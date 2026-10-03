using DVLD.Data;
using DVLD.Data.DTOs;
using System;
using System.Data;

namespace DVLD.Logic
{
    public class Person
    {
        private enum enMode : byte { AddNew, Update }
        public enum enGender : byte { Male, Female }

        private enMode _Mode = enMode.AddNew;

        public int ID { get; private set; } = -1;
        public enGender Gender { get; set; } = enGender.Male;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = null;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-18);
        private int _countryID = -1;
        private Country _country = null;
        public string NationalNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = null;
        public string ImagePath { get; set; } = null;

        public int CountryID
        {
            get => _countryID;
            set
            {
                if (_countryID != value)
                {
                    _countryID = value;
                    _country = null;
                }
            }
        }
        public Country Country
        {
            get
            {
                if (_countryID != -1 && _country == null)
                {
                    _country = Country.Find(_countryID);
                }
                return _country;
            }
        }

        public string FullName => !string.IsNullOrWhiteSpace(ThirdName) ?
            $"{FirstName} {SecondName} {ThirdName} {LastName}" :
            $"{FirstName} {SecondName} {LastName}";

        private PersonDTO PersonDTO => new PersonDTO(ID, (byte)Gender, FirstName, SecondName, ThirdName, LastName,
             DateOfBirth, CountryID, NationalNumber, Address, Phone, Email, ImagePath);

        public Person() { }
        public Person(PersonDTO personDTO)
        {
            _Mode = enMode.Update;

            ID = personDTO.ID;
            Gender = (enGender)personDTO.Gender;
            FirstName = personDTO.FirstName;
            SecondName = personDTO.SecondName;
            ThirdName = personDTO.ThirdName;
            LastName = personDTO.LastName;
            DateOfBirth = personDTO.DateOfBirth;
            CountryID = personDTO.CountryID;
            NationalNumber = personDTO.NationalNumber;
            Address = personDTO.Address;
            Phone = personDTO.Phone;
            Email = personDTO.Email;
            ImagePath = personDTO.ImagePath;
        }

        public static Person Find(int id) => PersonData.Find(id) is PersonDTO PersonDTO ? new Person(PersonDTO) : null;
        public static Person Find(string nationalNumber) => PersonData.Find(nationalNumber) is PersonDTO PersonDTO ? new Person(PersonDTO) : null;

        public static bool IsExist(int id) => PersonData.IsExist(id);
        public static bool IsExist(string nationalNumber) => PersonData.IsExist(nationalNumber);

        private bool _AddNew() => (ID = PersonData.AddNew(PersonDTO)) != -1;
        private bool _Update() => PersonData.Update(PersonDTO);
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

        public static bool Delete(int id) => PersonData.Delete(id);

        public static DataTable GetAllPeople() => PersonData.GetManagePeopleList();
    }
}