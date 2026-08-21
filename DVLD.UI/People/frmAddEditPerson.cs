using DVLD.Logic;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using DVLD.UI.Util;
using DVLD.UI.Properties;

namespace DVLD.UI.People
{
    public partial class frmAddEditPerson : Form
    {
        enum enMode : byte { AddNew, Edit }

        private clPerson _Person;
        private int _ID;
        private enMode _Mode;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public frmAddEditPerson(int ID)
        {
            InitializeComponent();

            _Mode = enMode.Edit;
            _ID = ID;
        }

        private void _FillComboBoxWithCountries()
        {
            cb_Country.DataSource = clCountry.GetAllCountries();
            cb_Country.DisplayMember = "Name";
            cb_Country.ValueMember = "ID";
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
                rb_Male.Checked = true;
            else
                rb_Female.Checked = true;
            tb_Phone.Text = _Person.Phone;
            tb_Email.Text = _Person.Email;
            cb_Country.SelectedValue = _Person.Country.ID;
            tb_Address.Text = _Person.Address;
            if (File.Exists(_Person.ImagePath))
                pb_PersonImage.ImageLocation = _Person.ImagePath;
        }
        private void _DesignForm()
        {
            if (_Mode == enMode.AddNew)
            {
                Text = "Add New Person";
                lb_Title.Text = "Add New Person";
                _Person = new clPerson();
            }
            else
            {
                Text = "Update Person";
                lb_Title.Text = "Update Person";
                _Person = clPerson.Find(_ID);

                if (_Person == null)
                {
                    MessageBox.Show($"No Person with ID = {_ID} was found in the system.", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                pb_PersonImage.Image = rb_Male.Checked ? Resources.MalePersonImage : Resources.FemalePersonImage;
        }
        private void rb_Gender_CheckedChanged(object sender, EventArgs e)
        {
            _ChangePersonImageAccordingToGender();
        }

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
                errorProvider1.SetError(control, $"{control.Tag?.ToString() ?? "This field"} is required.");

            else
                errorProvider1.SetError(control, null);
        }
        private void tb_NationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Edit)
                return;

            if (string.IsNullOrWhiteSpace(tb_NationalNumber.Text))
                errorProvider1.SetError(tb_NationalNumber, "National number is required.");

            else if (clPerson.IsExist(tb_NationalNumber.Text))
                errorProvider1.SetError(tb_NationalNumber, "National Number is already used by another person.");

            else
                errorProvider1.SetError(tb_NationalNumber, null);
        }
        private void tb_Email_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Email.Text))
                return;

            if (!clUtil.IsValidEmail(tb_Email.Text))
                errorProvider1.SetError(tb_Email, $"Invalid Email Address format! (e.g., user@example.com)");

            else
                errorProvider1.SetError(tb_Email, null);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.IsValid(errorProvider1))
            {
                MessageBox.Show("Some fields are not valid. Please check red error icons.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string OldImagePath = _Person.ImagePath;
            string NewImagePath = pb_PersonImage.ImageLocation ?? string.Empty;

            if (!clFileHandler.HandleImages(OldImagePath, ref NewImagePath))
            {
                MessageBox.Show("Failed to process person image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Person.ImagePath = NewImagePath;

            _Person.Gender = rb_Male.Checked ? clPerson.enGender.Male : clPerson.enGender.Female;
            _Person.FirstName = tb_FirstName.Text.Trim();
            _Person.SecondName = tb_SecondName.Text.Trim();
            _Person.ThirdName = tb_ThirdName.Text.Trim();
            _Person.LastName = tb_LastName.Text.Trim();
            _Person.DateOfBirth = dtp_DateOfBirth.Value;
            _Person.Country.ID = (int)cb_Country.SelectedValue;
            _Person.NationalNumber = tb_NationalNumber.Text.Trim();
            _Person.Phone = tb_Phone.Text.Trim();
            _Person.Email = tb_Email.Text.Trim();
            _Person.Address = tb_Address.Text.Trim();

            if (_Person.Save())
            {
                lb_ID.Text = _Person.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!string.IsNullOrEmpty(OldImagePath) && OldImagePath != NewImagePath)
                {
                    clFileHandler.HandleFileDelete(OldImagePath);
                }

                Text = "Edit Person";
                lb_Title.Text = "Edit Person";
                _Mode = enMode.Edit;
                tb_NationalNumber.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Data was not saved successfully.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pb_PersonImage.ImageLocation = _Person.ImagePath = OldImagePath;
                if (!string.IsNullOrEmpty(OldImagePath) && OldImagePath != NewImagePath)
                {
                    clFileHandler.HandleFileDelete(OldImagePath);
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
