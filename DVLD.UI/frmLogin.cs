using DVLD.Logic;
using System;
using System.Windows.Forms;

namespace DVLD.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            tb_Username.Text = Properties.Settings.Default.Username;
            tb_Password.Text = Properties.Settings.Default.Password;
        }

        private void ClearLoginInfo()
        {
            Properties.Settings.Default.Username = string.Empty;
            Properties.Settings.Default.Password = string.Empty;

            Properties.Settings.Default.Save();
        }
        private void SaveLoginInfo()
        {
            Properties.Settings.Default.Username = tb_Username.Text;
            Properties.Settings.Default.Password = tb_Password.Text;

            Properties.Settings.Default.Save();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            var (Result, User) = clUser.Login(tb_Username.Text.Trim(), tb_Password.Text);

            if (Result == clUser.enLoginResults.UserNotFound || Result == clUser.enLoginResults.InvalidPassword)
                MessageBox.Show("Invalid username or password. Please verify your credentials and try again.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (Result == clUser.enLoginResults.UserNotActive)
                MessageBox.Show("Your account is currently inactive. Please contact your system administrator.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                DialogResult = DialogResult.OK;
                clGlobalUser.GlobalUser = User;

                if (ckb_RememberMe.Checked)
                    SaveLoginInfo();

                else
                    ClearLoginInfo();

                Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}