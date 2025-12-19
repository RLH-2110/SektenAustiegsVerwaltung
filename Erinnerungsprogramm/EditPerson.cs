using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Erinnerungsprogramm
{
    public partial class EditPerson : Form, NotesHolder
    {
        private string notes = "";
        public string getNotes() { return notes; }

        private Control[] lockedElements;
        private Person? currentPerson = null;
        private string currentSect = "";

        private List<Person> personPrimaryKeys = new List<Person>();

        public EditPerson()
        {
            InitializeComponent();

            lockedElements = new Control[] { tbxFirstName, tbxLastName, tbxPhone1, tbxPhone2, tbxEmail, tbxCity, tbxPostal, tbxStreet, tbxHouseNumber, cbxSect, btnNotes, btnDelete };

            try
            {
                // get primary keys and names of persons
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                cmd.CommandText = $"select first_name,last_name,phone1 from person";

                SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    personPrimaryKeys.Add(person);
                    comboBoxPersonToEdit.Items.Add(person);
                }

                reader.Close();

                // get all available sects
                cmd.CommandText = $"select name from sect";

                reader = cmd.ExecuteReader();

                while (reader.Read())
                    cbxSect.Items.Add(reader.GetString(0));

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler: \n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentPerson == null)
            {
                MessageBox.Show("Fehler Ausgewählte person ist NULL!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbxSect.SelectedItem == null)
            {
                MessageBox.Show("Sekte ausgewüllt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxFirstName.Text.Trim() == "" && tbxLastName.Text.Trim() == "" && tbxPhone1.Text.Trim() == "")
            {
                MessageBox.Show("Vorname, Nachname oder Telefon1 muss ausgewüllt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqliteTransaction? transaction = null;

            try
            {
                transaction = SQLlightManagement.getConnection().BeginTransaction();
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.Transaction = transaction;
                cmd.CommandText = """
                    delete from person where first_name=$first_name and last_name=$last_name and phone1=$phone1
                 """;
                cmd.Parameters.AddWithValue("first_name", currentPerson.Value.firstName);
                cmd.Parameters.AddWithValue("$last_name", currentPerson.Value.lastName);
                cmd.Parameters.AddWithValue("$phone1", currentPerson.Value.phone1);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = """
                    INSERT INTO person (first_name, last_name, phone1, phone2, email, city, postal, street, house_nr, sect_name, notes)
                    VALUES ($first_name, $last_name, $phone1, $phone2, $email, $city, $postal, $street, $house_nr, $sect_name, $notes)
                 """;

                cmd.Parameters.AddWithValue("first_name", tbxFirstName.Text);
                cmd.Parameters.AddWithValue("$last_name", tbxLastName.Text);
                cmd.Parameters.AddWithValue("$phone1", tbxPhone1.Text);
                cmd.Parameters.AddWithValue("$phone2", tbxPhone2.Text);
                cmd.Parameters.AddWithValue("$email", tbxEmail.Text);
                cmd.Parameters.AddWithValue("$city", tbxCity.Text);
                cmd.Parameters.AddWithValue("$postal", tbxPostal.Text);
                cmd.Parameters.AddWithValue("$street", tbxStreet.Text);
                cmd.Parameters.AddWithValue("$house_nr", tbxHouseNumber.Text);
                cmd.Parameters.AddWithValue("$sect_name", cbxSect.SelectedItem);
                cmd.Parameters.AddWithValue("$notes", notes);

                cmd.ExecuteNonQuery();
                transaction.Commit();
                this.Close();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                MessageBox.Show("Datenbankfehler beim Speichern der Person.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            AddNotes notesWindow = new AddNotes();
            DialogResult result = notesWindow.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                notes = notesWindow.returnString;
            }
        }

        private void comboBoxPersonToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (comboBoxPersonToEdit.SelectedItem == null)
                    return;

                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                currentPerson = (Person)comboBoxPersonToEdit.SelectedItem;

                cmd.CommandText = $"select 1 from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                cmd.Parameters.AddWithValue("$first_name", currentPerson.Value.firstName);
                cmd.Parameters.AddWithValue("$last_name", currentPerson.Value.lastName);
                cmd.Parameters.AddWithValue("$phone1", currentPerson.Value.phone1);

                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Feher! Person: '" + currentPerson.ToString() + "' ist nicht in der Datenbank!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // lock all elements, since we dont have anything valid to edit
                    foreach (Control c in lockedElements)
                        c.Enabled = false;

                    return;
                }


                // unlock stuff once we selected a sect to edit
                if (lockedElements[0].Enabled == false)
                    foreach (Control c in lockedElements)
                        c.Enabled = true;

                tbxFirstName.Text = currentPerson.Value.firstName;
                tbxLastName.Text = currentPerson.Value.lastName;
                tbxPhone1.Text = currentPerson.Value.phone1;

                cmd.CommandText = $"select phone2 from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                tbxPhone2.Text = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"select email from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                tbxEmail.Text = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"select city from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                tbxCity.Text = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"select postal from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                tbxPostal.Text = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"select street from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                tbxStreet.Text = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"select house_nr from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                tbxHouseNumber.Text = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"select notes from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                notes = cmd.ExecuteScalar().ToString();


                cmd.CommandText = $"select sect_name from person where first_name=$first_name and last_name=$last_name and phone1=$phone1";
                string sect = cmd.ExecuteScalar().ToString();

                if (cbxSect.Items.Contains(sect) == false)
                {
                    MessageBox.Show("Sekte: '" + sect + "' existiert nicht In der Datenbank! Bitte Geben sie die Sekete Erneut an!");
                    currentSect = "";
                    cbxSect.SelectedText = "";
                }
                else
                {
                    currentSect = sect;
                    cbxSect.SelectedItem = sect;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler: \n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentSect = "";
                currentPerson = null;
                comboBoxPersonToEdit.Text = "";

                // lock all elements, since we dont have anything valid to edit
                foreach (Control c in lockedElements)
                    c.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.CommandText = """
                    delete from person where first_name=$first_name and last_name=$last_name and phone1=$phone1
                 """;
                cmd.Parameters.AddWithValue("first_name", currentPerson.Value.firstName);
                cmd.Parameters.AddWithValue("$last_name", currentPerson.Value.lastName);
                cmd.Parameters.AddWithValue("$phone1", currentPerson.Value.phone1);
                cmd.ExecuteNonQuery();

                comboBoxPersonToEdit.Items.Remove(currentPerson);
                currentSect = "";
                comboBoxPersonToEdit.Text = "";

                // lock all elements, since we dont have anything valid to edit
                foreach (Control c in lockedElements)
                    c.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler beim löschen der Sekte.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
