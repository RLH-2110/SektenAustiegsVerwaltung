namespace Erinnerungsprogramm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                if (SQLlightManagement.init("data.db") == false)
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