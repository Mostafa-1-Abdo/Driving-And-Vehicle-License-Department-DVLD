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

        private clUser _User;
        private int _ID;
        private enMode _Mode;

        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int id)
        {
            InitializeComponent();

            _Mode = enMode.Edit;
            _ID = id;
        }

        private void _FillFormWithUserInfo()
        {
            if (!ctrlPersonCardWithFilter1.LoadPersonInfo(_User.Person))
            {
                clUIMessages.ShowNotFound("User", _ID);
                Close();
                return;
            }

            lb_ID.Text = _User.ID.ToString();
            tb_Username.Text = _User.Username;
            tb_Password.Text = tb_ConfirmPassword.Text = _User.Password;
            ckb_IsActive.Checked = _User.IsActive;
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
            if (_Mode == enMode.AddNew)
            {
                Text = lb_Title.Text = "Add New User";
                _User = new clUser();
            }
            else
            {
                _User = clUser.Find(_ID);
                if (_User == null)
                {
                    clUIMessages.ShowNotFound("User", _ID);
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

            if (tabControl1.SelectedTab == tp_PersonalInformation)
            {
                ctrlPersonCardWithFilter1.SearchSelect();
            }
        }
        private void btn_Previous_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tp_PersonalInformation;

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tp_LoginInformation)
            {
                if (ctrlPersonCardWithFilter1.SelectedPerson == null)
                {
                    clUIMessages.ShowSelectPersonRequired();
                    e.Cancel = true;
                }
                else if (_Mode == enMode.AddNew && clUser.IsExistForPersonID(ctrlPersonCardWithFilter1.SelectedPerson.ID))
                {
                    clUIMessages.ShowDuplicateUserAccount();
                    e.Cancel = true;
                }

                if (e.Cancel)
                {
                    btn_Save.Enabled = false;
                    btn_Save.FlatAppearance.BorderSize = 1;
                    AcceptButton = null;
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
            if (_Mode == enMode.Edit) return;

            string username = tb_Username.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                errorProvider1.SetError(tb_Username, "Username is required.");
            }
            else if (clUser.IsExist(username))
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
            if (_Mode == enMode.Edit) return;

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
            if (_Mode == enMode.Edit) return;

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
            if (!this.IsValid(errorProvider1))
            {
                clUIMessages.ShowValidationError();
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                _User.Person = ctrlPersonCardWithFilter1.SelectedPerson;

                _User.Username = tb_Username.Text.Trim();
                _User.Password = tb_Password.Text;
            }

            _User.IsActive = ckb_IsActive.Checked;

            if (_User.Save())
            {
                lb_ID.Text = _User.ID.ToString();
                clUIMessages.ShowSaveSuccess();

                _EditModeSettings();
                _Mode = enMode.Edit;
            }
            else
            {
                clUIMessages.ShowSaveError();
            }
        }
        private void btn_Close_Click(object sender, EventArgs e) => Close();
    }
}