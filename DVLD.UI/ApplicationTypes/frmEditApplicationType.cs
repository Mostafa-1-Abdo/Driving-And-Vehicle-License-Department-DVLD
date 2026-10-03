using DVLD.Logic;
using DVLD.UI.Util;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.UI.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private ApplicationType _applicationType;
        private ApplicationType.enApplicationType _id;

        public frmEditApplicationType(int id)
        {
            InitializeComponent();

            _id = (ApplicationType.enApplicationType)id;
        }

        private void _FillFormWithApplicationTypeInfo()
        {
            lb_ID.Text = ((byte)_applicationType.ID).ToString();
            tb_Title.Text = _applicationType.Title;
            tb_Fees.Text = _applicationType.Fees.ToString("0.00");
        }
        private void _DesignForm()
        {
            _applicationType = ApplicationType.Find(_id);
            if (_applicationType == null)
            {
                UIMessages.ShowNotFound("Application Type", (int)_id);
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
                UIMessages.ShowValidationError();
                return;
            }

            _applicationType.Title = tb_Title.Text.Trim();
            _applicationType.Fees = Convert.ToDecimal(tb_Fees.Text.Trim());

            if (_applicationType.Save())
            {
                UIMessages.ShowSaveSuccess();
            }
            else
            {
                UIMessages.ShowSaveError();
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
            else if (!Util.Validation.IsValidMoney(fees))
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
