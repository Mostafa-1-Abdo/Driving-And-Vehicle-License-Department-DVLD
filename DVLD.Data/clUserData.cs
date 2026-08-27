using DVLD.Data.DTOs;
using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public class clUserData
    {
        public static clUserDTO Find(int ID)
        {
            clUserDTO UserDTO = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select u.ID,u.PersonID,p.Gender,p.FirstName,p.SecondName,p.ThirdName,p.LastName,p.DateOfBirth,
                                   p.CountryID,c.Name as Country,p.NationalNumber,p.Address,p.Phone,p.Email,p.ImagePath,
                                   u.Username,u.Password,u.IsActive from Users u
                                   join People p on u.PersonID = p.ID
                                   join Countries c on p.CountryID = c.ID
                                   where u.ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                UserDTO = new clUserDTO
                                {
                                    ID = (int)Reader["ID"],
                                    PersonDTO = new clPersonDTO((int)Reader["PersonID"], (byte)Reader["Gender"],
                                    (string)Reader["FirstName"], (string)Reader["SecondName"], Reader["ThirdName"] != DBNull.Value ? (string)Reader["ThirdName"] : null, (string)Reader["LastName"],
                                   (DateTime)Reader["DateOfBirth"], new clCountryDTO((int)Reader["CountryID"], (string)Reader["Country"]), (string)Reader["NationalNumber"], (string)Reader["Address"], (string)Reader["Phone"],
                                   Reader["Email"] != DBNull.Value ? (string)Reader["Email"] : null, Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : null),
                                    Username = (string)Reader["Username"],
                                    Password = (string)Reader["Password"],
                                    IsActive = (bool)Reader["IsActive"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                UserDTO = null;
            }

            return UserDTO;
        }
        public static clUserDTO Find(string Username)
        {
            clUserDTO UserDTO = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select u.ID,u.PersonID,p.Gender,p.FirstName,p.SecondName,p.ThirdName,p.LastName,p.DateOfBirth,
                                   p.CountryID,c.Name as Country,p.NationalNumber,p.Address,p.Phone,p.Email,p.ImagePath,
                                   u.Username,u.Password,u.IsActive from Users u
                                   join People p on u.PersonID = p.ID
                                   join Countries c on p.CountryID = c.ID
                                   where u.Username = @Username";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@Username", Username);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                UserDTO = new clUserDTO
                                {
                                    ID = (int)Reader["ID"],
                                    PersonDTO = new clPersonDTO((int)Reader["PersonID"], (byte)Reader["Gender"],
                                    (string)Reader["FirstName"], (string)Reader["SecondName"], Reader["ThirdName"] != DBNull.Value ? (string)Reader["ThirdName"] : null, (string)Reader["LastName"],
                                   (DateTime)Reader["DateOfBirth"], new clCountryDTO((int)Reader["CountryID"], (string)Reader["Country"]), (string)Reader["NationalNumber"], (string)Reader["Address"], (string)Reader["Phone"],
                                   Reader["Email"] != DBNull.Value ? (string)Reader["Email"] : null, Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : null),
                                    Username = (string)Reader["Username"],
                                    Password = (string)Reader["Password"],
                                    IsActive = (bool)Reader["IsActive"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                UserDTO = null;
            }

            return UserDTO;
        }

        public static bool IsExist(int ID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select 1 from Users
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);

                        Connection.Open();

                        if (Command.ExecuteScalar() != null)
                            IsFound = true;
                    }
                }
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }
        public static bool IsExist(string Username)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select 1 from Users
                                   where Username = @Username";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@Username", Username);

                        Connection.Open();

                        if (Command.ExecuteScalar() != null)
                            IsFound = true;
                    }
                }
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }
        public static bool IsExistForPersonID(int PersonID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select 1 from Users
                                   where PersonID = @PersonID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);

                        Connection.Open();

                        if (Command.ExecuteScalar() != null)
                            IsFound = true;
                    }
                }
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }

        public static int AddNew(clUserDTO UserDTO)
        {
            int ID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"insert into Users(PersonID,Username,Password,IsActive)
                                   values
                                   (@PersonID,@Username,@Password,@IsActive)
                                   select SCOPE_IDENTITY()";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", UserDTO.PersonDTO.ID);
                        Command.Parameters.AddWithValue("@Username", UserDTO.Username);
                        Command.Parameters.AddWithValue("@Password", UserDTO.Password);
                        Command.Parameters.AddWithValue("@IsActive", UserDTO.IsActive);
                   
                        Connection.Open();

                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                        {
                            ID = InsertedID;
                        }
                    }
                }
            }
            catch
            {
            }

            return ID;
        }

        public static bool Update(clUserDTO UserDTO)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"update Users set Username = @Username, Password = @Password, IsActive = @IsActive
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", UserDTO.ID);
                        Command.Parameters.AddWithValue("@Username", UserDTO.Username);
                        Command.Parameters.AddWithValue("@Password", UserDTO.Password);
                        Command.Parameters.AddWithValue("@IsActive", UserDTO.IsActive);

                        Connection.Open();

                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }

            return RowsAffected > 0;
        }
        public static bool ChangePassword(int ID, string NewPassword)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"update Users set Password = @Password
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);
                        Command.Parameters.AddWithValue("@Password", NewPassword);

                        Connection.Open();

                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }

            return RowsAffected > 0;
        }

        public static bool Delete(int ID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"delete Users
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);

                        Connection.Open();

                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }

            return RowsAffected > 0;
        }

        public static DataTable GetManageUsersList()
        {
            DataTable UsersTable = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select * from ManageUsers_View";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            UsersTable.Load(Reader);
                        }
                    }
                }

            }
            catch
            {
            }

            return UsersTable;
        }
    }
}
