using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class clCountry
    {
        public int ID { get; private set; }
        public string Name { get; set; }

        public clCountryDTO CountryDTO => new clCountryDTO(ID, Name); 

        public clCountry()
        {
            ID = -1;
            Name = string.Empty;
        }
        internal clCountry(clCountryDTO CountryDTO)
        {
            ID = CountryDTO.ID;
            Name = CountryDTO.Name;
        }

        static public DataTable GetAllCountries() =>  clCountryData.GetAllCountries();
    }
}