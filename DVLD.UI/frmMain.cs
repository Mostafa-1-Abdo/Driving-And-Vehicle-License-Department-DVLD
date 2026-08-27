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
            Form.ShowDialog(this) ;
        }

        private void msi_Drivers_Click(object sender, EventArgs e)
        {

        }

        private void msi_CurrentUserInfo_Click(object sender, EventArgs e)
        {
            frmShowUserDetails Form = new frmShowUserDetails(clGlobalUser.GlobalUser.ID);
            Form.ShowDialog(this);
        }

        private void msi_ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword Form = new frmChangePassword(clGlobalUser.GlobalUser.ID);
            Form.ShowDialog(this);
        }

        private void msi_Users_Click(object sender, EventArgs e)
        {
            frmManageUsers Form = new frmManageUsers();
            Form.ShowDialog(this);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            clGlobalUser.GlobalUser = null;
        }
    }
}
