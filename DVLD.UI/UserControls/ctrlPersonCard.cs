using DVLD.Data;
using DVLD.UI.People;
using DVLD.UI.Properties;
using System;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clPerson _Person;
        private int _ID;

        public clPerson Person
        {
            get => _Person;
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gender.ToString() == "Male")
                pb_Gender.Image = Resources.Male;

            else
                pb_Gender.Image = Resources.Female;

            if (!string.IsNullOrEmpty(_Person.ImagePath) && System.IO.File.Exists(_Person.ImagePath))
                pb_PersonImage.ImageLocation = _Person.ImagePath;

            else
            {
                pb_PersonImage.ImageLocation = string.Empty;
                pb_PersonImage.Image = (_Person.Gender.ToString() == "Male") ? Resources.MalePersonImage : Resources.FemalePersonImage;
            }
        }
        public void LoadPersonInfo(int ID)
        {
            _ID = ID;

            _Person = clPerson.Find(_ID);

            if (_Person == null)
            {
                MessageBox.Show($"No Person with ID = {_ID} was found in the system.", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            lb_ID.Text = _Person.ID.ToString();
            lb_FullName.Text = _Person.FullName;
            lb_NationalNumber.Text = _Person.NationalNumber;
            lb_Gender.Text = _Person.Gender.ToString();
            lb_Email.Text = _Person.Email;
            lb_Address.Text = _Person.Address;
            lb_DateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lb_Phone.Text = _Person.Phone;
            lb_Country.Text = _Person.Country.Name;

            _LoadPersonImage();
        }

        private void llb_EditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson Form = new frmAddEditPerson(_ID);
            Form.ShowDialog();

            LoadPersonInfo(_ID);
        }
    }
}
