using DVLD.Logic;
using DVLD.UI.UserControls;
using DVLD.UI.Util;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.UI.Users
{
    public partial class frmAddEditUser : Form
    {
        private enum enMode : byte { AddNew, Edit }

        private User _user;
        private int _id;
        private enMode _mode;

        public frmAddEditUser()
        {
            InitializeComponent();

            _mode = enMode.AddNew;
        }

        public frmAddEditUser(int id)
        {
            InitializeComponent();

            _mode = enMode.Edit;
            _id = id;
        }

        private void _FillFormWithUserInfo()
        {
            if (!ctrlPersonCardWithFilter1.LoadPersonInfo(_user.Person))
            {
                UIMessages.ShowNotFound("User", _id);
                Close();
                return;
            }

            lb_ID.Text = _user.ID.ToString();
            tb_Username.Text = _user.Username;
            tb_Password.Text = tb_ConfirmPassword.Text = _user.Password;
            ckb_IsActive.Checked = _user.IsActive;
        }
        private void _EditModeSettings()
        {
            Text = lb_Title.Text = "Edit User";

            ctrlPersonCardWithFilter1.gb_FilterEnabled = false;
            btn_Next.Enabled = true;

            tb_Username.Enabled = false;
            tb_Password.Enabled = false;
            tb_ConfirmPassword.Enabled = false;
        }
        private void _DesignForm()
        {
            if (_mode == enMode.AddNew)
            {
                Text = lb_Title.Text = "Add New User";
                _user = new User();

                ctrlPersonCardWithFilter1.SearchSelect();
            }
            else
            {
                _user = User.Find(_id);
                if (_user == null)
                {
                    UIMessages.ShowNotFound("User", _id);
                    Close();
                    return;
                }

                _EditModeSettings();
                _FillFormWithUserInfo();
            }
        }
        private void frmAddEditUser_Load(object sender, EventArgs e) => _DesignForm();

        private void ctrlPersonCardWithFilter1_OnSelectedPerson(int id) => btn_Next.Enabled = (id != -1);
        private void ctrlPersonCardWithFilter1_OnSavedPerson(int id) => ctrlPersonCardWithFilter1.gb_FilterEnabled = !(btn_Next.Enabled = (id != -1));

        private void btn_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_LoginInformation;
        }
        private void btn_Previous_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tp_PersonalInformation;

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tp_LoginInformation)
            {
                if (ctrlPersonCardWithFilter1.SelectedPerson == null)
                {
                    UIMessages.ShowSelectPersonRequired();
                    e.Cancel = true;
                }
                else if (_mode == enMode.AddNew && User.IsExistForPersonID(ctrlPersonCardWithFilter1.SelectedPerson.ID))
                {
                    UIMessages.ShowDuplicateUserAccount();
                    e.Cancel = true;
                }

                if (e.Cancel)
                {
                    btn_Save.Enabled = false;
                    btn_Save.FlatAppearance.BorderSize = 1;
                    AcceptButton = null;

                    ctrlPersonCardWithFilter1.SearchSelect();
                }
                else
                {
                    btn_Save.Enabled = true;
                    btn_Save.FlatAppearance.BorderSize = 0;
                    AcceptButton = btn_Save;
                }
            }
            else if (e.TabPage == tp_PersonalInformation)
            {
                btn_Save.Enabled = false;
                AcceptButton = null;
            }
        }

        private void tb_Username_Validating(object sender, CancelEventArgs e)
        {
            if (_mode == enMode.Edit) return;

            string username = tb_Username.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                errorProvider1.SetError(tb_Username, "Username is required.");
            }
            else if (User.IsExist(username))
            {
                errorProvider1.SetError(tb_Username, "Username is already used by another person.");
            }
            else
            {
                errorProvider1.SetError(tb_Username, null);
            }
        }
        private void tb_Password_Validating(object sender, CancelEventArgs e)
        {
            if (_mode == enMode.Edit) return;

            string password = tb_Password.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                errorProvider1.SetError(tb_Password, "Password is required.");
            }
            else if (password.Length < 6)
            {
                errorProvider1.SetError(tb_Password, "Password should be at least 6 characters.");
            }
            else
            {
                errorProvider1.SetError(tb_Password, null);
            }
        }
        private void tb_ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_mode == enMode.Edit) return;

            string confrimPassword = tb_ConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(confrimPassword))
            {
                errorProvider1.SetError(tb_ConfirmPassword, "Confirm password is required.");
            }
            else if (confrimPassword != tb_Password.Text)
            {
                errorProvider1.SetError(tb_ConfirmPassword, "Password confirmation does not match the password.");
            }
            else
            {
                errorProvider1.SetError(tb_ConfirmPassword, null);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (_mode == enMode.AddNew && ctrlPersonCardWithFilter1.SelectedPersonID == -1)
            {
                UIMessages.ShowSelectPersonRequired();
                return;
            }

            if (!this.IsValid(errorProvider1))
            {
                UIMessages.ShowValidationError();
                return;
            }

            if (_mode == enMode.AddNew)
            {
                _user.PersonID = ctrlPersonCardWithFilter1.SelectedPersonID;

                _user.Username = tb_Username.Text.Trim();
                _user.Password = tb_Password.Text;
            }

            _user.IsActive = ckb_IsActive.Checked;

            if (_user.Save())
            {
                lb_ID.Text = _user.ID.ToString();
                UIMessages.ShowSaveSuccess();

                _EditModeSettings();
                _mode = enMode.Edit;
            }
            else
            {
                UIMessages.ShowSaveError();
            }
        }
        private void btn_Close_Click(object sender, EventArgs e) => Close();
    }
}