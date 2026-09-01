using System;
using System.Windows.Forms;
using DVLD.UI.Properties;
using System.Data;
using DVLD.Logic;

namespace DVLD.UI
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable _TestTypesTable;

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _ResetForm()
        {
            _TestTypesTable = clTestType.GetAllTestTypes();
            ctrlManageData1.RefreshRecords(_TestTypesTable.DefaultView);
        }
        private void _Initialize_cms_dgv()
        {
            ctrlManageData1.cms_dgvItems.Add("Edit", Resources.EditTest, EditTestType_Click);
        }
        private void _Initialize_dgv_RecordsColumns()
        {
            ctrlManageData1.dgv_RecordsColumns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ctrlManageData1.dgv_RecordsColumns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ctrlManageData1.dgv_RecordsColumns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ctrlManageData1.dgv_RecordsAutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            ctrlManageData1.RemoveFilterAndAddButton();

            _ResetForm();
            _Initialize_dgv_RecordsColumns();

            _Initialize_cms_dgv();

            CancelButton = ctrlManageData1.CloseButton;
        }

        //Context Menu Strip Items Events
        private void EditTestType_Click(object sender, EventArgs e)
        {
           // new frmAddEditTestType((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value).ShowDialog(this);

            _ResetForm();
        }
    }
}