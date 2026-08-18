using DVLD.Data;
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
        public Image pb_HeaderImage
        {
            get => pb_Header.Image;
            set => pb_Header.Image = value;
        }

        public string lb_TitleText
        {
            get => lb_Title.Text;
            set => lb_Title.Text = value;
        }

        public ComboBox.ObjectCollection cb_FilterItems
        {
            get => cb_Filter.Items;
        }

        public Image btn_AddImage
        {
            get => btn_Add.Image;
            set => btn_Add.Image = value;
        }

        public object dgv_RecordsDataSource
        {
            get => dgv_Records.DataSource;
            set => dgv_Records.DataSource = value;
        }
        public DataGridViewRow CurrentRow
        {
            get => dgv_Records.CurrentRow;
        }

        public ContextMenuStrip cms_dgv
        {
            get => ContectMenuStrip;
            set => ContectMenuStrip = value;
        }

        public ctrlManageData()
        {
            InitializeComponent();
        }

        private void ctrlManageData_Load(object sender, EventArgs e)
        {
            cb_Filter.SelectedIndex = 0;
        }
       
        public void RefreshData(DataView View)
        {
            dgv_Records.DataSource = View;
            lb_NumberOfRecords.Text = dgv_Records.Rows.Count. ToString();
        }

        public event Action CloseClicked;
        private void btn_Close_Click(object sender, EventArgs e)
        {
            CloseClicked?.Invoke();
        }

        public event Action AddClicked;
        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke();
        }

        private void cb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Search.Clear();
            tb_Search.Visible = cb_Filter.SelectedIndex != 0;
        }

        public event Action<string,string> SearchTextChanged;
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            SearchTextChanged?.Invoke(cb_Filter.Text,tb_Search.Text);
        }

        public event Action MenuStripItemCliked;
        private void ContectMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MenuStripItemCliked?.Invoke();
        }
    }
}
    