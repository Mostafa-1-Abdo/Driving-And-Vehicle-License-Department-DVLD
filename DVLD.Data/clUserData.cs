using DVLD.Data.DTOs;
using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public class clUserData
    {
        public static clUserDTO Find(int id)
        {
            clUserDTO userDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select u.ID,u.PersonID,p.Gender,p.FirstName,p.SecondName,p.ThirdName,p.LastName,p.DateOfBirth,
                                   p.CountryID,c.Name as Country,p.NationalNumber,p.Address,p.Phone,p.Email,p.ImagePath,
                                   u.Username,u.Password,u.IsActive from Users u
                                   join People p on u.PersonID = p.ID
                                   join Countries c on p.CountryID = c.ID
                                   where u.ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userDTO = new clUserDTO
                                {
                                    ID = (int)reader["ID"],
                                    PersonID = (int)reader["PersonID"],
                                    Gender = (byte)reader["Gender"],
                                    FirstName = (string)reader["FirstName"],
                                    SecondName = (string)reader["SecondName"],
                                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : null,
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    CountryID = (int)reader["CountryID"],
                                    CountryName = (string)reader["Country"],
                                    NationalNumber = (string)reader["NationalNumber"],
                                    Address = (string)reader["Address"],
                                    Phone = (string)reader["Phone"],
                                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null,
                                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null,
                                    Username = (string)reader["Username"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                userDTO = null;
            }

            return userDTO;
        }
        public static clUserDTO Find(string username)
        {
            clUserDTO userDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select u.ID,u.PersonID,p.Gender,p.FirstName,p.SecondName,p.ThirdName,p.LastName,p.DateOfBirth,
                                   p.CountryID,c.Name as Country,p.NationalNumber,p.Address,p.Phone,p.Email,p.ImagePath,
                                   u.Username,u.Password,u.IsActive from Users u
                                   join People p on u.PersonID = p.ID
                                   join Countries c on p.CountryID = c.ID
                                   where u.Username = @Username";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userDTO = new clUserDTO
                                {
                                    ID = (int)reader["ID"],
                                    PersonID = (int)reader["PersonID"],
                                    Gender = (byte)reader["Gender"],
                                    FirstName = (string)reader["FirstName"],
                                    SecondName = (string)reader["SecondName"],
                                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : null,
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    CountryID = (int)reader["CountryID"],
                                    CountryName = (string)reader["Country"],
                                    NationalNumber = (string)reader["NationalNumber"],
                                    Address = (string)reader["Address"],
                                    Phone = (string)reader["Phone"],
                                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null,
                                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null,
                                    Username = (string)reader["Username"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                userDTO = null;
            }

            return userDTO;
        }

        public static bool IsExist(int id)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select 1 from Users
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        if (command.ExecuteScalar() != null)
                            isFound = true;
                    }
                }
            }
            catch
            {
                isFound = false;
            }

            return isFound;
        }
        public static bool IsExist(string username)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select 1 from Users
                                   where Username = @Username";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        connection.Open();

                        if (command.ExecuteScalar() != null)
                            isFound = true;
                    }
                }
            }
            catch
            {
                isFound = false;
            }

            return isFound;
        }
        public static bool IsExistForPersonID(int personID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select 1 from Users
                                   where PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", personID);

                        connection.Open();

                        if (command.ExecuteScalar() != null)
                            isFound = true;
                    }
                }
            }
            catch
            {
                isFound = false;
            }

            return isFound;
        }

        public static int AddNew(clUserDTO userDTO)
        {
            int id = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"insert into Users(PersonID,Username,Password,IsActive)
                                   values
                                   (@PersonID,@Username,@Password,@IsActive)
                                   select SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", userDTO.PersonID);
                        command.Parameters.AddWithValue("@Username", userDTO.Username);
                        command.Parameters.AddWithValue("@Password", userDTO.Password);
                        command.Parameters.AddWithValue("@IsActive", userDTO.IsActive);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            id = insertedID;
                        }
                    }
                }
            }
            catch
            {
            }

            return id;
        }

        public static bool Update(clUserDTO userDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"update Users set Username = @Username, Password = @Password, IsActive = @IsActive
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", userDTO.ID);
                        command.Parameters.AddWithValue("@Username", userDTO.Username);
                        command.Parameters.AddWithValue("@Password", userDTO.Password);
                        command.Parameters.AddWithValue("@IsActive", userDTO.IsActive);

                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }

            return rowsAffected > 0;
        }
        public static bool ChangePassword(int id, string newPassword)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"update Users set Password = @Password
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Password", newPassword);

                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }

            return rowsAffected > 0;
        }

        public static bool Delete(int id)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"delete Users
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }

            return rowsAffected > 0;
        }

        public static DataTable GetManageUsersList()
        {
            DataTable usersTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select * from ManageUsers_View";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            usersTable.Load(reader);
                        }
                    }
                }

            }
            catch
            {
            }

            return usersTable;
        }
    }
}