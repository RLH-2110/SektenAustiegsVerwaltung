namespace Erinnerungsprogramm
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddPerson = new Button();
            btnAddSect = new Button();
            btnEditPerson = new Button();
            btnEditSect = new Button();
            grpBox_add = new GroupBox();
            grpBox_edit = new GroupBox();
            grpBox_plannedCalls = new GroupBox();
            callTableLayout = new TableLayoutPanel();
            btnAddCall = new Button();
            dateTimePickerAddCall = new DateTimePicker();
            menuStrip = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            einstellungenToolStripMenuItem = new ToolStripMenuItem();
            comboBoxPersonToCall = new ComboBox();
            grpBox_add.SuspendLayout();
            grpBox_edit.SuspendLayout();
            grpBox_plannedCalls.SuspendLayout();
            callTableLayout.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddPerson
            // 
            btnAddPerson.Location = new Point(6, 22);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new Size(133, 23);
            btnAddPerson.TabIndex = 0;
            btnAddPerson.Text = "Person Hinzufügen";
            btnAddPerson.UseVisualStyleBackColor = true;
            btnAddPerson.Click += btnAddPerson_Click;
            // 
            // btnAddSect
            // 
            btnAddSect.Location = new Point(6, 51);
            btnAddSect.Name = "btnAddSect";
            btnAddSect.Size = new Size(133, 23);
            btnAddSect.TabIndex = 1;
            btnAddSect.Text = "Sekte Hinzufügen";
            btnAddSect.UseVisualStyleBackColor = true;
            btnAddSect.Click += btnAddSect_Click;
            // 
            // btnEditPerson
            // 
            btnEditPerson.Location = new Point(6, 22);
            btnEditPerson.Name = "btnEditPerson";
            btnEditPerson.Size = new Size(133, 23);
            btnEditPerson.TabIndex = 2;
            btnEditPerson.Text = "Person Verwalten";
            btnEditPerson.UseVisualStyleBackColor = true;
            btnEditPerson.Click += btnEditPerson_Click;
            // 
            // btnEditSect
            // 
            btnEditSect.Location = new Point(6, 51);
            btnEditSect.Name = "btnEditSect";
            btnEditSect.Size = new Size(133, 23);
            btnEditSect.TabIndex = 3;
            btnEditSect.Text = "Sekte Verwalten";
            btnEditSect.UseVisualStyleBackColor = true;
            btnEditSect.Click += btnEditSect_Click;
            // 
            // grpBox_add
            // 
            grpBox_add.Controls.Add(btnAddPerson);
            grpBox_add.Controls.Add(btnAddSect);
            grpBox_add.Location = new Point(12, 27);
            grpBox_add.Name = "grpBox_add";
            grpBox_add.Size = new Size(150, 85);
            grpBox_add.TabIndex = 4;
            grpBox_add.TabStop = false;
            grpBox_add.Text = "Hinzufügen";
            // 
            // grpBox_edit
            // 
            grpBox_edit.Controls.Add(btnEditSect);
            grpBox_edit.Controls.Add(btnEditPerson);
            grpBox_edit.Location = new Point(168, 27);
            grpBox_edit.Name = "grpBox_edit";
            grpBox_edit.Size = new Size(148, 85);
            grpBox_edit.TabIndex = 5;
            grpBox_edit.TabStop = false;
            grpBox_edit.Text = "Verwalten";
            // 
            // grpBox_plannedCalls
            // 
            grpBox_plannedCalls.Controls.Add(callTableLayout);
            grpBox_plannedCalls.Location = new Point(12, 118);
            grpBox_plannedCalls.Name = "grpBox_plannedCalls";
            grpBox_plannedCalls.Size = new Size(304, 138);
            grpBox_plannedCalls.TabIndex = 6;
            grpBox_plannedCalls.TabStop = false;
            grpBox_plannedCalls.Text = "Geplante Anrufe";
            // 
            // callTableLayout
            // 
            callTableLayout.ColumnCount = 3;
            callTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            callTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            callTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            callTableLayout.Controls.Add(btnAddCall, 2, 0);
            callTableLayout.Controls.Add(dateTimePickerAddCall, 1, 0);
            callTableLayout.Controls.Add(comboBoxPersonToCall, 0, 0);
            callTableLayout.Dock = DockStyle.Fill;
            callTableLayout.Location = new Point(3, 19);
            callTableLayout.Name = "callTableLayout";
            callTableLayout.RowCount = 1;
            callTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            callTableLayout.Size = new Size(298, 116);
            callTableLayout.TabIndex = 0;
            // 
            // btnAddCall
            // 
            btnAddCall.Dock = DockStyle.Top;
            btnAddCall.Location = new Point(281, 3);
            btnAddCall.Name = "btnAddCall";
            btnAddCall.Size = new Size(14, 23);
            btnAddCall.TabIndex = 0;
            btnAddCall.Text = "+";
            btnAddCall.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerAddCall
            // 
            dateTimePickerAddCall.CustomFormat = "ddd d.MM.yy HH:mm";
            dateTimePickerAddCall.Dock = DockStyle.Top;
            dateTimePickerAddCall.Format = DateTimePickerFormat.Custom;
            dateTimePickerAddCall.Location = new Point(142, 3);
            dateTimePickerAddCall.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePickerAddCall.Name = "dateTimePickerAddCall";
            dateTimePickerAddCall.Size = new Size(133, 23);
            dateTimePickerAddCall.TabIndex = 2;
            dateTimePickerAddCall.Value = new DateTime(2025, 1, 1, 12, 0, 0, 0);
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, einstellungenToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(334, 24);
            menuStrip.TabIndex = 7;
            menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 20);
            // 
            // einstellungenToolStripMenuItem
            // 
            einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            einstellungenToolStripMenuItem.Size = new Size(90, 20);
            einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // comboBoxPersonToCall
            // 
            comboBoxPersonToCall.Dock = DockStyle.Top;
            comboBoxPersonToCall.FormattingEnabled = true;
            comboBoxPersonToCall.Location = new Point(3, 3);
            comboBoxPersonToCall.Name = "comboBoxPersonToCall";
            comboBoxPersonToCall.Size = new Size(133, 23);
            comboBoxPersonToCall.TabIndex = 3;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 266);
            Controls.Add(grpBox_plannedCalls);
            Controls.Add(grpBox_edit);
            Controls.Add(grpBox_add);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(350, 305);
            Name = "mainForm";
            Text = "Hauptfenster";
            Load += Form1_Load;
            ClientSizeChanged += Form1_ClientSizeChanged;
            grpBox_add.ResumeLayout(false);
            grpBox_edit.ResumeLayout(false);
            grpBox_plannedCalls.ResumeLayout(false);
            callTableLayout.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddPerson;
        private Button btnAddSect;
        private Button btnEditPerson;
        private Button btnEditSect;
        private GroupBox grpBox_add;
        private GroupBox grpBox_edit;
        private GroupBox grpBox_plannedCalls;
        private MenuStrip menuStrip;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem einstellungenToolStripMenuItem;
        private TableLayoutPanel callTableLayout;
        private Button btnAddCall;
        private DateTimePicker dateTimePickerAddCall;
        private ComboBox comboBoxPersonToCall;
    }
}
