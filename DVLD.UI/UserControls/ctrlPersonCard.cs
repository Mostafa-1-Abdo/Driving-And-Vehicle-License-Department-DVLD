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
        private clPerson _Person;

        public clPerson SelectedPerson => _Person;

        public ctrlPersonCard() => InitializeComponent();

        public void ResetPersonCard()
        {
            _Person = null;

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

            if (_Person.Gender == clPerson.enGender.Male)
            {
                pb_Gender.Image = Resources.Male;
                personImage = Resources.MalePersonImage;
            }
            else
            {
                pb_Gender.Image = Resources.Female;
                personImage = Resources.FemalePersonImage;
            }

            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pb_PersonImage.ImageLocation = _Person.ImagePath;
            }
            else
            {
                pb_PersonImage.ImageLocation = null;
                pb_PersonImage.Image = personImage;
            }
        }
        private void _FillCardWithPersonInfo()
        {
            lb_ID.Text = _Person.ID.ToString();
            lb_FullName.Text = _Person.FullName;
            lb_NationalNumber.Text = _Person.NationalNumber;
            lb_Gender.Text = _Person.Gender.ToString();
            lb_Email.Text = _Person.Email?? "[????]";
            lb_Address.Text = _Person.Address;
            lb_DateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lb_Phone.Text = _Person.Phone;
            lb_Country.Text = _Person.Country?.Name ?? "[????]";

            _LoadPersonImage();

            llb_EditPersonInfo.Enabled = true;
        }

        public bool LoadPersonInfo(int id)
        {
            _Person = clPerson.Find(id);

            if (_Person == null)
            {
                ResetPersonCard();
                return false;
            }

            _FillCardWithPersonInfo();
            return true;
        }
        public bool LoadPersonInfo(string nationalNumber)
        {
            _Person = clPerson.Find(nationalNumber);

            if (_Person == null)
            {
                ResetPersonCard();
                return false;
            }

            _FillCardWithPersonInfo();
            return true;
        }
        public bool LoadPersonInfo(clPerson person)
        {
            _Person = person;

            if (_Person == null)
            {
                ResetPersonCard();
                return false;
            }

            _FillCardWithPersonInfo();
            return true;
        }

        private void llb_EditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Person == null) return;

            new frmAddEditPerson(_Person.ID).ShowDialog(FindForm());
            LoadPersonInfo(_Person.ID);
        }
    }
}