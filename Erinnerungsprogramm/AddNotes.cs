using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Erinnerungsprogramm
{
    public partial class AddNotes : Form
    {

        public string returnString = "";

        public AddNotes()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            returnString = richTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddNotes_Shown(object sender, EventArgs e)
        {
            if (this.Owner == null)
            {
                MessageBox.Show("Fehler: Kein Owner für das übernehmen der Notizen!","Fehler",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (this.Owner is NotesHolder)
            {
                richTextBox.Text = ((NotesHolder)this.Owner).getNotes();
            }
            else
            {
                MessageBox.Show("Fehler: Owner kann keine Notizen übergeben!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
