namespace Erinnerungsprogramm
{
    partial class EditSect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tbxLeader = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            tbxSectName = new TextBox();
            tbxWebsite = new TextBox();
            btnCancel = new Button();
            btnNotes = new Button();
            btnAdd = new Button();
            label4 = new Label();
            comboBoxSectToEdit = new ComboBox();
            btnDelete = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tbxLeader, 2, 3);
            tableLayoutPanel1.Controls.Add(label2, 1, 4);
            tableLayoutPanel1.Controls.Add(label3, 1, 3);
            tableLayoutPanel1.Controls.Add(label1, 1, 2);
            tableLayoutPanel1.Controls.Add(tbxSectName, 2, 2);
            tableLayoutPanel1.Controls.Add(tbxWebsite, 2, 4);
            tableLayoutPanel1.Controls.Add(btnCancel, 1, 5);
            tableLayoutPanel1.Controls.Add(btnNotes, 2, 5);
            tableLayoutPanel1.Controls.Add(btnAdd, 3, 5);
            tableLayoutPanel1.Controls.Add(label4, 1, 1);
            tableLayoutPanel1.Controls.Add(comboBoxSectToEdit, 2, 1);
            tableLayoutPanel1.Controls.Add(btnDelete, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000019F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.999F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.999F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.999F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0029964F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(504, 191);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tbxLeader
            // 
            tbxLeader.Dock = DockStyle.Fill;
            tbxLeader.Enabled = false;
            tbxLeader.Location = new Point(123, 83);
            tbxLeader.Name = "tbxLeader";
            tbxLeader.Size = new Size(258, 23);
            tbxLeader.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 110);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Webseite";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 80);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 4;
            label3.Text = "Führer/in";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 50);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "Sekten Name";
            // 
            // tbxSectName
            // 
            tbxSectName.Dock = DockStyle.Fill;
            tbxSectName.Enabled = false;
            tbxSectName.Location = new Point(123, 53);
            tbxSectName.Name = "tbxSectName";
            tbxSectName.Size = new Size(258, 23);
            tbxSectName.TabIndex = 0;
            // 
            // tbxWebsite
            // 
            tbxWebsite.Dock = DockStyle.Fill;
            tbxWebsite.Enabled = false;
            tbxWebsite.Location = new Point(123, 113);
            tbxWebsite.Name = "tbxWebsite";
            tbxWebsite.Size = new Size(258, 23);
            tbxWebsite.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Top;
            btnCancel.Location = new Point(23, 143);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 22);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnNotes
            // 
            btnNotes.Dock = DockStyle.Top;
            btnNotes.Enabled = false;
            btnNotes.Location = new Point(123, 143);
            btnNotes.Name = "btnNotes";
            btnNotes.Size = new Size(258, 22);
            btnNotes.TabIndex = 21;
            btnNotes.Text = "Notizen";
            btnNotes.UseVisualStyleBackColor = true;
            btnNotes.Click += btnNotes_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Top;
            btnAdd.Location = new Point(387, 143);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 22);
            btnAdd.TabIndex = 22;
            btnAdd.Text = "Speichern";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 20);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 23;
            label4.Text = "Sekte";
            // 
            // comboBoxSectToEdit
            // 
            comboBoxSectToEdit.Dock = DockStyle.Top;
            comboBoxSectToEdit.FormattingEnabled = true;
            comboBoxSectToEdit.Location = new Point(123, 23);
            comboBoxSectToEdit.Name = "comboBoxSectToEdit";
            comboBoxSectToEdit.Size = new Size(258, 23);
            comboBoxSectToEdit.TabIndex = 24;
            comboBoxSectToEdit.SelectedIndexChanged += comboBoxSectToEdit_SelectedIndexChanged;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(387, 23);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 24);
            btnDelete.TabIndex = 25;
            btnDelete.Text = "Löschen";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // EditSect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 191);
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(99999, 230);
            MinimumSize = new Size(520, 230);
            Name = "EditSect";
            Text = "Sekte Bearbeiten";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbxLeader;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox tbxSectName;
        private TextBox tbxWebsite;
        private Button btnCancel;
        private Button btnNotes;
        private Button btnAdd;
        private Label label4;
        private ComboBox comboBoxSectToEdit;
        private Button btnDelete;
    }
}