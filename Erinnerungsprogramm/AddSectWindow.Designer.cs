namespace Erinnerungsprogramm
{
    partial class AddSectWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSectWindow));
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
            tableLayoutPanel1.Controls.Add(tbxLeader, 2, 2);
            tableLayoutPanel1.Controls.Add(label2, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(tbxSectName, 2, 1);
            tableLayoutPanel1.Controls.Add(tbxWebsite, 2, 3);
            tableLayoutPanel1.Controls.Add(btnCancel, 1, 4);
            tableLayoutPanel1.Controls.Add(btnNotes, 2, 4);
            tableLayoutPanel1.Controls.Add(btnAdd, 3, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9987488F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9987488F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9987488F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.003746F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(504, 161);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tbxLeader
            // 
            tbxLeader.Dock = DockStyle.Fill;
            tbxLeader.Location = new Point(123, 53);
            tbxLeader.Name = "tbxLeader";
            tbxLeader.Size = new Size(258, 23);
            tbxLeader.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 80);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Webseite";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 50);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 4;
            label3.Text = "Führer/in";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "Sekten Name";
            // 
            // tbxSectName
            // 
            tbxSectName.Dock = DockStyle.Fill;
            tbxSectName.Location = new Point(123, 23);
            tbxSectName.Name = "tbxSectName";
            tbxSectName.Size = new Size(258, 23);
            tbxSectName.TabIndex = 0;
            // 
            // tbxWebsite
            // 
            tbxWebsite.Dock = DockStyle.Fill;
            tbxWebsite.Location = new Point(123, 83);
            tbxWebsite.Name = "tbxWebsite";
            tbxWebsite.Size = new Size(258, 23);
            tbxWebsite.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Top;
            btnCancel.Location = new Point(23, 113);
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
            btnNotes.Location = new Point(123, 113);
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
            btnAdd.Location = new Point(387, 113);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 22);
            btnAdd.TabIndex = 22;
            btnAdd.Text = "Hinzufügen";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // AddSectWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 161);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(999999, 200);
            MinimizeBox = false;
            MinimumSize = new Size(520, 200);
            Name = "AddSectWindow";
            Text = "Sekte Hinzufügen";
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
        private Button btnNotes;
        private Button btnAdd;
        private Button btnCancel;
    }
}