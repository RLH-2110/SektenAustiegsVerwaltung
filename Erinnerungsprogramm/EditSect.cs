using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Erinnerungsprogramm
{
    public partial class EditSect : Form, NotesHolder
    {
        private string notes = "";
        public string getNotes() { return notes; }

        private Control[] lockedElements;
        private string sectName = "";
        public EditSect()
        {
            InitializeComponent();

            lockedElements = new Control[] { tbxSectName, tbxLeader, tbxWebsite, btnNotes, btnDelete };

            try
            {
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                cmd.CommandText = $"select name from sect";

                using SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    comboBoxSectToEdit.Items.Add(reader.GetString(0));

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
            if (sectName == "")
            {
                MessageBox.Show("Kann nicht nichts Speichern!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbxSectName.Text.Trim() == "")
            {
                MessageBox.Show("Sekten Name kann nicht leer sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.CommandText = """
                    SELECT 1 FROM sect where name=$name_new
                 """;
                cmd.Parameters.AddWithValue("$name_new", tbxSectName.Text);

                if (cmd.ExecuteScalar() != null)
                {
                    MessageBox.Show("Sekte '" + tbxSectName.Text + "' ist bereits in der Datenbank!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.CommandText = """
                    PRAGMA foreign_keys = ON;
                    UPDATE sect set name = $name_new, leader = $leader, website = $website, notes = $notes where name = $name_orig;
                 """;

                
                cmd.Parameters.AddWithValue("$leader", tbxLeader.Text);
                cmd.Parameters.AddWithValue("$website", tbxWebsite.Text);
                cmd.Parameters.AddWithValue("$notes", notes);
                cmd.Parameters.AddWithValue("$name_orig", sectName);

                cmd.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
    
                MessageBox.Show("Datenbankfehler beim Speichern der Sekte.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxSectToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (comboBoxSectToEdit.SelectedItem == null)
                    return;

                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                sectName = (string)comboBoxSectToEdit.SelectedItem;

                cmd.CommandText = $"select 1 from sect where name=$name";
                cmd.Parameters.AddWithValue("$name", comboBoxSectToEdit.SelectedItem);

                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Feher! Sekte: '" + comboBoxSectToEdit.SelectedItem + "' ist nicht in der Datenbank!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // lock all elements, since we dont have anything valid to edit
                    foreach (Control c in lockedElements)
                        c.Enabled = false;

                    return;
                }


                // unlock stuff once we selected a sect to edit
                if (lockedElements[0].Enabled == false)
                    foreach (Control c in lockedElements)
                        c.Enabled = true;

                tbxSectName.Text = (string)comboBoxSectToEdit.SelectedItem;

                cmd.CommandText = $"select leader from sect where name=$name";
                tbxLeader.Text = cmd.ExecuteScalar().ToString();

                cmd.CommandText = $"select website from sect where name=$name";
                tbxWebsite.Text = cmd.ExecuteScalar().ToString();

                cmd.CommandText = $"select notes from sect where name=$name";
                notes = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler: \n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sectName = "";
                comboBoxSectToEdit.Text = "";

                // lock all elements, since we dont have anything valid to edit
                foreach (Control c in lockedElements)
                    c.Enabled = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.CommandText = """
                    delete from sect where name = $name
                 """;
                cmd.Parameters.AddWithValue("$name", sectName);
                cmd.ExecuteNonQuery();

                comboBoxSectToEdit.Items.Remove(sectName);
                sectName = "";
                comboBoxSectToEdit.Text = "";

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
