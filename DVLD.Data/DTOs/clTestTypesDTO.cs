namespace DVLD.Data.DTOs
{
    public class clTestTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clTestTypeDTO()
        {
            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            Fees = 0;
        }
        public clTestTypeDTO(int id, string name,string description,decimal fees)
        {
            ID = id;
            Name = name;
            Description = description;
            Fees = fees;
        }
    }
}