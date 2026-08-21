using System.Windows.Forms;

namespace DVLD.UI
{
    public static class clFormValidationExtensions
    {
        private static bool ValidateControls(Control control, ErrorProvider errorProvider)
        {
            foreach (Control ctr in control.Controls)
            {
                if (!string.IsNullOrEmpty(errorProvider.GetError(ctr)))
                    return false;

                if (ctr.HasChildren && !ValidateControls(ctr, errorProvider))
                    return false;
            }
            return true;
        }
        public static bool IsValid(this Form form, ErrorProvider errorProvider)
        {
            form.ValidateChildren();
            return ValidateControls(form, errorProvider);
        }
    }
}
