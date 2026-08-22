using DVLD.Data;
using DVLD.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DVLD.Logic.clPerson;

namespace DVLD.Logic
{
    public class clUser
    {
        private enum enMode : byte { AddNew, Update }
        public enum enGender : byte { Male, Female }

        private enMode _Mode;

        public int ID { get; set; }
        public clPerson Person { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clUserDTO UserDTO
        {
            get => new clUserDTO(ID, Person.PersonDTO, Username, Password, IsActive);
        }

        public clUser()
        {
            _Mode = enMode.AddNew;

            ID = -1;
            Person = new clPerson();
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
        }
        internal clUser(clUserDTO UserDTO)
        {
            _Mode = enMode.Update;

            ID = UserDTO.ID;
            Person = new clPerson(UserDTO.PersonDTO);
            Username = UserDTO.Username;
            Password = UserDTO.Password;
            IsActive = UserDTO.IsActive;
        }

        public enum enLoginResults { Success, UserNotFound,InvalidPassword,UserNotActive}
        public static (enLoginResults Result,clUser User) Login(string Username,string Password)
        {
            clUserDTO UserDTO = clUserData.Find(Username);

            if (UserDTO == null)
                return (enLoginResults.UserNotFound,null);

            else if (Password != UserDTO.Password)
                return (enLoginResults.InvalidPassword,null);

            else if(!UserDTO.IsActive)
                return (enLoginResults.UserNotActive,null);

            return (enLoginResults.Success,new clUser(UserDTO));
        }

        public static clUser Find(int ID)
        {
            clUserDTO UserDTO = clUserData.Find(ID);

            return UserDTO != null ? new clUser(UserDTO) : null;
        }
        public static clUser Find(string Username)
        {
            clUserDTO UserDTO = clUserData.Find(Username);

            return UserDTO != null ? new clUser(UserDTO) : null;
        }

        public static bool IsExist(int ID)
        {
            return clUserData.IsExist(ID);
        }
        public static bool IsExist(string Username)
        {
            return clUserData.IsExist(Username);
        }
        public static bool IsExistForPersonID(int PersonID)
        {
            return clUserData.IsExistForPersonID(PersonID);
        }

        private bool _AddNew()
        {
            ID = clUserData.AddNew(UserDTO);

            return ID != -1;
        }
        private bool _Update()
        {
            return clUserData.Update(UserDTO);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        public bool UpdatePassword(string NewPassword)
        {
            if (clUserData.UpdatePassword(ID, NewPassword))
            {
                Password = NewPassword;
                return true;
            }
            return false;
        }

        public static bool Delete(int ID)
        {
            return clUserData.Delete(ID);
        }

        public static DataTable GetAllUsers()
        {
            return clUserData.GetManageUsersList();
        }
    }
}
