using DVLD.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Data
{
    public class clPerson
    {
        public enum enMode : byte
        {
            AddNew, Update
        }
        public enum enGender : byte
        {
            Male, Female
        }

        public enMode _Mode;

        public int ID { get; set; }
        public enGender Gender { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public string NationalNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public clPersonDTO PersonDTO
        {
            get
            {
                return new clPersonDTO(ID, (byte)Gender, FirstName, SecondName, ThirdName, LastName, DateOfBirth, CountryID, NationalNumber, Address, Phone, Email, ImagePath);
            }
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
            CountryID = PersonDTO.CountryID;
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
            CountryID = -1;
            NationalNumber = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            ImagePath = string.Empty;
        }

        static public clPerson Find(int ID)
        {
            clPersonDTO PersonDTO = clPersonData.Find(ID);

            return PersonDTO != null ? new clPerson(PersonDTO) : null;
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
            return clPersonData.GetAllPeople();
        }
    }
}
