using DVLD.Logic;
using DVLD.UI.Properties;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.UI.Users
{
    public partial class frmManageUsers : Form
    {
        private DataTable UsersTable;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _Initialize_cms_dgv()
        {
            ctrlManageData1.cms_dgvItems.Add("Show Details", Resources.CurrentUserInfo, ShowDetails_Click);
            ctrlManageData1.cms_dgvItems.Add("-");
            ctrlManageData1.cms_dgvItems.Add("Edit", Resources.Edit, EditUser_Click);
            ctrlManageData1.cms_dgvItems.Add("Delete", Resources.Delete, DeleteUser_Click);
            ctrlManageData1.cms_dgvItems.Add("Change Password", Resources.Delete, ChangePassword_Click);
            ctrlManageData1.cms_dgvItems.Add("-");
            ctrlManageData1.cms_dgvItems.Add("Send Email", Resources.SendEmail, SendEmail_Click);
            ctrlManageData1.cms_dgvItems.Add("Phone Call", Resources.PhoneCall, PhoneCall_Click);
        }
        private void _Initialize_cb_Filter()
        {
            ctrlManageData1.cb_FilterItems.Add("User ID");
            ctrlManageData1.cb_FilterItems.Add("Person ID");
            ctrlManageData1.cb_FilterItems.Add("Full Name");
            ctrlManageData1.cb_FilterItems.Add("Username");
            ctrlManageData1.cb_FilterItems.Add("Is Active");
        }
        private void _Initialize_dgv_RecordsColumns()
        {
            ctrlManageData1.dgv_RecordsColumns["Full Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ctrlManageData1.dgv_RecordsColumns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            UsersTable = clUser.GetAllUsers();
            ctrlManageData1.RefreshRecords(UsersTable.DefaultView);
            _Initialize_dgv_RecordsColumns();

            _Initialize_cms_dgv();

            _Initialize_cb_Filter();
            ctrlManageData1.SetNumericColumns("Person ID", "User ID","Is Active");
        }

        private void ctrlManageData_OnCloseClick()
        {
           Close();
        }

        private void ctrlManageData_OnAddClick()
        {
            frmAddEditUser Form = new frmAddEditUser();
            Form.ShowDialog();

            ctrlManageData1.RefreshRecords(clUser.GetAllUsers().DefaultView);
        }

        private void ctrlManageData_SearchTextChanged(string Filter, string Search)
        {
            Search = Search.Trim();

            if (Filter == "None" || string.IsNullOrEmpty(Search))
            {
                UsersTable.DefaultView.RowFilter = string.Empty;
            }

            else
            {
                if (Filter == "User ID" || Filter == "Person ID" || Filter == "Is Active")
                {
                    if (int.TryParse(Search, out int Value))
                        UsersTable.DefaultView.RowFilter = $"[{Filter}] = {Value}";
                    else
                        UsersTable.DefaultView.RowFilter = $"[{Filter}] = {Value}";
                }

                else
                    UsersTable.DefaultView.RowFilter = $"[{Filter}] like '%{Search}%'";
            }

            ctrlManageData1.RefreshNumberOfRecords();
        }

        //Context Menu Strip Items Events
        private void ShowDetails_Click(object sender, EventArgs e)
        {
            frmShowUserDetails Form = new frmShowUserDetails((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value);
            Form.ShowDialog();

            ctrlManageData1.RefreshRecords(clUser.GetAllUsers().DefaultView);
        }
        private void EditUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser Form = new frmAddEditUser((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value);
            Form.ShowDialog();

            ctrlManageData1.RefreshRecords(clUser.GetAllUsers().DefaultView);
        }
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            int ID = (int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value;

            if (MessageBox.Show($"Are you sure you want to delete User {ID}?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clUser.Delete(ID))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ctrlManageData1.RefreshRecords(clUser.GetAllUsers().DefaultView);
                }
                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword Form = new frmChangePassword((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value);
            Form.ShowDialog();
        }

        private void SendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void PhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
