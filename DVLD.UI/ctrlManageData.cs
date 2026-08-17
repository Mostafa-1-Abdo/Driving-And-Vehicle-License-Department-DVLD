using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UI
{
    public partial class ctrlManageData : UserControl
    {
        public Image pb_TitleImage
        {
            set
            {
                pb_title.Image = value;
            }
        }
        public string lb_TitleText
        {
            set
            {
                lb_Title.Text = value;
            }
        }
        public object dgv_RecordsDataSource
        {
            set
            {
                dgv_Records.DataSource = value;
            }
        }
        public DataGridView dgv_Records
        {
            get
            {
                return dgv;
            }
            set
            {
                dgv = value;
            }
        }
        public Image btn_AddImage
        {
            set
            {
                btn_Add.Image = value;
            }
        }
        public string lb_NumberOfRecordsText
        {
            set
            {
                lb_NumberOfRecords.Text = value;
            }
        }

        public ctrlManageData()
        {
            InitializeComponent();
        }
    
    }
}
