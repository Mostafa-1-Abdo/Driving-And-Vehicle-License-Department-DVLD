using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class TestType
    {
        public enum enTestType : byte { None = 0, VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        public enTestType ID { get; private set; } = enTestType.None;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Fees { get; set; } = decimal.Zero;

        public TestTypeDTO TestTypeDTO => new TestTypeDTO((byte)ID, Title, Description, Fees);

        public TestType() { }
        public TestType(TestTypeDTO testTypeDTO)
        {
            ID = (enTestType)testTypeDTO.ID;
            Title = testTypeDTO.Title;
            Description = testTypeDTO.Description;
            Fees = testTypeDTO.Fees;
        }

        public static TestType Find(enTestType id) => TestTypeData.Find((int)id) is TestTypeDTO testTypeDTO ? new TestType(testTypeDTO) : null;

        private bool _Update() => TestTypeData.Update(TestTypeDTO);
        public bool Save() => _Update();

        static public DataTable GetAllTestTypes() => TestTypeData.GetAllTestTypes();
    }
}