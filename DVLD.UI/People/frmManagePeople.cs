using DVLD.Data;
using System;
using System.Runtime.Versioning;
using System.Windows.Forms;
using DVLD.UI.Properties;
using DVLD.UI.People;
using System.Data;
using System.Diagnostics;

namespace DVLD.UI
{
    public partial class frmManagePeople : Form
    {
        private DataTable PeopleTable = null;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _Initialize_cms_dgv()
        {
            ctrlManageData.cms_dgvItems.Add("Show Details", Resources.CurrentUserInfo, ShowDetails_Click);
            ctrlManageData.cms_dgvItems.Add("-");
            ctrlManageData.cms_dgvItems.Add("Edit", Resources.Edit, EditPerson_Click);
            ctrlManageData.cms_dgvItems.Add("Delete", Resources.Delete, DeletePerson_Click);
            ctrlManageData.cms_dgvItems.Add("-");
            ctrlManageData.cms_dgvItems.Add("Send Email", Resources.SendEmail, SendEmail_Click);
            ctrlManageData.cms_dgvItems.Add("Phone Call", Resources.PhoneCall, PhoneCall_Click);
        }
        private void _Initialize_cb_Filter()
        {
            ctrlManageData.cb_FilterItems.Add("ID");
            ctrlManageData.cb_FilterItems.Add("First Name");
            ctrlManageData.cb_FilterItems.Add("Second Name");
            ctrlManageData.cb_FilterItems.Add("Third Name");
            ctrlManageData.cb_FilterItems.Add("Last Name");
            ctrlManageData.cb_FilterItems.Add("Country");
            ctrlManageData.cb_FilterItems.Add("National Number");
            ctrlManageData.cb_FilterItems.Add("Phone");
            ctrlManageData.cb_FilterItems.Add("Email");
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            PeopleTable = clPerson.GetAllPeople();
            ctrlManageData.RefreshRecords(PeopleTable.DefaultView);
            _Initialize_cms_dgv();
            _Initialize_cb_Filter();
        }

        private void ctrlManageData_OnCloseClick()
        {
            this.Close();
        }

        private void ctrlManageData_OnAddClick()
        {
            frmAddEditPerson Form = new frmAddEditPerson();
            Form.ShowDialog();

            ctrlManageData.RefreshRecords(clPerson.GetAllPeople().DefaultView);
        }

        private void ctrlManageData_SearchTextChanged(string Filter, string Search)
        {
            if (Filter == "None" || string.IsNullOrEmpty(Search))
            {
                PeopleTable.DefaultView.RowFilter = "";
            }
            else
            {
                string ColumnName = Filter.Replace(" ", "");

                if (ColumnName == "ID")
                {
                    if (int.TryParse(Search, out int ID))
                        PeopleTable.DefaultView.RowFilter = $"[ID] = {ID}";
                    else
                        PeopleTable.DefaultView.RowFilter = $"[ID] = {-1}";
                }
                else
                    PeopleTable.DefaultView.RowFilter = $"[{ColumnName}] like '%{Search}%'";
            }

            ctrlManageData.RefreshNumberOfRecords();
        }

        //Context Menu Strip Items Events
        private void ShowDetails_Click(object sender, EventArgs e)
        {
            frmShowDetails Form = new frmShowDetails();
            Form.ShowDialog();
        }
        private void EditPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson Form = new frmAddEditPerson((int)ctrlManageData.dgv_CurrentRow.Cells["ID"].Value);
            Form.ShowDialog();

            ctrlManageData.RefreshRecords(clPerson.GetAllPeople().DefaultView);
        }
        private void DeletePerson_Click(object sender, EventArgs e)
        {
            clPerson.Delete((int)ctrlManageData.dgv_CurrentRow.Cells["ID"].Value);

            ctrlManageData.RefreshRecords(clPerson.GetAllPeople().DefaultView);
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
