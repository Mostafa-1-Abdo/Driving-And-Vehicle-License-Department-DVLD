using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class clUser
    {
        private enum enMode : byte { AddNew, Update }

        private enMode _Mode = enMode.AddNew;

        public int ID { get; private set; } = -1;
        public int PersonID { get; set; } = -1;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        public clPerson Person => PersonID != -1 ? clPerson.Find(PersonID) : null;

        private clUserDTO UserDTO => new clUserDTO(ID, PersonID, Username, Password, IsActive);

        public clUser() { }
        public clUser(clUserDTO userDTO)
        {
            _Mode = enMode.Update;

            ID = userDTO.ID;
            PersonID = userDTO.PersonID;
            Username = userDTO.Username;
            Password = userDTO.Password;
            IsActive = userDTO.IsActive;
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

        public static clUser Find(int id) => clUserData.Find(id) is clUserDTO UserDTO ? new clUser(UserDTO) : null;
        public static clUser Find(string username) => clUserData.Find(username) is clUserDTO UserDTO ? new clUser(UserDTO) : null;

        public static bool IsExist(int id) => clUserData.IsExist(id);
        public static bool IsExist(string username) => clUserData.IsExist(username);
        public static bool IsExistForPersonID(int personID) => clUserData.IsExistForPersonID(personID);

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

        public bool ChangePassword(string newPassword)
        {
            if (_Mode == enMode.AddNew) return false;

            if (clUserData.ChangePassword(ID, newPassword))
            {
                Password = newPassword;
                return true;
            }
            return false;
        }

        public static bool Delete(int id) => clUserData.Delete(id);

        public static DataTable GetAllUsers() => clUserData.GetManageUsersList();
    }
}