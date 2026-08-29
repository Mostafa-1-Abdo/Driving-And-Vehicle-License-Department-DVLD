using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.UI
{
    public partial class ctrlManageData : UserControl
    {
        public Image pb_HeaderImage { get => pb_Header.Image; set => pb_Header.Image = value; }

        public string lb_TitleText { get => lb_Title.Text; set => lb_Title.Text = value; }

        public ComboBox.ObjectCollection cb_FilterItems { get => cb_Filter.Items; }

        public Image btn_AddImage { get => btn_Add.Image; set => btn_Add.Image = value; }

        public DataGridViewColumnCollection dgv_RecordsColumns { get => dgv_Records.Columns; }
        public DataGridViewRow dgv_RecordsCurrentRow { get => dgv_Records.CurrentRow; }

        public ToolStripItemCollection cms_dgvItems { get => ContectMenuStrip.Items; }

        public IButtonControl CloseButton { get => btn_Close; }

        private DataView _View;

        public ctrlManageData()
        {
            InitializeComponent();
        }

        public void RefreshRecords(DataView View)
        {
            dgv_Records.DataSource = _View = View;
            RefreshNumberOfRecords();

            cb_Filter.Text = "None";
        }
        public void RefreshNumberOfRecords() => lb_NumberOfRecords.Text = dgv_Records.Rows.Count.ToString();
        
        private void btn_Close_Click(object sender, EventArgs e) => ParentForm.Close();

        public event Action AddClicked;
        private void btn_Add_Click(object sender, EventArgs e) => AddClicked?.Invoke();

        //Filter
        public class clFilterOption
        {
            public string DisplayText { get; set; }
            public object ActualValue { get; set; }

            public clFilterOption(string option, object value)
            {
                DisplayText = option;
                ActualValue = value;
            }

            public override string ToString() => DisplayText;
        }
        public void SetCustomeFilter(clFilterOption[] Options)
        {
            cb_Search.DataSource = null;
            cb_Search.DisplayMember = "DisplayText";
            cb_Search.ValueMember = "ActualValue";
            cb_Search.DataSource = Options;
            cb_Search.SelectedIndex = 0;

            tb_Search.Visible = false;
            cb_Search.Visible = true;
        }
        public void SetTextFilter()
        {
            tb_Search.Clear();

            cb_Search.Visible = false;
            tb_Search.Visible = true;
        }

        public event Action<string> OnFilterChanged;
        private void cb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Filter.Text == "None")
            {
                tb_Search.Visible = false;
                cb_Search.Visible = false;

                if (_View != null)
                {
                    _View.RowFilter = string.Empty;
                    RefreshNumberOfRecords();
                }

                return;
            }

            OnFilterChanged?.Invoke(cb_Filter.Text);
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Search.Text.Trim()))
            {
                _View.RowFilter = string.Empty;
                RefreshNumberOfRecords();

                return;
            }

            Type ColumnType = _View.Table.Columns[cb_Filter.Text].DataType;

            if (ColumnType == typeof(byte) || ColumnType == typeof(short) || ColumnType == typeof(int) ||
            ColumnType == typeof(long) || ColumnType == typeof(float) | ColumnType == typeof(double) ||
            ColumnType == typeof(decimal))
                _View.RowFilter = int.TryParse(tb_Search.Text, out int Number) ? $"[{cb_Filter.Text}] = {Number}" : $"[{cb_Filter.Text}] = {-1}";

            else
                _View.RowFilter = $"[{cb_Filter.Text}] like '%{tb_Search.Text}%'";

            RefreshNumberOfRecords();
        }
        private void cb_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Search.SelectedValue == null)
            {
                _View.RowFilter = string.Empty;
                RefreshNumberOfRecords();
                return;
            }

            if (cb_Search.SelectedValue is string)
                _View.RowFilter = $"[{cb_Filter.Text}] = '{cb_Search.SelectedValue}'";

            else
                _View.RowFilter = $"[{cb_Filter.Text}] = {cb_Search.SelectedValue}";

            RefreshNumberOfRecords();
        }

        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_View.Table.Columns.Contains(cb_Filter.Text))
                return;

            Type ColumnType = _View.Table.Columns[cb_Filter.Text].DataType;
            if (ColumnType == typeof(byte) || ColumnType == typeof(short) || ColumnType == typeof(int) ||
                ColumnType == typeof(long) || ColumnType == typeof(float) | ColumnType == typeof(double) ||
                ColumnType == typeof(decimal))
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}