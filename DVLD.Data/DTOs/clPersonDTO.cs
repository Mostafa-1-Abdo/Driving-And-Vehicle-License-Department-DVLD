using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace DVLD.Data.DTOs
{
    public class clPersonDTO
    {
        public int ID { get; set; }
        public byte Gender { get; set; }
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

        public clPersonDTO(int id, byte gender, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, int countryID,string nationalNumber, string address, string phone, string email, string imagePath)
        {
            ID = id;
            Gender = gender;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CountryID = countryID;
            NationalNumber = nationalNumber;
            Address = address;
            Phone = phone;
            Email = email;
            ImagePath = imagePath;
        }
        public clPersonDTO()
        {
            ID = 0;
            Gender = 0;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            CountryID = 0;
            NationalNumber = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            ImagePath = string.Empty;
        }
    }
}
