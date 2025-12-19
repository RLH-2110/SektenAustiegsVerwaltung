namespace Erinnerungsprogramm
{
    partial class AddNotes
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
            btnCancel = new Button();
            btnSave = new Button();
            richTextBox = new RichTextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnCancel, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 1);
            tableLayoutPanel1.Controls.Add(richTextBox, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(475, 396);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Left;
            btnCancel.Location = new Point(3, 359);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 34);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Right;
            btnSave.Location = new Point(397, 359);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 34);
            btnSave.TabIndex = 1;
            btnSave.Text = "Speichern";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // richTextBox
            // 
            tableLayoutPanel1.SetColumnSpan(richTextBox, 2);
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Location = new Point(3, 3);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(469, 350);
            richTextBox.TabIndex = 2;
            richTextBox.Text = "";
            // 
            // AddNotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 396);
            Controls.Add(tableLayoutPanel1);
            Name = "AddNotes";
            Text = "Notizen Hinzufügen";
            Shown += AddNotes_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnCancel;
        private Button btnSave;
        private RichTextBox richTextBox;
    }
}