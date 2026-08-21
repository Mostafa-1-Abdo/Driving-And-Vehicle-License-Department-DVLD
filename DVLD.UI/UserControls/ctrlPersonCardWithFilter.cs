using System;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void btn_SearchPerson_Click(object sender, EventArgs e)
        {
            if (cb_Filter.Text == "ID")
               ctrlPersonCard1.LoadPersonInfo(tb_Search.Text);
            else
                ctrlPersonCard1.LoadPersonInfo(tb_Search.Text);
        }

        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cb_Filter.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
