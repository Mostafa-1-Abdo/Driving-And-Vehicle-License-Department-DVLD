using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class clTestType
    {
        public enum enTestType : byte { None = 0, VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        public enTestType ID { get;private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clTestTypeDTO TestTypeDTO => new clTestTypeDTO((int)ID, Title, Description, Fees);

        public clTestType()
        {
            ID = enTestType.None;
            Title = string.Empty;
            Description = string.Empty;
            Fees = 0;
        }
        internal clTestType(clTestTypeDTO TestTypeDTO)
        {
            ID = (enTestType)TestTypeDTO.ID;
            Title = TestTypeDTO.Title;
            Description = TestTypeDTO.Description;
            Fees = TestTypeDTO.Fees;
        }

        public static clTestType Find(enTestType ID) => clTestTypeData.Find((int)ID) is clTestTypeDTO TestTypeDTO ? new clTestType(TestTypeDTO) : null;

        private bool _Update() => clTestTypeData.Update(TestTypeDTO);
        public bool Save() => _Update();

        static public DataTable GetAllTestTypes() => clTestTypeData.GetAllTestTypes();
    }
}