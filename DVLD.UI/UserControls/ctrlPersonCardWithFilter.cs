using DVLD.Logic;
using DVLD.UI.People;
using DVLD.UI.Util;
using System;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public clPerson SelectedPerson => ctrlPersonCard1.SelectedPerson;

        public bool gb_FilterEnabled
        {
            get => gb_Filters.Enabled;
            set => gb_Filters.Enabled = value;
        }

        public void SearchSelect() => tb_Search.Select();

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            cb_Filter.Text = "ID";
        }

        public bool LoadPersonInfo(clPerson person)
        {
            if (person == null)
                return false;

            if (ctrlPersonCard1.LoadPersonInfo(person))
            {
                cb_Filter.Text = "ID";
                tb_Search.Text = person.ID.ToString();
                return true;
            }

            return false;
        }

        public event Action<int> OnSelectedPerson;

        private void btn_SearchPerson_Click(object sender, EventArgs e)
        {
            string searchValue = tb_Search.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                tb_Search.Select();
                return;
            }

            bool isFailed = true;

            if (cb_Filter.Text == "ID")
            {
                if (int.TryParse(searchValue, out int personID))
                {
                    isFailed = !ctrlPersonCard1.LoadPersonInfo(personID);
                    if (isFailed)
                        clUIMessages.ShowNotFound("Person", personID);
                }
                else
                {
                    isFailed = true;
                    clUIMessages.ShowValidationError();
                }
            }
            else if (cb_Filter.Text == "National Number")
            {
                isFailed = !ctrlPersonCard1.LoadPersonInfo(searchValue);
                if (isFailed)
                    clUIMessages.ShowNotFoundByField("Person", "National Number", searchValue);
            }

            if (isFailed)
            {
                tb_Search.Clear();
                tb_Search.Select();
                OnSelectedPerson?.Invoke(-1);
            }
            else
            {
                OnSelectedPerson?.Invoke(SelectedPerson.ID);
            }
        }

        private void _OnPersonSaved(clPerson person)
        {
            if (ctrlPersonCard1.LoadPersonInfo(person))
            {
                cb_Filter.Text = "ID";
                tb_Search.Text = person.ID.ToString();

                gb_Filters.Enabled = false;

                OnSelectedPerson?.Invoke(SelectedPerson.ID);
            }
            else
            {
                OnSelectedPerson?.Invoke(-1);
            }
        }

        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson form = new frmAddEditPerson();
            form.OnPersonSaved += _OnPersonSaved;
            form.ShowDialog(FindForm());

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