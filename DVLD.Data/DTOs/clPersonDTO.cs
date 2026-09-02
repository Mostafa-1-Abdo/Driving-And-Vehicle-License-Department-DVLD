using System;

namespace DVLD.Data.DTOs
{
    public class clPersonDTO
    {
        public int ID { get; set; } = -1;
        public byte Gender { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public int CountryID { get; set; } = -1;
        public string CountryName { get; set; } = string.Empty;
        public string NationalNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public clPersonDTO() { }
        public clPersonDTO(int id, byte gender, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, int countryID,string countryName, string nationalNumber, string address, string phone, string email, string imagePath)
        {
            ID = id;
            Gender = gender;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CountryID = countryID;
            CountryName = countryName;
            NationalNumber = nationalNumber;
            Address = address;
            Phone = phone;
            Email = email;
            ImagePath = imagePath;
        }
    }
}