using DVLD.UI.Util;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.UI.Users
{
    public partial class frmChangePassword : Form
    {
        private int _ID;

        public frmChangePassword(int id)
        {
            InitializeComponent();

            _ID = id;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (!ctrlUserCard1.LoadUserInfo(_ID))
            {
                clUIMessages.ShowNotFound("User", _ID);
                Close();
                return;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.IsValid(errorProvider1))
            {
                clUIMessages.ShowValidationError();
                return;
            }

            if (ctrlUserCard1.User.ChangePassword(tb_NewPassword.Text))
            {
                clUIMessages.ShowPasswordChangedSuccess();

                Close();
            }
            else
            {
                clUIMessages.ShowPasswordChangeFailed();
            }
        }
        private void btn_Close_Click(object sender, EventArgs e) => Close();

        private void tb_CurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tb_CurrentPassword.Text != ctrlUserCard1.User?.Password)
            {
                errorProvider1.SetError(tb_CurrentPassword, "Password is wrong.");
            }
            else
            {
                errorProvider1.SetError(tb_CurrentPassword, null);
            }
        }
        private void tb_NewPassword_Validating(object sender, CancelEventArgs e)
        {
            string newPassword = tb_NewPassword.Text;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                errorProvider1.SetError(tb_NewPassword, "Password is required.");
            }
            else if (newPassword.Length < 6)
            {
                errorProvider1.SetError(tb_NewPassword, "Password should be at least 6 characters.");
            }
            else
            {
                errorProvider1.SetError(tb_NewPassword, null);
            }
        }
        private void tb_ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            string confirmPassword = tb_ConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                errorProvider1.SetError(tb_ConfirmPassword, "Confirm password is required.");
            }
            else if (confirmPassword != tb_NewPassword.Text)
            {
                errorProvider1.SetError(tb_ConfirmPassword, "Password confirmation does not match the password.");
            }
            else
            {
                errorProvider1.SetError(tb_ConfirmPassword, null);
            }
        }
    }
}