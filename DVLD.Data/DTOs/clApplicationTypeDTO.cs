namespace DVLD.Data.DTOs
{
    public class clApplicationTypeDTO
    {
        public int ID { get; set; } = -1;
        public string Title { get; set; } = string.Empty;
        public decimal Fees { get; set; } = 0;

        public clApplicationTypeDTO() { }
        public clApplicationTypeDTO(int id, string title, decimal fees)
        {
            ID = id;
            Title = title;
            Fees = fees;
        }
    }
}