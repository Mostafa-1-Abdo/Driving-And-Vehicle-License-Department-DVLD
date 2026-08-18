namespace DVLD.Data.DTOs
{
    public class clCountryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public clCountryDTO()
        {
            ID = -1;
            Name = string.Empty;
        }
        public clCountryDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
