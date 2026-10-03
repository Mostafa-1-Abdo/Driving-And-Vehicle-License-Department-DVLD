using DVLD.Logic;
using DVLD.UI.People;
using DVLD.UI.Properties;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace DVLD.UI.UserControls
{
    public partial class ctrlPersonCard : UserControl
    {
        private Person _person;

        public Person SelectedPerson => _person;
        public int SelectedPersonID => _person != null? _person.ID : -1;

        public ctrlPersonCard() => InitializeComponent();

        public void ResetPersonCard()
        {
            _person = null;

            lb_ID.Text = "[???]";
            lb_FullName.Text = "[???]";
            lb_NationalNumber.Text = "[???]";
            lb_Gender.Text = "[???]";
            pb_Gender.Image = Resources.Male;
            pb_PersonImage.Image = Resources.MalePersonImage;
            pb_PersonImage.ImageLocation = null;
            lb_Email.Text = "[???]";
            lb_Address.Text = "[???]";
            lb_DateOfBirth.Text = "[???]";
            lb_Phone.Text = "[???]";
            lb_Country.Text = "[???]";

            llb_EditPersonInfo.Enabled = false;
        }

        private void _LoadPersonImage()
        {
            Image personImage = null;

            if (_person.Gender == Person.enGender.Male)
            {
                pb_Gender.Image = Resources.Male;
                personImage = Resources.MalePersonImage;
            }
            else
            {
                pb_Gender.Image = Resources.Female;
                personImage = Resources.FemalePersonImage;
            }

            if (!string.IsNullOrEmpty(_person.ImagePath) && File.Exists(_person.ImagePath))
            {
                pb_PersonImage.ImageLocation = _person.ImagePath;
            }
            else
            {
                pb_PersonImage.ImageLocation = null;
                pb_PersonImage.Image = personImage;
            }
        }
        private void _FillCardWithPersonInfo()
        {
            lb_ID.Text = _person.ID.ToString();
            lb_FullName.Text = _person.FullName;
            lb_NationalNumber.Text = _person.NationalNumber;
            lb_Gender.Text = _person.Gender.ToString();
            lb_Email.Text = _person.Email?? "[????]";
            lb_Address.Text = _person.Address;
            lb_DateOfBirth.Text = _person.DateOfBirth.ToShortDateString();
            lb_Phone.Text = _person.Phone;
            lb_Country.Text = _person.Country?.Name ?? "[????]";

            _LoadPersonImage();

            llb_EditPersonInfo.Enabled = true;
        }

        public bool LoadPersonInfo(int id)
        {
            _person = Person.Find(id);

            if (_person == null)
            {
                ResetPersonCard();
                return false;
            }

            _FillCardWithPersonInfo();
            return true;
        }
        public bool LoadPersonInfo(string nationalNumber)
        {
            _person = Person.Find(nationalNumber);

            if (_person == null)
            {
                ResetPersonCard();
                return false;
            }

            _FillCardWithPersonInfo();
            return true;
        }
        public bool LoadPersonInfo(Person person)
        {
            _person = person;

            if (_person == null)
            {
                ResetPersonCard();
                return false;
            }

            _FillCardWithPersonInfo();
            return true;
        }

        private void llb_EditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_person == null) return;

            new frmAddEditPerson(_person.ID).ShowDialog(FindForm());
            LoadPersonInfo(_person.ID);
        }
    }
}