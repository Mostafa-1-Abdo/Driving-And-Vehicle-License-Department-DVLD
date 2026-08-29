using DVLD.Logic;
using DVLD.UI.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using static DVLD.UI.ctrlManageData;

namespace DVLD.UI.Users
{
    public partial class frmManageUsers : Form
    {
        private DataTable _UsersTable;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _ResetForm()
        {
            _UsersTable = clUser.GetAllUsers();
            ctrlManageData1.RefreshRecords(_UsersTable.DefaultView);
        }
        private void _Initialize_cms_dgv()
        {
            ctrlManageData1.cms_dgvItems.Add("Show Details", Resources.ShowDetails, ShowDetails_Click);
            ctrlManageData1.cms_dgvItems.Add("-");
            ctrlManageData1.cms_dgvItems.Add("Edit", Resources.Edit, EditUser_Click);
            ctrlManageData1.cms_dgvItems.Add("Delete", Resources.Delete, DeleteUser_Click);
            ctrlManageData1.cms_dgvItems.Add("Change Password", Resources.ChangePassword, ChangePassword_Click);
            ctrlManageData1.cms_dgvItems.Add("-");
            ctrlManageData1.cms_dgvItems.Add("Send Email", Resources.SendEmail, FeatureNotImplemented_Click);
            ctrlManageData1.cms_dgvItems.Add("Phone Call", Resources.PhoneCall, FeatureNotImplemented_Click);
        }
        private void _Initialize_dgv_RecordsColumns()
        {
            ctrlManageData1.dgv_RecordsColumns["Full Name"].AutoSizeMode = ctrlManageData1.dgv_RecordsColumns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _ResetForm();
            _Initialize_dgv_RecordsColumns();

            _Initialize_cms_dgv();

            ctrlManageData1.cb_FilterItems.AddRange(new object[] { "User ID", "Person ID", "Full Name", "Username", "Is Active" });

            CancelButton = ctrlManageData1.CloseButton;
        }

        private void ctrlManageData_OnAddClick()
        {
            new frmAddEditUser().ShowDialog();

            _ResetForm();
        }

        private void ctrlManageData_OnFilterChanged(string Filter)
        {
            if (Filter == "Is Active")
                ctrlManageData1.SetCustomeFilter(new clFilterOption[]
                {
                  new clFilterOption("All",null),
                  new clFilterOption("Inactive",0),
                  new clFilterOption("Active",1)
                });

            else
                ctrlManageData1.SetTextFilter();
        }

        //Context Menu Strip Items Events
        private void ShowDetails_Click(object sender, EventArgs e)
        {
            new frmShowUserDetails((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value).ShowDialog(this);

            _ResetForm();
        }
        private void EditUser_Click(object sender, EventArgs e)
        {
            new frmAddEditUser((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value).ShowDialog(this);

            _ResetForm();
        }
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            int ID = (int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value;

            if (MessageBox.Show($"Are you sure you want to delete User {ID}?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clUser.Delete(ID))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _ResetForm();
                }
                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            new frmChangePassword((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value).ShowDialog(this);
        }

        private void FeatureNotImplemented_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}