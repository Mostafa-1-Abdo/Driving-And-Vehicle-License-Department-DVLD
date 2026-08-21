using DVLD.UI.People;
using System;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            cb_Filter.SelectedIndex = 0;
        }

        private void btn_SearchPerson_Click(object sender, EventArgs e)
        {
            if (cb_Filter.Text == "ID")
               ctrlPersonCard1.LoadPersonInfo(Convert.ToInt32(tb_Search.Text));
            else
                ctrlPersonCard1.LoadPersonInfo(tb_Search.Text);
        }

        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cb_Filter.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson Form = new frmAddEditPerson();
            Form.ShowDialog();
        }
    }
}
