using DVLD.Data;
using System.Data;

namespace DVLD.Logic
{
    public class clCountry
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;

        public clCountry() { }
        public clCountry(int id,string name)
        {
            ID = id;
            Name = name;
        }

        static public DataTable GetAllCountries() =>  clCountryData.GetAllCountries();
    }
}