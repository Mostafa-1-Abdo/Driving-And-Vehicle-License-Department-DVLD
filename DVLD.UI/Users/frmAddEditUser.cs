using DVLD.Logic;
using DVLD.UI.Util;
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
    public partial class frmAddEditUser : Form
    {
        enum enMode : byte { AddNew, Edit }

        private clUser _User;
        private int _ID;
        private enMode _Mode;

        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public frmAddEditUser(int ID)
        {
            InitializeComponent();

            _Mode = enMode.Edit;
            _ID = ID;
        }

        private void _FillFormWithUserInfo()
        {
            if (!ctrlPersonCardWithFilter1.LoadPersonInfo(_User.Person))
            {
                Close();
                return;
            }

            lb_ID.Text = _User.ID.ToString();
            tb_Username.Text = _User.Username;
            tb_Password.Text = tb_ConfirmPassword.Text = _User.Password;
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
                    MessageBox.Show($"No user with ID = {_ID} was found in the system.", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                    return;
                }

                _EditModeSettings();

                _FillFormWithUserInfo();
            }
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _DesignForm();
        }

        private void ctrlPersonCardWithFilter1_OnSelectedPerson(int ID)
        {
            btn_Next.Enabled = ID != -1 ? true : false;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
           tabControl1.SelectedTab = tp_LoginInformation;

            if(tabControl1.SelectedTab == tp_PersonalInformation)
                ctrlPersonCardWithFilter1.SearchSelect();

        }
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_PersonalInformation;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tp_LoginInformation)
            {
                if (ctrlPersonCardWithFilter1.SelectedPerson == null)
                {
                    MessageBox.Show("Please select or add a person first before proceeding to Login Information.", "Select Person Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;

                }

                else if (_Mode == enMode.AddNew && clUser.IsExistForPersonID(ctrlPersonCardWithFilter1.SelectedPerson.ID))
                {
                    MessageBox.Show("Selected person already has an associated user account. Please choose another person.", "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                if (e.Cancel)
                {
                    btn_Save.Enabled = false;
                    AcceptButton = null;
                }

                else
                {
                    btn_Save.Enabled = true;
                    AcceptButton = btn_Save;
                }
            }

            else if (e.TabPage == tp_PersonalInformation)
            {
                btn_Save.Enabled = false;
                AcceptButton = null;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.IsValid(errorProvider1))
            {
                MessageBox.Show("Some fields are not valid. Please check red error icons.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
                _User.Person = ctrlPersonCardWithFilter1.SelectedPerson;

            _User.Username = tb_Username.Text;
            _User.Password = tb_Password.Text;
            _User.IsActive = ckb_IsActive.Checked;

            if (_User.Save())
            {
                lb_ID.Text = _User.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _EditModeSettings();

                _Mode = enMode.Edit;
            }
            else
                MessageBox.Show("Error: Data was not saved successfully.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tb_Username_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Username.Text))
                errorProvider1.SetError(tb_Username, "Username is required.");

            else if (_Mode == enMode.AddNew && clUser.IsExist(tb_Username.Text.Trim()))
                errorProvider1.SetError(tb_Username, "Username is already used by another person.");

            else
                errorProvider1.SetError(tb_Username, null);
        }
        private void tb_Password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Password.Text))
                errorProvider1.SetError(tb_Password, "Password is required.");

            else if (tb_Password.Text.Length < 6)
                errorProvider1.SetError(tb_Password, "Password should be at least 6 characters.");

            else
                errorProvider1.SetError(tb_Password, null);
        }
        private void tb_ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ConfirmPassword.Text))
                errorProvider1.SetError(tb_ConfirmPassword, "Confrim password is required.");

            else if (tb_ConfirmPassword.Text != tb_Password.Text)
                errorProvider1.SetError(tb_ConfirmPassword, "Password confirmation does not match the password.");

            else
                errorProvider1.SetError(tb_ConfirmPassword, null);
        }
    }
}
