using DVLD.Logic;
using DVLD.UI.Util;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.UI.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private clApplicationType _ApplicationType;
        private clApplicationType.enApplicationType _ID;

        public frmEditApplicationType(int id)
        {
            InitializeComponent();

            _ID = (clApplicationType.enApplicationType)id;
        }

        private void _FillFormWithApplicationTypeInfo()
        {
            lb_ID.Text = ((byte)_ApplicationType.ID).ToString();
            tb_Title.Text = _ApplicationType.Title;
            tb_Fees.Text = _ApplicationType.Fees.ToString("0.00");
        }
        private void _DesignForm()
        {
            _ApplicationType = clApplicationType.Find(_ID);
            if (_ApplicationType == null)
            {
                clUIMessages.ShowNotFound("Application Type", (int)_ID);
                Close();
                return;
            }

            _FillFormWithApplicationTypeInfo();
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e) => _DesignForm();

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.IsValid(errorProvider1))
            {
                clUIMessages.ShowValidationError();
                return;
            }

            _ApplicationType.Title = tb_Title.Text.Trim();
            _ApplicationType.Fees = Convert.ToDecimal(tb_Fees.Text.Trim());

            if (_ApplicationType.Save())
            {
                clUIMessages.ShowSaveSuccess();
            }
            else
            {
                clUIMessages.ShowSaveError();
            }
        }
        private void btn_Close_Click(object sender, EventArgs e) => Close();

        private void tb_Title_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, $"Title is required.");
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
