using DVLD.Logic;
using DVLD.UI.People;
using DVLD.UI.Properties;
using DVLD.UI.Util;
using System;
using System.Data;
using System.Windows.Forms;
using static DVLD.UI.ctrlManageData;

namespace DVLD.UI
{
    public partial class frmManagePeople : Form
    {
        private DataTable _PeopleTable;

        public frmManagePeople() => InitializeComponent();

        private void _ResetForm()
        {
            _PeopleTable = clPerson.GetAllPeople();
            ctrlManageData1.RefreshRecords(_PeopleTable.DefaultView);
        }
        private void _Initialize_dgv_RecordsColumns()
        {
            ctrlManageData1.dgv_RecordsColumns["National Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ctrlManageData1.dgv_RecordsColumns["Full Name"].AutoSizeMode =
                ctrlManageData1.dgv_RecordsColumns["Email"].AutoSizeMode =
                ctrlManageData1.dgv_RecordsColumns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _ResetForm();
            _Initialize_dgv_RecordsColumns();
            _Initialize_cms_dgv();

            ctrlManageData1.cb_FilterItems.AddRange(new object[] { "ID", "National Number", "Full Name", "Gender", "Phone", "Email", "Country" });

            CancelButton = ctrlManageData1.CloseButton;
        }

        private void ctrlManageData_OnFilterChanged(string filter)
        {
            if (filter == "Gender")
            {
                ctrlManageData1.SetCustomeFilter(new clFilterOption[]
                {
                    new clFilterOption("All", null),
                    new clFilterOption("Male", "Male"),
                    new clFilterOption("Female", "Female")
                });
            }
            else
            {
                ctrlManageData1.SetTextFilter();
            }
        }

        private void ctrlManageData_OnAddClick()
        {
            new frmAddEditPerson().ShowDialog(this);
            _ResetForm();
        }

        // Context Menu Strip Items Events
        private void ShowDetails_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

            new frmShowPersonDetails((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value).ShowDialog(this);
            _ResetForm();
        }
        private void EditPerson_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

            new frmAddEditPerson((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value).ShowDialog(this);
            _ResetForm();
        }
        private void DeletePerson_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

            int id = (int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value;
            if (clUIMessages.ShowConfirmDelete("Person", id))
            {
                clPerson person = clPerson.Find(id);
                string imagePath = person?.ImagePath;

                if (clPerson.Delete(id))
                {
                    clUIMessages.ShowDeleteSuccess("Person");

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        clFileHandler.HandleFileDelete(imagePath);
                    }

                    _ResetForm();
                }
                else
                {
                    clUIMessages.ShowDeleteFailedLinkedData("Person");
                }
            }
        }
        private void FeatureNotImplemented_Click(object sender, EventArgs e) => clUIMessages.ShowFeatureNotImplemented();
    }
}