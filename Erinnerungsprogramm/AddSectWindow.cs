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
    public partial class AddSectWindow : Form, NotesHolder
    {

        private string notes = "";
        public string getNotes() { return notes; }

        public AddSectWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxSectName.Text.Trim() == "")
            {
                MessageBox.Show("Sekten Name kann nicht leer sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init before the first window is created.
                cmd.CommandText = """
                    SELECT 1 FROM sect where name=$name
                 """;
                cmd.Parameters.AddWithValue("$name", tbxSectName.Text);

                if (cmd.ExecuteScalar() != null)
                {
                    MessageBox.Show("Sekte '" + tbxSectName.Text + "' ist bereits in der Datenbank!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.CommandText = """
                    INSERT INTO sect (name, leader, website, notes)
                    VALUES ($name, $leader, $website, $notes)
                 """;

                // the name parameter from line 39 is reused
                cmd.Parameters.AddWithValue("$leader", tbxLeader.Text);
                cmd.Parameters.AddWithValue("$website", tbxWebsite.Text);
                cmd.Parameters.AddWithValue("$notes", notes);

                cmd.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler beim Hinzufügen der Sekte.\n\nFehler:\n" + ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
