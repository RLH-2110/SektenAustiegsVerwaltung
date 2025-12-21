using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace Erinnerungsprogramm
{
    class SQLlightManagement
    {

        private static SQLlightManagement? instance = null;
        private static SqliteConnection? connection = null;

        public static bool init(string dataBaseFile)
        {
            if (instance == null)
            {
                try
                {
                    instance = new SQLlightManagement(dataBaseFile);
                }catch(Exception)
                {
                    return false;
                }

                return true;
            }
        
            return false;
        }
        public static SqliteConnection? getConnection() { return connection; }

        private SQLlightManagement(string dataBaseFile)
        {

            try
            {
                if (File.Exists(dataBaseFile))
                {
                    connection = new SqliteConnection("Data Source=" + dataBaseFile);
                    connection.Open();

                    // check if the database is valid.
                    validateDatabase();
                    return;
                }
            }
            catch (Exception e)
            {
                try
                {
                    if (connection != null)
                    connection.Close();
                }catch(Exception)
                {}

                SqliteConnection.ClearAllPools();

                handleDatabaseOpenErrors(e, dataBaseFile); // either throws another exception that we intercept at init, or falls though to the database creation code
            }

            // Database does not exist

            connection = new SqliteConnection("Data Source=" + dataBaseFile);
            connection.Open();

            // create the tables
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = """
            CREATE TABLE sect (
                name TEXT PRIMARY KEY,
                leader  TEXT,
                website TEXT,
                notes   TEXT
            );

            CREATE TABLE person (
                first_name  TEXT NOT NULL,
                last_name   TEXT NOT NULL,
                phone1      TEXT NOT NULL,
                phone2      TEXT,
                email       TEXT,
                city        TEXT,
                postal      TEXT,
                street      TEXT,
                house_nr    TEXT,
                sect_name   TEXT,
                notes       TEXT,

                PRIMARY KEY (first_name, last_name, phone1),
                FOREIGN KEY (sect_name) REFERENCES sect(name) ON UPDATE CASCADE
            );

            CREATE TABLE calls (
                first_name  TEXT NOT NULL,
                last_name   TEXT NOT NULL,
                phone1      TEXT NOT NULL,
                timestamp   INTEGER,
                PRIMARY KEY (first_name, last_name, phone1, timestamp)
                FOREIGN KEY (first_name, last_name, phone1) REFERENCES person(first_name, last_name, phone1) ON UPDATE CASCADE
            );
            """;
            cmd.ExecuteNonQuery();
        }

        ~SQLlightManagement()
        {
            if (connection != null)
                connection.Close();
        }

        // lazy checking if its valid (right tables, and columns) ingores keys and data types
        private void validateDatabase()
        {
            if (connection == null)
                throw new Exception("Database connection does not exist");

            // check table person
            using SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = """
                SELECT 1
                FROM sqlite_master
                WHERE type = 'table' AND name = 'person';
            """;

            if (cmd.ExecuteScalar() == null)
                throw new Exception("Person Table does not exist");

            // check table sect
            cmd.CommandText = """
                SELECT 1
                FROM sqlite_master
                WHERE type = 'table' AND name = 'sect';
            """;

            if (cmd.ExecuteScalar() == null)
                throw new Exception("sect Table does not exist");

            // check table calls
            cmd.CommandText = """
                SELECT 1
                FROM sqlite_master
                WHERE type = 'table' AND name = 'calls';
            """;

            if (cmd.ExecuteScalar() == null)
                throw new Exception("calls Table does not exist");

            // check columns in person
            {
                string[] expectedColumns = { "first_name", "last_name", "phone1", "phone2", "email", "city", "postal", "street", "house_nr", "sect_name", "notes" };
                List<string> foundColums = new List<string>();

                cmd.CommandText = $"PRAGMA table_info(person);";

                using SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foundColums.Add(reader.GetString(1)); // get column name
                }

                foreach (string column in expectedColumns)
                    if (foundColums.Contains(column) == false)
                        throw new Exception("person table does not have column '" + column + "'");
            }

            // check columns in sect
            {
                string[] expectedColumns = { "name", "leader", "website", "notes" };
                List<string> foundColums = new List<string>();

                cmd.CommandText = $"PRAGMA table_info(sect);";

                using SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foundColums.Add(reader.GetString(1)); // get column name
                }

                foreach (string column in expectedColumns)
                    if (foundColums.Contains(column) == false)
                        throw new Exception("sect table does not have column '" + column + "'");
            }

            // check columns in calls
            {
                string[] expectedColumns = { "first_name", "last_name", "phone1", "timestamp" };
                List<string> foundColums = new List<string>();

                cmd.CommandText = $"PRAGMA table_info(calls);";

                using SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foundColums.Add(reader.GetString(1)); // get column name
                }

                foreach (string column in expectedColumns)
                    if (foundColums.Contains(column) == false)
                        throw new Exception("calls table does not have column '" + column + "'");
            }
        }
        private void handleDatabaseOpenErrors(Exception e, string dataBaseFile)
        {
            DialogResult result;

            if (e is SqliteException)
                result = MessageBox.Show("Ein Datenbankfehler ist Aufgetreten!\nWollen Sie die Datenbank Neu erstellen? Warnung: Alle Daten würden verloren gehen!\n\nFehler:\n"+e.Message, "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            else 
                result = MessageBox.Show("Datenbank hat falsches format!\nWollen Sie die Datenbank Neu erstellen? Warnung: Alle Daten würden verloren gehen!\n\nFehler:\n"+e.Message, "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (result == DialogResult.No)
            {
                throw new Exception(); // this is to tell the init function that we failed, since we cant return false here
            }

            if (result == DialogResult.Yes)
            {
                result = MessageBox.Show("Sind sie sicher? Alle Daten werden verloren gehen!", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    throw new Exception(); // this is to tell the init function that we failed, since we cant return false here
                }

                try
                {
                    File.Delete(dataBaseFile);
                }
                catch
                {
                    MessageBox.Show("Datenbank kann nicht neu erstellt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception();  // this is to tell the init function that we failed, since we cant return false here
                }
            }

            // just fall though if we sucessfully deleted the old database, and create a new one
        }
    }
}
