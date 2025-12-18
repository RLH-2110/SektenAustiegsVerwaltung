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


        unsafe public mainForm()
        {
            InitializeComponent();

            upperButtons = new Button[4];
            upperButtons[0] = btnAddPerson;
            upperButtons[1] = btnEditPerson;
            upperButtons[2] = btnAddSect;
            upperButtons[3] = btnEditSect;

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
            grpBox_plannedCalls.Location = new Point(grpBoxPadding, grpBox_add.Location.Y + grpBox_add.Size.Height + grpBoxPadding);
            // size = ~ the full width of the window
            grpBox_plannedCalls.Size = new Size(grpBoxFullScreenSizeX, this.ClientSize.Height - grpBoxPadding - grpBox_plannedCalls.Location.Y);

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
            newWind.Show();
        }

        private void btnAddSect_Click(object sender, EventArgs e)
        {
            AddSectWindow newWind = new AddSectWindow();
            newWind.Show();
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            EditPerson newWind = new EditPerson();
            newWind.Show();
        }

        private void btnEditSect_Click(object sender, EventArgs e)
        {
            EditSect newWind = new EditSect();
            newWind.Show();
        }
    }
}
