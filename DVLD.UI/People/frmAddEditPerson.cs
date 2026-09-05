using DVLD.Logic;
using DVLD.UI.Properties;
using DVLD.UI.Util;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace DVLD.UI.People
{
    public partial class frmAddEditPerson : Form
    {
        private enum enMode : byte { AddNew, Edit }

        private clPerson _Person;
        private int _ID;
        private enMode _Mode;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditPerson(int id)
        {
            InitializeComponent();

            _Mode = enMode.Edit;
            _ID = id;
        }

        private void _FillComboBoxWithCountries()
        {
            cb_Country.DisplayMember = "Name";
            cb_Country.ValueMember = "ID";
            cb_Country.DataSource = clCountry.GetAllCountries();
        }
        private void _LoadPersonInfo()
        {
            lb_ID.Text = _Person.ID.ToString();
            tb_FirstName.Text = _Person.FirstName;
            tb_SecondName.Text = _Person.SecondName;
            tb_ThirdName.Text = _Person.ThirdName;
            tb_LastName.Text = _Person.LastName;
            tb_NationalNumber.Text = _Person.NationalNumber;
            dtp_DateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender == clPerson.enGender.Male)
            {
                rb_Male.Checked = true;
            }
            else
            {
                rb_Female.Checked = true;
            }

            tb_Phone.Text = _Person.Phone;
            tb_Email.Text = _Person.Email;
            cb_Country.SelectedValue = _Person.Country?.ID ?? -1;
            tb_Address.Text = _Person.Address;

            if (File.Exists(_Person.ImagePath))
            {
                pb_PersonImage.ImageLocation = _Person.ImagePath;
            }
            else
            {
                _ChangePersonImageAccordingToGender();
            }
        }
        private void _DesignForm()
        {
            if (_Mode == enMode.AddNew)
            {
                Text = lb_Title.Text = "Add New Person";
                _Person = new clPerson();
            }
            else
            {
                Text = lb_Title.Text = "Edit Person";
                _Person = clPerson.Find(_ID);

                if (_Person == null)
                {
                    clUIMessages.ShowNotFound("Person", _ID);
                    Close();
                    return;
                }

                _LoadPersonInfo();

                llb_RemoveImage.Visible = !string.IsNullOrEmpty(pb_PersonImage.ImageLocation);
                tb_NationalNumber.Enabled = false;
            }
        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _FillComboBoxWithCountries();
            cb_Country.SelectedIndex = -1;

            dtp_DateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dtp_DateOfBirth.Value = dtp_DateOfBirth.MaxDate;

            _DesignForm();
        }

        private void _ChangePersonImageAccordingToGender()
        {
            if (string.IsNullOrEmpty(pb_PersonImage.ImageLocation))
            {
                pb_PersonImage.Image = rb_Male.Checked ? Resources.MalePersonImage : Resources.FemalePersonImage;
            }
        }
        private void rb_Gender_CheckedChanged(object sender, EventArgs e) => _ChangePersonImageAccordingToGender();

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pb_PersonImage.ImageLocation = openFileDialog1.FileName;
                llb_RemoveImage.Visible = true;
            }
        }
        private void llb_RemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pb_PersonImage.ImageLocation = string.Empty;
            llb_RemoveImage.Visible = false;
            _ChangePersonImageAccordingToGender();
        }

        private void Controls_Validating(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;

            if (string.IsNullOrWhiteSpace(control.Text))
            {
                errorProvider1.SetError(control, $"{control.Tag?.ToString() ?? "This field"} is required.");
            }
            else
            {
                errorProvider1.SetError(control, null);
            }
        }
        private void tb_NationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Edit) return;

            string nationalNumber = tb_NationalNumber.Text.Trim();

            if (string.IsNullOrEmpty(nationalNumber))
            {
                errorProvider1.SetError(tb_NationalNumber, "National Number is required.");
            }
            else if (clPerson.IsExist(nationalNumber))
            {
                errorProvider1.SetError(tb_NationalNumber, "National Number is already used by another person.");
            }
            else
            {
                errorProvider1.SetError(tb_NationalNumber, null);
            }
            }
        private void tb_Email_Validating(object sender, CancelEventArgs e)
        {
            string email = tb_Email.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                errorProvider1.SetError(tb_Email, null);
            }
            else if (!clUtil.IsValidEmail(email))
            {
                errorProvider1.SetError(tb_Email, "Invalid Email Address format! (e.g. user@example.com)");
            }
            else
            {
                errorProvider1.SetError(tb_Email, null);
            }
        }
        private void tb_Phone_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        public event Action<clPerson> OnPersonSaved;
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.IsValid(errorProvider1))
            {
                clUIMessages.ShowValidationError();
                return;
            }

            string oldImagePath = _Person.ImagePath;
            string newImagePath = pb_PersonImage.ImageLocation ?? string.Empty;

            if (!clFileHandler.HandleImages(oldImagePath, ref newImagePath))
            {
                clUIMessages.ShowImageProcessingError("Failed to process person image.");
                return;
            }

            _Person.ImagePath = newImagePath;
            _Person.Gender = rb_Male.Checked ? clPerson.enGender.Male : clPerson.enGender.Female;
            _Person.FirstName = tb_FirstName.Text.Trim();
            _Person.SecondName = tb_SecondName.Text.Trim();
            _Person.ThirdName = tb_ThirdName.Text.Trim();
            _Person.LastName = tb_LastName.Text.Trim();
            _Person.DateOfBirth = dtp_DateOfBirth.Value;
            _Person.Country = new clCountry((int)cb_Country.SelectedValue, cb_Country.Text);
            _Person.NationalNumber = tb_NationalNumber.Text.Trim();
            _Person.Phone = tb_Phone.Text.Trim();
            _Person.Email = tb_Email.Text.Trim();
            _Person.Address = tb_Address.Text.Trim();

            if (_Person.Save())
            {
                clUIMessages.ShowSaveSuccess();

                if (!string.IsNullOrEmpty(oldImagePath) && oldImagePath != newImagePath)
                {
                    clFileHandler.HandleFileDelete(oldImagePath);
                }

                Text = lb_Title.Text = "Edit Person";
                _Mode = enMode.Edit;

                lb_ID.Text = _Person.ID.ToString();
                _ID = _Person.ID;

                tb_NationalNumber.Enabled = false;

                OnPersonSaved?.Invoke(_Person);
            }
            else
            {
                clUIMessages.ShowSaveError();

                pb_PersonImage.ImageLocation = _Person.ImagePath = oldImagePath;
                if (!string.IsNullOrEmpty(oldImagePath) && oldImagePath != newImagePath)
                {
                    clFileHandler.HandleFileDelete(newImagePath);
                }
            }
        }
        private void btn_Close_Click(object sender, EventArgs e) => Close();
    }
}