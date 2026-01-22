using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Erinnerungsprogramm
{
    internal static class Program
    {
        public const string timeFormat = "ddd d.MM.yy HH: mm";
        private const string defaultSQLDatabase = "data.db";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string? databasePath;

            try
            {
                databasePath = (string?)Registry.GetValue("HKEY_CURRENT_USER\\Software\\RLH-2110\\Erinnerungsprogramm", "databasePath", null);

                if (databasePath == null || File.Exists(databasePath) == false) // if any problems arise 
                {
                    if (File.Exists(defaultSQLDatabase) == false)
                    {
                        DialogResult result = MessageBox.Show("Datenbankdatei kann nicht gefunden werden!\nSoll eine neue Datenbank Angelegt werden?", "Datenbank", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result != DialogResult.Yes)
                            return;
                    }

                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\RLH-2110\\Erinnerungsprogramm", "databasePath", new FileInfo(defaultSQLDatabase).FullName, RegistryValueKind.String);
                    databasePath = defaultSQLDatabase;

                }


            }catch(Exception e)
            {
                MessageBox.Show("Programstartfehler!\n"+e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                if (SQLlightManagement.init(databasePath) == false)
                    return; // exit programm on error

                Application.Run(new mainForm());
            }catch(Exception e)
            {
                MessageBox.Show("Kriticher Unbekannter Fehler!\n" + e.Message, "Kritisher Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SQLlightManagement.deinit();
        }

   
    }
}