using Contacts.Logic.Countries;
using DVLD.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Data
{
    public class clPerson
    {
        private enum enMode : byte { AddNew, Update }
        public enum enGender : byte { Male, Female }

        private enMode _Mode;

        public int ID { get; set; }
        public enGender Gender { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public clCountry Country { get; set; }
        public string NationalNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public string FullName
        {
            get => !string.IsNullOrEmpty(ThirdName) ? $"{FirstName} {SecondName} {ThirdName} {LastName}" : $"{FirstName} {SecondName} {LastName}";
        }
        public clPersonDTO PersonDTO
        {
            get => new clPersonDTO(ID, (byte)Gender, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Country.ID, Country.Name, NationalNumber, Address, Phone, Email, ImagePath);
        }

        private clPerson(clPersonDTO PersonDTO)
        {
            _Mode = enMode.Update;

            ID = PersonDTO.ID;
            Gender = (enGender)PersonDTO.Gender;
            FirstName = PersonDTO.FirstName;
            SecondName = PersonDTO.SecondName;
            ThirdName = PersonDTO.ThirdName;
            LastName = PersonDTO.LastName;
            DateOfBirth = PersonDTO.DateOfBirth;
            Country = new clCountry
            {
                ID = PersonDTO.CountryDTO.ID,
                Name = PersonDTO.CountryDTO.Name
            };
            NationalNumber = PersonDTO.NationalNumber;
            Address = PersonDTO.Address;
            Phone = PersonDTO.Phone;
            Email = PersonDTO.Email;
            ImagePath = PersonDTO.ImagePath;
        }
        public clPerson()
        {
            _Mode = enMode.AddNew;

            ID = -1;
            Gender = enGender.Male;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Country = new clCountry
            {
                ID = -1,
                Name = string.Empty
            };
            NationalNumber = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            ImagePath = string.Empty;
        }

        public static clPerson Find(int ID)
        {
            clPersonDTO PersonDTO = clPersonData.Find(ID);

            return PersonDTO != null ? new clPerson(PersonDTO) : null;
        }
        public static clPerson Find(string NationalNumber)
        {
            clPersonDTO PersonDTO = clPersonData.Find(NationalNumber);

            return PersonDTO != null ? new clPerson(PersonDTO) : null;
        }

        public static bool IsExist(int ID)
        {
            return clPersonData.IsExist(ID);
        }
        public static bool IsExist(string NationalNumber)
        {
            return clPersonData.IsExist(NationalNumber);
        }

        private bool _AddNew()
        {
            ID = clPersonData.AddNew(PersonDTO);

            return ID != -1;
        }
        private bool _Update()
        {
            return clPersonData.Update(PersonDTO);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        public static bool Delete(int ID)
        {
            return clPersonData.Delete(ID);
        }

        public static DataTable GetAllPeople()
        {
            return clPersonData.GetManagePeopleList();
        }
    }
}
