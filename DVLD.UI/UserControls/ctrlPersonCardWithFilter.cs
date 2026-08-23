using DVLD.Logic;
using DVLD.UI.People;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public clPerson SelectedPerson { get => ctrlPersonCard1.SelectedPerson; }

        public bool gb_FilterEnabled { get => gb_Filters.Enabled; set => gb_Filters.Enabled = value; }

        public void SearchSelect()
        {
            tb_Search.Select();
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            cb_Filter.Text = "ID";
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

        public event Action<int> OnSelectedPerson;
        private void btn_SearchPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Search.Text.Trim()))
            {
                tb_Search.Select();
                return;
            }

            bool IsFailed = true;

            if (cb_Filter.Text == "ID")
                IsFailed = !ctrlPersonCard1.LoadPersonInfo(Convert.ToInt32(tb_Search.Text));

            else if (cb_Filter.Text == "National Number")
                IsFailed = !ctrlPersonCard1.LoadPersonInfo(tb_Search.Text);

            if (IsFailed)
            {
                tb_Search.Clear();
                tb_Search.Select();

                OnSelectedPerson?.Invoke(-1);
            }

            else
                OnSelectedPerson?.Invoke(SelectedPerson.ID);
        }

        private void _OnPersonSaved(clPerson Person)
        {
            if (ctrlPersonCard1.LoadPersonInfo(Person))
            {
                cb_Filter.Text = "ID";
                tb_Search.Text = Person.ID.ToString();

                gb_Filters.Enabled = false;

                OnSelectedPerson?.Invoke(SelectedPerson.ID);
            }

            else
                OnSelectedPerson?.Invoke(-1);
        }
        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson Form = new frmAddEditPerson();
            Form.OnPersonSaved += _OnPersonSaved;
            Form.ShowDialog();

            tb_Search.Select();
        }

        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cb_Filter.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void tb_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_SearchPerson.PerformClick();
            }
        }
    }
}
