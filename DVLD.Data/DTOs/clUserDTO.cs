using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Data.DTOs
{
    public class clUserDTO
    {
        public int ID { get; set; }
        public clPersonDTO PersonDTO { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clUserDTO(int id, clPersonDTO personDTO, string username, string password ,bool isActive)
        {
            ID = id;
            PersonDTO = personDTO;
            Username = username;
            Password = password;
            IsActive = isActive;
        }
        public clUserDTO()
        {
            ID = -1;
            PersonDTO = new clPersonDTO();
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
        }
    }
}
