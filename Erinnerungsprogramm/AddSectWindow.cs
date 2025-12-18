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
    public partial class AddSectWindow : Form
    {
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

                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand(); // cant be null at this point, since we init early.
                cmd.CommandText = """
                    INSERT INTO sect (name, leader, website, notes)
                    VALUES ($name, $leader, $website, $notes)
                 """;
                cmd.Parameters.AddWithValue("$name", tbxSectName.Text);
                cmd.Parameters.AddWithValue("$leader", tbxLeader.Text);
                cmd.Parameters.AddWithValue("$website", tbxWebsite.Text);
                cmd.Parameters.AddWithValue("$notes", ""); // placeholder for now

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Datenbankfehler beim Hinzufügen der Sekte.\n\nFehler:\n"+ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
