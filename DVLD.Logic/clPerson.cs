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

        private enMode _Mode;

        public int ID { get; private set; }
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

        public string FullName => !string.IsNullOrWhiteSpace(ThirdName) ?
            $"{FirstName} {SecondName} {ThirdName} {LastName}" :
            $"{FirstName} {SecondName} {LastName}";
        
        public clPersonDTO PersonDTO => new clPersonDTO(
          ID, (byte)Gender, FirstName, SecondName, ThirdName, LastName,
          DateOfBirth,Country.CountryDTO, NationalNumber, Address, Phone, Email, ImagePath);

        public clPerson()
        {
            _Mode = enMode.AddNew;

            ID = -1;
            Gender = enGender.Male;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now.AddYears(-18);
            Country = new clCountry();
            NationalNumber = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            ImagePath = string.Empty;
        }
        internal clPerson(clPersonDTO PersonDTO)
        {
            _Mode = enMode.Update;

            ID = PersonDTO.ID;
            Gender = (enGender)PersonDTO.Gender;
            FirstName = PersonDTO.FirstName;
            SecondName = PersonDTO.SecondName;
            ThirdName = PersonDTO.ThirdName;
            LastName = PersonDTO.LastName;
            DateOfBirth = PersonDTO.DateOfBirth;
            Country = new clCountry(PersonDTO.CountryDTO);
            NationalNumber = PersonDTO.NationalNumber;
            Address = PersonDTO.Address;
            Phone = PersonDTO.Phone;
            Email = PersonDTO.Email;
            ImagePath = PersonDTO.ImagePath;
        }

        public static clPerson Find(int ID) => clPersonData.Find(ID) is clPersonDTO PersonDTO ? new clPerson(PersonDTO) : null;
        public static clPerson Find(string NationalNumber) => clPersonData.Find(NationalNumber) is clPersonDTO PersonDTO ? new clPerson(PersonDTO) : null;

        public static bool IsExist(int ID) => clPersonData.IsExist(ID);
        public static bool IsExist(string NationalNumber) => clPersonData.IsExist(NationalNumber);
      
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

        public static bool Delete(int ID) => clPersonData.Delete(ID);
     
        public static DataTable GetAllPeople() => clPersonData.GetManagePeopleList();
    }
}