using DVLD.Logic;
using DVLD.UI.Util;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.UI.TestTypes
{
    public partial class frmEditTestType : Form
    {
        private clTestType _TestType;
        private clTestType.enTestType _ID;

        public frmEditTestType(int id)
        {
            InitializeComponent();

            _ID = (clTestType.enTestType)id;
        }

        private void _FillFormWithTestTypeInfo()
        {
            lb_ID.Text = ((byte)_TestType.ID).ToString();
            tb_Title.Text = _TestType.Title;
            tb_Description.Text = _TestType.Description;
            tb_Fees.Text = _TestType.Fees.ToString("0.00");
        }
        private void _DesignForm()
        {
            _TestType = clTestType.Find(_ID);
            if (_TestType == null)
            {
                clUIMessages.ShowNotFound("Test Type", (int)_ID);
                Close();
                return;
            }

            _FillFormWithTestTypeInfo();
        }
        private void frmEditTestType_Load(object sender, EventArgs e) => _DesignForm();

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.IsValid(errorProvider1))
            {
                clUIMessages.ShowValidationError();
                return;
            }

            _TestType.Title = tb_Title.Text.Trim();
            _TestType.Description = tb_Description.Text.Trim();
            _TestType.Fees = Convert.ToDecimal(tb_Fees.Text.Trim());

            if (_TestType.Save())
            {
                clUIMessages.ShowSaveSuccess();
            }
            else
            {
                clUIMessages.ShowSaveError();
            }
        }
        private void btn_Close_Click(object sender, EventArgs e) => Close();

        private void tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, $"{textBox.Tag?.ToString() ?? "This field"} is required.");
            }
            else
            {
                errorProvider1.SetError(textBox, null);
            }
        }
        private void tb_Fees_Validating(object sender, CancelEventArgs e)
        {
            string fees = tb_Fees.Text.Trim();

            if (string.IsNullOrEmpty(fees))
            {
                errorProvider1.SetError(tb_Fees, "Fees is required.");
            }
            else if (!clUtil.IsValidMoney(fees))
            {
                errorProvider1.SetError(tb_Fees, "Invalid fees format! (e.g. 15 or 15.50).");
            }
            else
            {
                errorProvider1.SetError(tb_Fees, null);
            }
        }

        private void tb_Fees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && (!tb_Fees.Text.Contains(".") || tb_Fees.SelectedText.Contains(".")))
            {
                e.Handled = false;
                return;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void tb_Fees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Save.PerformClick();
            }
        }
    }
}