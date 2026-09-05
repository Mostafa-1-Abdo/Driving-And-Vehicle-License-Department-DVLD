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

        public ComboBox.ObjectCollection cb_FilterItems => cb_Filter.Items;

        public Image btn_AddImage { get => btn_Add.Image; set => btn_Add.Image = value; }

        public DataGridViewColumnCollection dgv_RecordsColumns => dgv_Records.Columns;
        public DataGridViewRow dgv_RecordsCurrentRow => dgv_Records.CurrentRow;

        public ToolStripItemCollection cms_dgvItems => ContextMenuStrip.Items;

        public IButtonControl CloseButton => btn_Close;

        public DataGridViewAutoSizeRowsMode dgv_RecordsAutoSizeRowsMode { get => dgv_Records.AutoSizeRowsMode; set => dgv_Records.AutoSizeRowsMode = value; }

        public void RemoveFilterAndAddButton()
        {
            lb_FilterBy.Visible = false;
            cb_Filter.Visible = false;
            btn_Add.Visible = false;

            dgv_Records.Top = cb_Filter.Top;
        }

        private DataView _View;

        public ctrlManageData() => InitializeComponent();
        
        public void RefreshRecords(DataView view)
        {
            _View = view;
            dgv_Records.DataSource = _View;
            RefreshNumberOfRecords();

            cb_Filter.Text = "None";
        }

        public void RefreshNumberOfRecords() => lb_NumberOfRecords.Text = dgv_Records.Rows.Count.ToString();

        private void btn_Close_Click(object sender, EventArgs e) => ParentForm?.Close();

        public event Action AddClicked;
        private void btn_Add_Click(object sender, EventArgs e) => AddClicked?.Invoke();

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
        public void SetCustomeFilter(clFilterOption[] options)
        {
            cb_Search.DataSource = null;
            cb_Search.DisplayMember = "DisplayText";
            cb_Search.ValueMember = "ActualValue";
            cb_Search.DataSource = options;
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
            if (_View == null || _View.Table == null) return;

            string filterColumn = cb_Filter.Text.Trim();
            string searchValue = tb_Search.Text.Trim();

            if (string.IsNullOrEmpty(searchValue) || !_View.Table.Columns.Contains(filterColumn))
            {
                _View.RowFilter = string.Empty;
                RefreshNumberOfRecords();
                return;
            }

            Type columnType = _View.Table.Columns[filterColumn].DataType;

            if (columnType == typeof(byte) || columnType == typeof(short) || columnType == typeof(int) ||
                columnType == typeof(long))
            {
                _View.RowFilter = long.TryParse(searchValue, out long number)
                    ? $"[{filterColumn}] = {number}"
                    : $"[{filterColumn}] = -1";
            }
            else
            {
                string safeSearchValue = searchValue.Replace("'", "''");
                _View.RowFilter = $"[{filterColumn}] LIKE '%{safeSearchValue}%'";
            }

            RefreshNumberOfRecords();
        }
        private void cb_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_View == null || _View.Table == null) return;

            string filterColumn = cb_Filter.Text.Trim();

            if (cb_Search.SelectedValue == null || !_View.Table.Columns.Contains(filterColumn))
            {
                _View.RowFilter = null;
                RefreshNumberOfRecords();
                return;
            }

            if (cb_Search.SelectedValue is string stringValue)
            {
                _View.RowFilter = $"[{filterColumn}] = '{stringValue.Replace("'", "''")}'";
            }
            else
            {
                _View.RowFilter = $"[{filterColumn}] = {cb_Search.SelectedValue}";
            }

            RefreshNumberOfRecords();
        }

        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_View == null || _View.Table == null || !_View.Table.Columns.Contains(cb_Filter.Text.Trim())) return;

            Type columnType = _View.Table.Columns[cb_Filter.Text].DataType;

            if (columnType == typeof(byte) || columnType == typeof(short) || columnType == typeof(int) ||
                columnType == typeof(long))
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}