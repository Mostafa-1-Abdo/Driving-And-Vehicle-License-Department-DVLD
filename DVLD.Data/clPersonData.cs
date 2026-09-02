using DVLD.Data.DTOs;
using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clPersonData
    {
        public static clPersonDTO Find(int id)
        {
            clPersonDTO personDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select p.*, c.Name as Country from People p
                                   join Countries c on p.CountryID = c.ID
                                   where p.ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personDTO = new clPersonDTO
                                {
                                    ID = (int)reader["ID"],
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
                                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                personDTO = null;
            }

            return personDTO;
        }

        public static clPersonDTO Find(string nationalNumber)
        {
            clPersonDTO personDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select p.*, c.Name as Country from People p
                                   join Countries c on p.CountryID = c.ID
                                   where p.NationalNumber = @NationalNumber";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNumber", nationalNumber);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personDTO = new clPersonDTO
                                {
                                    ID = (int)reader["ID"],
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
                                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                personDTO = null;
            }

            return personDTO;
        }

        public static bool IsExist(int id)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select 1 from People
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

        public static bool IsExist(string nationalNumber)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select 1 from People
                                   where NationalNumber = @NationalNumber";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNumber", nationalNumber);

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

        public static int AddNew(clPersonDTO personDTO)
        {
            int id = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"insert into People(Gender, FirstName, SecondName, ThirdName, LastName, DateOfBirth, CountryID, NationalNumber, Address, Phone, Email, ImagePath)
                                   values
                                   (@Gender, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @CountryID, @NationalNumber, @Address, @Phone, @Email, @ImagePath)
                                   select SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Gender", personDTO.Gender);
                        command.Parameters.AddWithValue("@FirstName", personDTO.FirstName);
                        command.Parameters.AddWithValue("@SecondName", personDTO.SecondName);
                        command.Parameters.AddWithValue("@ThirdName", !string.IsNullOrEmpty(personDTO.ThirdName) ? (object)personDTO.ThirdName : DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", personDTO.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", personDTO.DateOfBirth.Date);
                        command.Parameters.AddWithValue("@CountryID", personDTO.CountryID);
                        command.Parameters.AddWithValue("@NationalNumber", personDTO.NationalNumber);
                        command.Parameters.AddWithValue("@Address", personDTO.Address);
                        command.Parameters.AddWithValue("@Phone", personDTO.Phone);
                        command.Parameters.AddWithValue("@Email", !string.IsNullOrEmpty(personDTO.Email) ? (object)personDTO.Email : DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrEmpty(personDTO.ImagePath) ? (object)personDTO.ImagePath : DBNull.Value);

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

        public static bool Update(clPersonDTO personDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"update People set Gender = @Gender, FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName, DateOfBirth = @DateOfBirth, CountryID = @CountryID, NationalNumber = @NationalNumber, Address = @Address, Phone = @Phone, Email = @Email, ImagePath = @ImagePath
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", personDTO.ID);
                        command.Parameters.AddWithValue("@Gender", personDTO.Gender);
                        command.Parameters.AddWithValue("@FirstName", personDTO.FirstName);
                        command.Parameters.AddWithValue("@SecondName", personDTO.SecondName);
                        command.Parameters.AddWithValue("@ThirdName", !string.IsNullOrEmpty(personDTO.ThirdName) ? (object)personDTO.ThirdName : DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", personDTO.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", personDTO.DateOfBirth.Date);
                        command.Parameters.AddWithValue("@CountryID", personDTO.CountryID);
                        command.Parameters.AddWithValue("@NationalNumber", personDTO.NationalNumber);
                        command.Parameters.AddWithValue("@Address", personDTO.Address);
                        command.Parameters.AddWithValue("@Phone", personDTO.Phone);
                        command.Parameters.AddWithValue("@Email", !string.IsNullOrEmpty(personDTO.Email) ? (object)personDTO.Email : DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrEmpty(personDTO.ImagePath) ? (object)personDTO.ImagePath : DBNull.Value);

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
                    string sql = @"delete People
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

        public static DataTable GetManagePeopleList()
        {
            DataTable peopleTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select * from ManagePeople_View";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            peopleTable.Load(reader);
                        }
                    }
                }
            }
            catch
            {
            }

            return peopleTable;
        }
    }
}