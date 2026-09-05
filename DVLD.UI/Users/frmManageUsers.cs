using DVLD.Logic;
using DVLD.UI.Properties;
using DVLD.UI.Util;
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
        private void _Initialize_dgv_RecordsColumns()
        {
            ctrlManageData1.dgv_RecordsColumns["Full Name"].AutoSizeMode =
                ctrlManageData1.dgv_RecordsColumns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _ResetForm();
            _Initialize_dgv_RecordsColumns();
            _Initialize_cms_dgv();

            ctrlManageData1.cb_FilterItems.AddRange(new object[] { "User ID", "Person ID", "Full Name", "Username", "Is Active" });

            CancelButton = ctrlManageData1.CloseButton;
        }

        private void ctrlManageData_OnFilterChanged(string filter)
        {
            if (filter == "Is Active")
            {
                ctrlManageData1.SetCustomeFilter(new clFilterOption[]
                {
                    new clFilterOption("All", null),
                    new clFilterOption("Inactive", 0),
                    new clFilterOption("Active", 1)
                });
            }
            else
            {
                ctrlManageData1.SetTextFilter();
            }
        }

        private void ctrlManageData_OnAddClick()
        {
            new frmAddEditUser().ShowDialog(this);
            _ResetForm();
        }

        // Context Menu Strip Items Events
        private void ShowDetails_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

            new frmShowUserDetails((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value).ShowDialog(this);
            _ResetForm();
        }
        private void EditUser_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

            new frmAddEditUser((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value).ShowDialog(this);
            _ResetForm();
        }
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

            int id = (int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value;

            if (id == clGlobalUser.GlobalUser.ID)
            {
                clUIMessages.ShowCannotDeleteCurrentUser();
                return;
            }

            if (clUIMessages.ShowConfirmDelete("User", id))
            {
                if (clUser.Delete(id))
                {
                    clUIMessages.ShowDeleteSuccess("User");
                    _ResetForm();
                }
                else
                {
                    clUIMessages.ShowDeleteFailedLinkedData("User");
                }
            }
        }
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

            new frmChangePassword((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["User ID"].Value).ShowDialog(this);
        }
        private void FeatureNotImplemented_Click(object sender, EventArgs e) => clUIMessages.ShowFeatureNotImplemented();
    }
}