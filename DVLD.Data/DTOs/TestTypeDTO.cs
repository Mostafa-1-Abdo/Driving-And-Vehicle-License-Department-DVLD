namespace DVLD.Data.DTOs
{
    public class TestTypeDTO
    {
        public byte ID { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Fees { get; set; } = decimal.Zero;

        public TestTypeDTO() { }
        public TestTypeDTO(byte id, string title,string description,decimal fees)
        {
            ID = id;
            Title = title;
            Description = description;
            Fees = fees;
        }
    }
}