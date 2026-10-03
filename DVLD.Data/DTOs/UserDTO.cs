using System;

namespace DVLD.Data.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; } = -1;
        public int PersonID { get; set; } = -1;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        public UserDTO() { }
        public UserDTO(int id,int personID, string username, string password, bool isActive)
        {
            ID = id;
            PersonID = personID;
            Username = username;
            Password = password;
            IsActive = isActive;
        }
    }
}