using Microsoft.Data.Sqlite;
using Microsoft.Win32.TaskScheduler;  
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Erinnerungsprogramm
{
    internal class ReminderManagement
    {
        private const string TASK_FOLDER = "ErringerungsProgrammRLH";

        static ReminderManagement? instance;
        public string toasterPath;
        public static bool init(string toasterPath)
        {
            if (instance == null)
            {
                try
                {
                    instance = new ReminderManagement(toasterPath);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        private ReminderManagement(string toasterPath)
        {
            this.toasterPath = toasterPath;
        }
        public static string getToasterPath()
        {
            if (instance == null) // should never happen
            {
                MessageBox.Show("Kritisher Fehler!\nReminderManagement instanz ist NULL!", "Kritischer Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
               
            return instance.toasterPath;
        }



        public static string constuctReminderIdentifier(Person person, long timestamp)
        {
            string baseString = timestamp.ToString() + person.ToString();

            return baseString.GetHashCode().ToString("X"); //will make it alphanumeric, so its allways valid chars
        }

        public static bool registerReminder(Person person, long timestamp)
        {
            try
            {

                //MessageBox.Show(constuctReminderIdentifier(person,timestamp));
                using (TaskService taskService = new TaskService())
                {
                    TaskDefinition taskDefinition = taskService.NewTask();
                    taskDefinition.RegistrationInfo.Description = "Anrufserrinerung";

                    TimeTrigger trigger = new TimeTrigger(DateTime.FromFileTime(timestamp));
                    trigger.EndBoundary = DateTime.FromFileTime(timestamp).AddDays(1);
                    taskDefinition.Triggers.Add(trigger);
                    

                    taskDefinition.Actions.Add(
                        new ExecAction(
                            getToasterPath(), "Anrufserrinnerung \"" + person.firstName + " " + person.lastName + " " + person.phone1 +
                            "\num " + DateTime.FromFileTime(timestamp).Hour.ToString() + ":" + DateTime.FromFileTime(timestamp).Minute.ToString()
                            + " Anrufen!\"")
                        );

                    taskDefinition.Settings.DeleteExpiredTaskAfter = TimeSpan.FromMinutes(1);
                    taskDefinition.Settings.StartWhenAvailable = true;
                    taskDefinition.Settings.DisallowStartIfOnBatteries = false;
                    taskDefinition.Settings.StopIfGoingOnBatteries = false;


                    string taskName = TASK_FOLDER + "\\" + constuctReminderIdentifier(person, timestamp);
                    taskService.RootFolder.RegisterTaskDefinition(
                        taskName,
                        taskDefinition,
                        TaskCreation.CreateOrUpdate,
                        null,
                        null,
                        TaskLogonType.InteractiveToken
                        );

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aufgabenplanungsfehler beim Hinzufügen des Termins.\n\nFehler:\n" + ex.Message, "Aufgabenplanungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }

        public static bool unregisterReminder(Person person, long timestamp)
        {
            try
            {

                string taskName = TASK_FOLDER + "\\" + constuctReminderIdentifier(person, timestamp);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "schtasks.exe",
                    Arguments = $"/Delete /TN \"{taskName}\" /F",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aufgabenplanungsfehler beim Entfernen des Termins.\n\nFehler:\n" + ex.Message, "Aufgabenplanungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool addReminder(Person person, long timestamp)
        {
            try
            {

                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.CommandText = """
                    SELECT 1 FROM calls where first_name=$first_name and last_name=$last_name and phone1=$phone1 and timestamp=$timestamp
                 """;
                cmd.Parameters.AddWithValue("$first_name", person.firstName);
                cmd.Parameters.AddWithValue("$last_name", person.lastName);
                cmd.Parameters.AddWithValue("$phone1", person.phone1);
                cmd.Parameters.AddWithValue("$timestamp", timestamp);

                if (cmd.ExecuteScalar() != null)
                {
                    MessageBox.Show("Termin für person '" + person.ToString() + "' am '"+ DateTime.FromFileTime(timestamp).ToString("dddd dd.MM.yyyy HH:mm") +"' ist bereits in der Datenbank!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                cmd.CommandText = """
                    INSERT INTO calls (first_name, last_name, phone1, timestamp)
                    VALUES ($first_name, $last_name, $phone1, $timestamp)
                 """;

                // parameters are reused

                cmd.ExecuteNonQuery();

                return registerReminder(person, timestamp);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler beim Hinzufügen des Termins.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        public static bool removeReminder(Person person, long timestamp)
        {
            try
            {

                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.CommandText = """
                    delete FROM calls where first_name=$first_name and last_name=$last_name and phone1=$phone1 and timestamp=$timestamp
                 """;
                cmd.Parameters.AddWithValue("$first_name", person.firstName);
                cmd.Parameters.AddWithValue("$last_name", person.lastName);
                cmd.Parameters.AddWithValue("$phone1", person.phone1);
                cmd.Parameters.AddWithValue("$timestamp", timestamp);

                cmd.ExecuteNonQuery();
              
                return unregisterReminder(person,timestamp);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler beim Entfernen des Termins.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
