namespace DVLD.Data.DTOs
{
    public class clCountryDTO
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;

        public clCountryDTO() { }
        public clCountryDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}