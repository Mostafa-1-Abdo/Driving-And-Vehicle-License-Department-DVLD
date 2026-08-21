using DVLD.Logic;
using DVLD.UI.People;
using DVLD.UI.Properties;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clPerson _Person;

        public clPerson SelectedPerson { get => _Person; }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gender == clPerson.enGender.Male)
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
            _Person = clPerson.Find(ID);

            if (_Person == null)
            {
                MessageBox.Show($"No Person with ID = {ID} was found in the system.", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        public void LoadPersonInfo(string NationalNumber)
        {
            _Person = clPerson.Find(NationalNumber);

            if (_Person == null)
            {
                MessageBox.Show($"No Person with national number = {NationalNumber} was found in the system.", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            frmAddEditPerson Form = new frmAddEditPerson(_Person.ID);
            Form.ShowDialog();

            LoadPersonInfo(_Person.ID);
        }
    }
}
