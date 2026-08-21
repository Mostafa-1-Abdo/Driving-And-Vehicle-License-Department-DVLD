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

        private void _LoadUserInfo()
        {

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
                Text = lb_Title.Text = "Update User";

                _User = clUser.Find(_ID);

                if (_User == null)
                {
                    MessageBox.Show($"No Person with ID = {_ID} was found in the system.", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                    return;
                }

                _LoadUserInfo();

                
            }
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_Username_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Username.Text))
                errorProvider1.SetError(tb_Username, "Username is required.");

            else if (clUser.IsExist(tb_Username.Text))
                errorProvider1.SetError(tb_Username, "Username is already used by another person.");

            else
                errorProvider1.SetError(tb_Username, null);
        }
        private void tb_Password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Password.Text))
                errorProvider1.SetError(tb_Password, "Password is required.");

            else if(tb_Password.Text.Length < 6)
                errorProvider1.SetError(tb_Password, "Password should be at least 6 characters.");

            else
                errorProvider1.SetError(tb_Password, null);
        }
        private void tb_ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tb_ConfirmPassword.Text))
                errorProvider1.SetError(tb_ConfirmPassword, "Confrim password is required.");

            else if (tb_Password.Text != tb_Password.Text)
                errorProvider1.SetError(tb_ConfirmPassword, "");

            else
                errorProvider1.SetError(tb_ConfirmPassword, null);
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_LoginInformation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_PersonalInformation;
        }
    }
}
