namespace DVLD.Data.DTOs
{
    public class ApplicationTypeDTO
    {
        public byte ID { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public decimal Fees { get; set; } = decimal.Zero;

        public ApplicationTypeDTO() { }
        public ApplicationTypeDTO(byte id, string title, decimal fees)
        {
            ID = id;
            Title = title;
            Fees = fees;
        }
    }
}