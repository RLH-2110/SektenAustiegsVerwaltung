using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace Erinnerungsprogramm
{
    public partial class mainForm : Form
    {
        private const byte grpBoxPadding = 12;
        private const byte grpBoxHeight = 85;
        private const byte grpBoxInnerUpperPadding = 16;

        private const byte btnSidePadding = 6;
        private const byte btnHeight = 23;

        Button[] upperButtons;


        public mainForm()
        {
            InitializeComponent();

            upperButtons = new Button[4];
            upperButtons[0] = btnAddPerson;
            upperButtons[1] = btnEditPerson;
            upperButtons[2] = btnAddSect;
            upperButtons[3] = btnEditSect;

            dateTimePickerAddCall.CustomFormat = Program.timeFormat;

            if (updatesCallablePersons() == false)
                this.Close();


            // get existing calls
            try
            {
                // get primary keys and names of persons
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                cmd.CommandText = $"select first_name,last_name,phone1,timestamp from calls";

                SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    long timestamp = reader.GetInt64(3);
                    uiAddCallUnchecked(person,timestamp);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler: \n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool updatesCallablePersons()
        {
            try
            {
                comboBoxPersonToCall.Items.Clear();

                // get primary keys and names of persons
                SqliteCommand cmd = SQLlightManagement.getConnection().CreateCommand();

                cmd.CommandText = $"select first_name,last_name,phone1 from person";

                SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    comboBoxPersonToCall.Items.Add(person);
                }

                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbankfehler: \n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }


        private void update_components_size()
        {

            short grpBoxHalfScreenSizeX = (short)(this.ClientSize.Width / 2 - grpBoxPadding - grpBoxPadding / 2);
            short grpBoxFullScreenSizeX = (short)(this.ClientSize.Width - grpBoxPadding * 2);

            // place upper left corner
            grpBox_add.Location = new Point(grpBoxPadding, grpBoxPadding + menuStrip.Size.Height);
            // size = ~ half the width of the window
            grpBox_add.Size = new Size(grpBoxHalfScreenSizeX, grpBoxHeight);

            //place right of grpBox_add
            grpBox_edit.Location = new Point(grpBox_add.Location.X + grpBox_add.Size.Width + grpBoxPadding, grpBoxPadding + +menuStrip.Size.Height);
            // size = ~ half the width of the window
            grpBox_edit.Size = new Size(grpBoxHalfScreenSizeX, grpBoxHeight);

            // place under grpBox_add
            scrollPannel.Location = new Point(grpBoxPadding, grpBox_add.Location.Y + grpBox_add.Size.Height + grpBoxPadding);
            // size = ~ the full width of the window
            scrollPannel.Size = new Size(grpBoxFullScreenSizeX, this.ClientSize.Height - grpBoxPadding - scrollPannel.Location.Y);

            // set button Sizes
            foreach (Button btn in upperButtons)
                btn.Size = new Size(grpBox_add.Size.Width - btnSidePadding * 2, btnHeight);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            update_components_size();
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            update_components_size();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddPersonWindow newWind = new AddPersonWindow();
            newWind.Show(this);
        }

        private void btnAddSect_Click(object sender, EventArgs e)
        {
            AddSectWindow newWind = new AddSectWindow();
            newWind.Show(this);
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            EditPerson newWind = new EditPerson();
            newWind.Show(this);
        }

        private void btnEditSect_Click(object sender, EventArgs e)
        {
            EditSect newWind = new EditSect();
            newWind.Show(this);
        }


        private void btnRemoveCall_Click(object sender, EventArgs e)
        {
            if (sender is Control == false)
                return;

            int rowIndex = callTableLayout.GetRow((Control)sender);

           

            Label? lblPerson    = (Label?)  callTableLayout.GetControlFromPosition(0, rowIndex);
            Label? lblTimestamp = (Label?)  callTableLayout.GetControlFromPosition(1, rowIndex);

            if (lblPerson is Label && lblTimestamp is Label && lblPerson.Tag is Person && lblTimestamp.Tag is long)
            {
                ReminderManagement.removeReminder((Person)lblPerson.Tag, (long)lblTimestamp.Tag);
            }
            else
            {
                MessageBox.Show("Interner Fehler beim löchen des Termins in der btnRemoveCall_Click routine!");
                return;
            }

            /* https://stackoverflow.com/questions/15535214/removing-a-specific-row-in-tablelayoutpanel/31371962#31371962 */

            for (int i = 0; i < callTableLayout.ColumnCount; i++)
            {
                Control? control = callTableLayout.GetControlFromPosition(i, rowIndex);
                callTableLayout.Controls.Remove(control);
            }


            for (int i = rowIndex + 1; i < callTableLayout.RowCount; i++)
            {
                for (int j = 0; j < callTableLayout.ColumnCount; j++)
                {
                    var control = callTableLayout.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        callTableLayout.SetRow(control, i - 1);
                    }
                }
            }

            var removeStyle = callTableLayout.RowCount - 1;

            if (callTableLayout.RowStyles.Count > removeStyle)
                callTableLayout.RowStyles.RemoveAt(removeStyle);

            callTableLayout.RowCount--;


        }
        private void btnAddCall_Click(object sender, EventArgs e)
        {
            if (comboBoxPersonToCall.SelectedIndex == -1)
                return;
            if (comboBoxPersonToCall.SelectedItem is Person == false)
                return;
            if (ReminderManagement.addReminder((Person)comboBoxPersonToCall.SelectedItem, dateTimePickerAddCall.Value.ToFileTime()) == false)
                return;

            uiAddCallUnchecked((Person)comboBoxPersonToCall.SelectedItem, dateTimePickerAddCall.Value.ToFileTime());



        }

        private void uiAddCallUnchecked(Person person, long timestamp)
        {
            callTableLayout.RowCount++;
            callTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, callTableLayout.RowStyles[0].Height));

            Label lblAddedPerson = new Label();

            lblAddedPerson.Dock = DockStyle.Top;
            lblAddedPerson.Location = new Point(3, 3);
            lblAddedPerson.AutoSize = true;
            lblAddedPerson.Text = person.ToString();
            lblAddedPerson.Tag = person;

            Label lblAddedTime = new Label();
            lblAddedTime.Dock = DockStyle.Top;
            lblAddedTime.Location = new Point(3, 3);
            lblAddedTime.AutoSize = true;
            lblAddedTime.Text = DateTime.FromFileTime(timestamp).ToString(Program.timeFormat);
            lblAddedTime.Tag = timestamp;

            Button btnRemoveCall = new Button();
            btnRemoveCall.Dock = DockStyle.Top;
            btnRemoveCall.Location = new Point(3, 3);
            btnRemoveCall.Size = btnAddCall.Size;
            btnRemoveCall.Text = "-";
            btnRemoveCall.Click += btnRemoveCall_Click;

            callTableLayout.Controls.Add(lblAddedPerson, 0, callTableLayout.RowCount - 1);
            callTableLayout.Controls.Add(lblAddedTime, 1, callTableLayout.RowCount - 1);
            callTableLayout.Controls.Add(btnRemoveCall, 2, callTableLayout.RowCount - 1);
        }

    }
}
