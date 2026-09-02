namespace DVLD.Data.DTOs
{
    public class clTestTypeDTO
    {
        public int ID { get; set; } = -1;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Fees { get; set; } = 0;

        public clTestTypeDTO() { }
        public clTestTypeDTO(int id, string title,string description,decimal fees)
        {
            ID = id;
            Title = title;
            Description = description;
            Fees = fees;
        }
    }
}