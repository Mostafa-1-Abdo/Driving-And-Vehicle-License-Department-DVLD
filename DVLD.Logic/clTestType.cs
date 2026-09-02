using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class clTestType
    {
        public enum enTestType : byte { None = 0, VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        public enTestType ID { get; private set; } = enTestType.None;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Fees { get; set; } = decimal.Zero;

        public clTestTypeDTO TestTypeDTO => new clTestTypeDTO((int)ID, Title, Description, Fees);

        public clTestType() { }
        public clTestType(clTestTypeDTO testTypeDTO)
        {
            ID = (enTestType)testTypeDTO.ID;
            Title = testTypeDTO.Title;
            Description = testTypeDTO.Description;
            Fees = testTypeDTO.Fees;
        }

        public static clTestType Find(enTestType id) => clTestTypeData.Find((int)id) is clTestTypeDTO TestTypeDTO ? new clTestType(TestTypeDTO) : null;

        private bool _Update() => clTestTypeData.Update(TestTypeDTO);
        public bool Save() => _Update();

        static public DataTable GetAllTestTypes() => clTestTypeData.GetAllTestTypes();
    }
}