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
    public partial class AddPersonWindow : Form, NotesHolder
    {
        private string notes = "";
        public string getNotes() { return notes; }

        private string sectName = "";

        public AddPersonWindow()
        {
            InitializeComponent();

            try
            {
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                cmd.CommandText = $"select name from sect";

                using SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    cbxSect.Items.Add(reader.GetString(0));

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

        private void btnNotes_Click(object sender, EventArgs e)
        {
            AddNotes notesWindow = new AddNotes();
            DialogResult result = notesWindow.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                notes = notesWindow.returnString;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxSect.SelectedItem == null)
            {
                MessageBox.Show("Sekte ausgewüllt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbxFirstName.Text.Trim() == "" && tbxLastName.Text == "" && tbxPhone1.Text == "")
            {
                MessageBox.Show("Vorname, Nachname oder Telefon1 muss ausgewüllt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.CommandText = """
                    SELECT 1 FROM person where first_name=$first_name and last_name=$last_name and phone1=$phone1 
                 """;
                cmd.Parameters.AddWithValue("$first_name", tbxFirstName.Text);
                cmd.Parameters.AddWithValue("$last_name", tbxLastName.Text);
                cmd.Parameters.AddWithValue("$phone1", tbxPhone1.Text);

                if (cmd.ExecuteScalar() != null)
                {
                    MessageBox.Show("Sekte '" + tbxFirstName.Text+" "+ tbxLastName.Text+" "+ tbxPhone1.Text + "' ist bereits in der Datenbank!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.CommandText = """
                    INSERT INTO person (first_name, last_name, phone1, phone2, email, city, postal, street, house_nr, sect_name, notes)
                    VALUES ($first_name, $last_name, $phone1, $phone2, $email, $city, $postal, $street, $house_nr, $sect_name, $notes)
                 """;

                // the first_name, last_name and phone1 parameters are reused
                cmd.Parameters.AddWithValue("$phone2", tbxPhone2.Text);
                cmd.Parameters.AddWithValue("$email", tbxEmail.Text);
                cmd.Parameters.AddWithValue("$city", tbxCity.Text);
                cmd.Parameters.AddWithValue("$postal", tbxPostal.Text);
                cmd.Parameters.AddWithValue("$street", tbxStreet.Text);
                cmd.Parameters.AddWithValue("$house_nr", tbxHouseNumber.Text);
                cmd.Parameters.AddWithValue("$sect_name", sectName);
                cmd.Parameters.AddWithValue("$notes", notes);

                cmd.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler beim Hinzufügen der Person.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxSect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSect.SelectedItem == null)
                return;

            try
            {
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                sectName = (string)cbxSect.SelectedItem;

                cmd.CommandText = $"select 1 from sect where name=$name";
                cmd.Parameters.AddWithValue("$name", cbxSect.SelectedItem);

                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Feher! Sekte: '" + cbxSect.SelectedItem + "' ist nicht in der Datenbank!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Datenbankfehler: \n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sectName = "";
                cbxSect.Text = "";
            }
        }
    }
}
