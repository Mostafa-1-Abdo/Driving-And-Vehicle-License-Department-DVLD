using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class Country
    {
        public int ID { get; private set; } = -1;
        public string Name { get; private set; } = string.Empty;

        public Country(CountryDTO countryDTO)
        {
            ID = countryDTO.ID;
            Name = countryDTO.Name;
        }

        public static Country Find(int id) => CountryData.Find(id) is CountryDTO countryDTO ? new Country(countryDTO) : null;

        static public DataTable GetAllCountries() => CountryData.GetAllCountries();
    }
}