using System;
using System.Windows.Forms;
using DVLD.UI.Properties;
using DVLD.UI.People;
using System.Data;
using DVLD.Logic;

namespace DVLD.UI
{
    public partial class frmManagePeople : Form
    {
        private DataTable _PeopleTable;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _ResetForm()
        {
            _PeopleTable = clPerson.GetAllPeople();
            ctrlManageData1.RefreshRecords(_PeopleTable.DefaultView);

            ctrlManageData1.dgv_RecordsColumns["Date Of Birth"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void _Initialize_cms_dgv()
        {
            ctrlManageData1.cms_dgvItems.Add("Show Details", Resources.ShowDetails, ShowDetails_Click);
            ctrlManageData1.cms_dgvItems.Add("-");
            ctrlManageData1.cms_dgvItems.Add("Edit", Resources.Edit, EditPerson_Click);
            ctrlManageData1.cms_dgvItems.Add("Delete", Resources.Delete, DeletePerson_Click);
            ctrlManageData1.cms_dgvItems.Add("-");
            ctrlManageData1.cms_dgvItems.Add("Send Email", Resources.SendEmail, FeatureNotImplemented_Click);
            ctrlManageData1.cms_dgvItems.Add("Phone Call", Resources.PhoneCall, FeatureNotImplemented_Click);
        }
        private void _Initialize_dgv_RecordsColumns()
        {
            ctrlManageData1.dgv_RecordsColumns["National Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ctrlManageData1.dgv_RecordsColumns["Full Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ctrlManageData1.dgv_RecordsColumns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ctrlManageData1.dgv_RecordsColumns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _ResetForm();
            _Initialize_dgv_RecordsColumns();

            _Initialize_cms_dgv();

            ctrlManageData1.cb_FilterItems.AddRange(new object[] { "ID", "National Number", "Full Name", "Gender", "Phone", "Email", "Country" });

           CancelButton = ctrlManageData1.CloseButton;
        }

        private void ctrlManageData_OnCloseClick() => Close();

        private void ctrlManageData_OnAddClick()
        {
            new frmAddEditPerson().ShowDialog();

            _ResetForm();
        }

        private void ctrlManageData_SearchTextChanged(string Filter, string Search)
        {
            Search = Search.Trim();

            if (Filter == "None" || string.IsNullOrEmpty(Search))
                _PeopleTable.DefaultView.RowFilter = string.Empty;

            else if (Filter == "ID")
                _PeopleTable.DefaultView.RowFilter = int.TryParse(Search, out int ID) ? $"ID = {ID}" : $"ID = {-1}";

            else if (Filter == "Gender")
                _PeopleTable.DefaultView.RowFilter = $"Gender like '{Search}%'";

            else
                _PeopleTable.DefaultView.RowFilter = $"[{Filter}] like '%{Search}%'";

            ctrlManageData1.RefreshNumberOfRecords();
        }

        //Context Menu Strip Items Events
        private void ShowDetails_Click(object sender, EventArgs e)
        {
            new frmShowPersonDetails((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value).ShowDialog(this);

            _ResetForm();
        }
        private void EditPerson_Click(object sender, EventArgs e)
        {
            new frmAddEditPerson((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value).ShowDialog(this);

            _ResetForm();
        }
        private void DeletePerson_Click(object sender, EventArgs e)
        {
            int ID = (int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value;

            if (MessageBox.Show($"Are you sure you want to delete Person {ID}?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clPerson.Delete(ID))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _ResetForm();
                }
                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FeatureNotImplemented_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}