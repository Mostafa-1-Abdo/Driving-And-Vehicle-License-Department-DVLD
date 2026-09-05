using DVLD.Data;
using System.Data;

namespace DVLD.Logic
{
    public class clLicenseClass
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte MinimumAllowedAge { get; set; } = 0;
        public byte ValidityLength { get; set; } = 0;
        public decimal Fees { get; set; } = decimal.Zero;

        public clLicenseClass() { }
        public clLicenseClass(int id, string name, string description, byte minimumAllowedAge, byte validityLength, decimal fees)
        {
            ID = id;
            Name = name;
            Description = description;
            MinimumAllowedAge = minimumAllowedAge;
            ValidityLength = validityLength;
            Fees = fees;
        }

        static public DataTable GetAllLicenseClasses() => clLicenseClassData.GetAllLicenseClasses();
    }
}