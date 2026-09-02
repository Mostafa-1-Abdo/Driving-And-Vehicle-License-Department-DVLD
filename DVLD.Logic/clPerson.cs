using DVLD.Data;
using DVLD.Data.DTOs;
using System;
using System.Data;

namespace DVLD.Logic
{
    public class clPerson
    {
        private enum enMode : byte { AddNew, Update }
        public enum enGender : byte { Male, Female }

        private enMode _Mode = enMode.AddNew;

        public int ID { get; private set; } = -1;
        public enGender Gender { get; set; } = enGender.Male;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-18);
        public clCountry Country { get; set; } = new clCountry();
        public string NationalNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public string FullName => !string.IsNullOrWhiteSpace(ThirdName) ?
            $"{FirstName} {SecondName} {ThirdName} {LastName}" :
            $"{FirstName} {SecondName} {LastName}";

        public clPersonDTO PersonDTO => new clPersonDTO(ID, (byte)Gender, FirstName, SecondName, ThirdName, LastName,
            DateOfBirth, Country?.ID ?? -1,Country?.Name ?? string.Empty,NationalNumber, Address, Phone, Email, ImagePath);

        public clPerson() { }
        public clPerson(clPersonDTO personDTO)
        {
            _Mode = enMode.Update;

            ID = personDTO.ID;
            Gender = (enGender)personDTO.Gender;
            FirstName = personDTO.FirstName;
            SecondName = personDTO.SecondName;
            ThirdName = personDTO.ThirdName;
            LastName = personDTO.LastName;
            DateOfBirth = personDTO.DateOfBirth;
            Country = new clCountry(personDTO.CountryID, personDTO.CountryName);
            NationalNumber = personDTO.NationalNumber;
            Address = personDTO.Address;
            Phone = personDTO.Phone;
            Email = personDTO.Email;
            ImagePath = personDTO.ImagePath;
        }

        public static clPerson Find(int id) => clPersonData.Find(id) is clPersonDTO PersonDTO ? new clPerson(PersonDTO) : null;
        public static clPerson Find(string nationalNumber) => clPersonData.Find(nationalNumber) is clPersonDTO PersonDTO ? new clPerson(PersonDTO) : null;

        public static bool IsExist(int id) => clPersonData.IsExist(id);
        public static bool IsExist(string nationalNumber) => clPersonData.IsExist(nationalNumber);

        private bool _AddNew() => (ID = clPersonData.AddNew(PersonDTO)) != -1;
        private bool _Update() => clPersonData.Update(PersonDTO);
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

        public static bool Delete(int id) => clPersonData.Delete(id);

        public static DataTable GetAllPeople() => clPersonData.GetManagePeopleList();
    }
}