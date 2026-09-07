using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class clCountry
    {
        public int ID { get; private set; } = -1;
        public string Name { get; private set; } = string.Empty;

        public clCountry(clCountryDTO countryDTO)
        {
            ID = countryDTO.ID;
            Name = countryDTO.Name;
        }

        public static clCountry Find(int id) => clCountryData.Find(id) is clCountryDTO CountryDTO ? new clCountry(CountryDTO) : null;

        static public DataTable GetAllCountries() =>  clCountryData.GetAllCountries();
    }
}