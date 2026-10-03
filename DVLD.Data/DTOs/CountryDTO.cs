namespace DVLD.Data.DTOs
{
    public class CountryDTO
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;

        public CountryDTO() { }
        public CountryDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}