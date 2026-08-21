using DVLD.Data;
using DVLD.Data.DTOs;
using System;
using System.Data;

namespace Contacts.Logic.Countries
{
    public class clCountry
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public clCountryDTO CountryDTO
        {
            get => new clCountryDTO(ID, Name);
        }

        private clCountry(clCountryDTO CountryDTO)
        {
            ID = CountryDTO.ID;
            Name = CountryDTO.Name;
        }
        public clCountry()
        {
            ID = -1;
            Name = string.Empty;
        }

        static public DataTable GetAllCountries()
        {
            return clCountryData.GetAllCountries();
        }
    }
}
