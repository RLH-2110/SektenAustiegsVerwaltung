using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;


namespace Erinnerungsprogramm
{
    internal class ReminderManagement
    {
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
                return true;

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
              
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler beim Entfernen des Termins.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
