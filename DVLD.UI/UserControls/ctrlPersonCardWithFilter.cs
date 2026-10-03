using DVLD.Logic;
using DVLD.UI.People;
using DVLD.UI.Util;
using System;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public Person SelectedPerson => ctrlPersonCard1.SelectedPerson;
        public int SelectedPersonID => ctrlPersonCard1.SelectedPersonID;

        public bool gb_FilterEnabled { get => gb_Filters.Enabled; set => gb_Filters.Enabled = value; }

        public void SearchSelect()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                tb_Search.Select();
                tb_Search.SelectAll();
            });
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            cb_Filter.Text = "ID";
        }

        public bool LoadPersonInfo(Person person)
        {
            if (person == null) return false;

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

            if (string.IsNullOrEmpty(searchValue))
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
                    {
                        UIMessages.ShowNotFound("Person", personID);
                    }
                }
                else
                {
                    isFailed = true;
                    UIMessages.ShowValidationError();
                }
            }
            else if (cb_Filter.Text == "National Number")
            {
                isFailed = !ctrlPersonCard1.LoadPersonInfo(searchValue);
                if (isFailed)
                {
                    UIMessages.ShowNotFound("Person", searchValue);
                }
            }

            if (isFailed)
            {
                tb_Search.SelectAll();
                OnSelectedPerson?.Invoke(-1);
            }
            else
            {
                OnSelectedPerson?.Invoke(SelectedPerson.ID);
            }
        }

        public event Action<int> OnSavedPerson;
        private void _OnPersonSaved(Person person)
        {
            if (ctrlPersonCard1.LoadPersonInfo(person))
            {
                cb_Filter.Text = "ID";
                tb_Search.Text = person.ID.ToString();

                OnSavedPerson?.Invoke(SelectedPerson.ID);
            }
            else
            {
                OnSavedPerson?.Invoke(-1);
            }
        }
        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            using (frmAddEditPerson form = new frmAddEditPerson())
            {
                form.OnPersonSaved += _OnPersonSaved;
                form.ShowDialog(FindForm());
                form.OnPersonSaved -= _OnPersonSaved;
            }
        }

        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cb_Filter.Text == "ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void tb_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_SearchPerson.PerformClick();
            }
        }

        private void cb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Search.Text = null;
            ctrlPersonCard1.ResetPersonCard();

            tb_Search.Select();
        }
    }
}