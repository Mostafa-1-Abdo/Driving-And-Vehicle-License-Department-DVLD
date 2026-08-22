using System;
using System.Windows.Forms;
using DVLD.UI.Users;

namespace DVLD.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void msi_People_Click(object sender, EventArgs e)
        {
            frmManagePeople Form = new frmManagePeople();
            Form.ShowDialog() ;
        }

        private void msi_Drivers_Click(object sender, EventArgs e)
        {

        }

        private void msi_CurrentUserInfo_Click(object sender, EventArgs e)
        {
          
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void msi_Users_Click(object sender, EventArgs e)
        {
            frmManageUsers Form = new frmManageUsers();
            Form.ShowDialog();
        }
    }
}
