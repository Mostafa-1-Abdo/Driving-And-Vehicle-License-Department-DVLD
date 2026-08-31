using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class clUser
    {
        private enum enMode : byte { AddNew, Update }

        private enMode _Mode;

        public int ID { get; private set; }
        public clPerson Person { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clUserDTO UserDTO => new clUserDTO(ID, Person.PersonDTO, Username, Password, IsActive);

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

        public enum enLoginResults : byte { Success, UserNotFound, InvalidPassword, UserNotActive }
        public static (enLoginResults Result, clUser User) Login(string Username, string Password)
        {
            clUserDTO UserDTO = clUserData.Find(Username);

            if (UserDTO == null)
                return (enLoginResults.UserNotFound, null);

            if (Password != UserDTO.Password)
                return (enLoginResults.InvalidPassword, null);

            if (!UserDTO.IsActive)
                return (enLoginResults.UserNotActive, null);

            return (enLoginResults.Success, new clUser(UserDTO));
        }

        public static clUser Find(int ID) => clUserData.Find(ID) is clUserDTO UserDTO ? new clUser(UserDTO) : null;
        public static clUser Find(string Username) => clUserData.Find(Username) is clUserDTO UserDTO ? new clUser(UserDTO) : null;

        public static bool IsExist(int ID) => clUserData.IsExist(ID);
        public static bool IsExist(string Username) => clUserData.IsExist(Username);
        public static bool IsExistForPersonID(int PersonID) => clUserData.IsExistForPersonID(PersonID);

        private bool _AddNew() => (ID = clUserData.AddNew(UserDTO)) != -1;
        private bool _Update() => clUserData.Update(UserDTO);
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

        public bool ChangePassword(string NewPassword)
        {
            if (clUserData.ChangePassword(ID, NewPassword))
            {
                Password = NewPassword;
                return true;
            }
            return false;
        }

        public static bool Delete(int ID) => clUserData.Delete(ID);

        public static DataTable GetAllUsers() => clUserData.GetManageUsersList();
    }
}