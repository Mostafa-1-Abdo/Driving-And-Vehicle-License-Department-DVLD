using DVLD.Logic;
using DVLD.UI.People;
using System;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public clPerson SelectedPerson { get => ctrlPersonCard1.SelectedPerson; }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            cb_Filter.Text = "ID";
        }

        public void DisableFilter()
        {
            gb_Filters.Enabled = false;
        }

        public bool LoadPersonInfo(clPerson Person)
        {
            if (ctrlPersonCard1.LoadPersonInfo(Person))
            {
                cb_Filter.Text = "ID";
                tb_Search.Text = Person.ID.ToString();

                return true;
            }
            return false;
        }

        private void btn_SearchPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Search.Text.Trim()))
                return;

            bool IsFailed = true;

            if (cb_Filter.Text == "ID")
                IsFailed = !ctrlPersonCard1.LoadPersonInfo(Convert.ToInt32(tb_Search.Text));

            else if (cb_Filter.Text == "National Number")
                IsFailed = !ctrlPersonCard1.LoadPersonInfo(tb_Search.Text);

            if (IsFailed)
            {
                tb_Search.Clear();
                tb_Search.Select();
            }
        }

        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cb_Filter.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void _OnPersonSaved(clPerson Person)
        {
            if (ctrlPersonCard1.LoadPersonInfo(Person))
            {
                cb_Filter.Text = "ID";
                tb_Search.Text = Person.ID.ToString();
            }

            else
                tb_Search.Clear();
        }
        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson Form = new frmAddEditPerson();
            Form.OnPersonSaved += _OnPersonSaved;

            Form.ShowDialog();
        }
    }
}
