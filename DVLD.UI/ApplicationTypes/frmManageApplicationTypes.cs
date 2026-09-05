using DVLD.Logic;
using DVLD.UI.Properties;
using DVLD.UI.ApplicationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UI.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes() => InitializeComponent();

        private void _ResetForm() => ctrlManageData1.RefreshRecords(clApplicationType.GetAllApplicationTypes().DefaultView);

        private void _Initialize_cms_dgv() => ctrlManageData1.cms_dgvItems.Add("Edit", Resources.EditApplicationType, EditApplicationType_Click);
        private void _Initialize_dgv_RecordsColumns()
        {
            ctrlManageData1.dgv_RecordsColumns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ctrlManageData1.dgv_RecordsColumns["Fees"].DefaultCellStyle.Format = "00.00";
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            ctrlManageData1.RemoveFilterAndAddButton();

            _ResetForm();
            _Initialize_dgv_RecordsColumns();
            _Initialize_cms_dgv();

            CancelButton = ctrlManageData1.CloseButton;
        }

        // Context Menu Strip Items Events
        private void EditApplicationType_Click(object sender, EventArgs e)
        {
            if (ctrlManageData1.dgv_RecordsCurrentRow == null) return;

           //new frmEditApplicationType((int)ctrlManageData1.dgv_RecordsCurrentRow.Cells["ID"].Value).ShowDialog(this);
            _ResetForm();
        }
    }
}
