using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UI.Users
{
    public partial class frmChangePassword : Form
    {
        private int _ID;

        public frmChangePassword(int ID)
        {
            InitializeComponent();

            _ID = ID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (!ctrlUserCard1.LoadUserInfo(_ID))
                Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.IsValid(errorProvider1))
            {
                MessageBox.Show("Some fields are not valid. Please check red error icons.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlUserCard1.User.ChangePassword(tb_NewPassword.Text.Trim()))
            {
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb_CurrentPassword.Text = tb_NewPassword.Text = tb_ConfirmPassword.Text = string.Empty;
            }

            else
                MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_CurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tb_CurrentPassword.Text != ctrlUserCard1.User.Password)
                errorProvider1.SetError(tb_CurrentPassword, "Password is wrong.");

            else
                errorProvider1.SetError(tb_CurrentPassword, null);
        }
        private void tb_NewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_NewPassword.Text))
                errorProvider1.SetError(tb_NewPassword, "Password is required.");

            else if (tb_NewPassword.Text.Length < 6)
                errorProvider1.SetError(tb_NewPassword, "Password should be at least 6 characters.");

            else
                errorProvider1.SetError(tb_NewPassword, null);
        }
        private void tb_ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ConfirmPassword.Text))
                errorProvider1.SetError(tb_ConfirmPassword, "Confrim password is required.");

            else if (tb_ConfirmPassword.Text != tb_NewPassword.Text)
                errorProvider1.SetError(tb_ConfirmPassword, "Password confirmation does not match the password.");

            else
                errorProvider1.SetError(tb_ConfirmPassword, null);
        }
    }
}
