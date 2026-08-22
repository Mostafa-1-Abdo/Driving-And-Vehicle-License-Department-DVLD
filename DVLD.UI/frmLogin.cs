using DVLD.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            var (Result, User) = clUser.Login(tb_UserName.Text.Trim(), tb_Password.Text.Trim());

            if (Result == clUser.enLoginResults.UserNotFound || Result == clUser.enLoginResults.InvalidPassword)
                MessageBox.Show("Invalid username or password. Please verify your credentials and try again.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (Result == clUser.enLoginResults.UserNotActive)
                MessageBox.Show("Your account is currently inactive. Please contact your system administrator.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                DialogResult = DialogResult.OK;
                clGlobalUser.GlobalUser = User;

                Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
