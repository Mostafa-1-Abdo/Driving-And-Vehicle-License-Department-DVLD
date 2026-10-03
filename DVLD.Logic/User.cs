using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class User
    {
        private enum enMode : byte { AddNew, Update }

        private enMode _Mode = enMode.AddNew;

        public int ID { get; private set; } = -1;
        private int _personID = -1;
        private Person _person = null;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        public int PersonID
        {
            get => _personID;
            set
            {
                if (_personID != value)
                {
                    _personID = value;
                    _person = null;
                }
            }
        }
        public Person Person
        {
            get
            {
                if (_personID != -1 && _person == null)
                {
                    _person = Person.Find(PersonID);
                }
                return _person;
            }
        }

        private UserDTO UserDTO => new UserDTO(ID, PersonID, Username, Password, IsActive);

        public User() { }
        public User(UserDTO userDTO)
        {
            _Mode = enMode.Update;

            ID = userDTO.ID;
            PersonID = userDTO.PersonID;
            Username = userDTO.Username;
            Password = userDTO.Password;
            IsActive = userDTO.IsActive;
        }

        public enum enLoginResult : byte { Success, UserNotFound, InvalidPassword, UserNotActive }
        public static (enLoginResult result, User user) Login(string username, string password)
        {
            UserDTO userDTO = UserData.Find(username);

            if (userDTO == null)
                return (enLoginResult.UserNotFound, null);

            if (password != userDTO.Password)
                return (enLoginResult.InvalidPassword, null);

            if (!userDTO.IsActive)
                return (enLoginResult.UserNotActive, null);

            return (enLoginResult.Success, new User(userDTO));
        }

        public static User Find(int id) => UserData.Find(id) is UserDTO userDTO ? new User(userDTO) : null;
        public static User Find(string username) => UserData.Find(username) is UserDTO userDTO ? new User(userDTO) : null;

        public static bool IsExist(int id) => UserData.IsExist(id);
        public static bool IsExist(string username) => UserData.IsExist(username);
        public static bool IsExistForPersonID(int personID) => UserData.IsExistByPersonID(personID);

        private bool _AddNew() => (ID = UserData.AddNew(UserDTO)) != -1;
        private bool _Update() => UserData.Update(UserDTO);
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

            if (UserData.ChangePassword(ID, newPassword))
            {
                Password = newPassword;
                return true;
            }
            return false;
        }

        public static bool Delete(int id) => UserData.Delete(id);

        public static DataTable GetAllUsers() => UserData.GetManageUsersList();
    }
}