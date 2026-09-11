using DVLD.Data.DTOs;
using System;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clApplicationData
    {
        public static clApplicationDTO Find(int id)
        {
            clApplicationDTO applicationDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select ID, PersonID, ApplicationTypeID, Date, PaidFees, Status, LastStatusDate, UserID from Applications
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                applicationDTO = new clApplicationDTO
                                {
                                    ID = (int)reader["ID"],
                                    PersonID = (int)reader["PersonID"],
                                    ApplicationTypeID = (int)reader["ApplicationTypeID"],
                                    Date = (DateTime)reader["Date"],
                                    PaidFees = (decimal)reader["PaidFees"],
                                    Status = (byte)reader["Status"],
                                    LastStatusDate = (DateTime)reader["LastStatusDate"],
                                    UserID = (int)reader["UserID"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                applicationDTO = null;
            }

            return applicationDTO;
        }

        public static int AddNew(clApplicationDTO applicationDTO)
        {
            int id = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"insert into Applications(PersonID, ApplicationTypeID, Date, PaidFees, Status, LastStatusDate, UserID)
                                   values
                                   (@PersonID, @ApplicationTypeID, @Date, @PaidFees, @Status, @LastStatusDate, @UserID)
                                   select SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", applicationDTO.PersonID);
                        command.Parameters.AddWithValue("@ApplicationTypeID", applicationDTO.ApplicationTypeID);
                        command.Parameters.AddWithValue("@Date", applicationDTO.Date);
                        command.Parameters.AddWithValue("@PaidFees", applicationDTO.PaidFees);
                        command.Parameters.AddWithValue("@Status", applicationDTO.Status);
                        command.Parameters.AddWithValue("@LastStatusDate", applicationDTO.LastStatusDate);
                        command.Parameters.AddWithValue("@UserID", applicationDTO.UserID);

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

        public static bool UpdateStatus(int id,byte status)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"update Applications set Status = @Status, LastStatusDate = @LastStatusDate
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Status", status);

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
                    string sql = @"delete Applications
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
    }
}