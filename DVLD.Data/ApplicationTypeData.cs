using DVLD.Data.DTOs;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class ApplicationTypeData
    {
        public static ApplicationTypeDTO Find(int id)
        {
            ApplicationTypeDTO applicationTypeDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select ID, Title, Fees from ApplicationTypes
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                applicationTypeDTO = new ApplicationTypeDTO
                                {
                                    ID = (byte)reader["ID"],
                                    Title = (string)reader["Title"],
                                    Fees = (decimal)reader["Fees"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                applicationTypeDTO = null;
            }

            return applicationTypeDTO;
        }

        public static bool Update(ApplicationTypeDTO applicationTypeDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"update ApplicationTypes set Title = @Title, Fees = @Fees
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", applicationTypeDTO.ID);
                        command.Parameters.AddWithValue("@Title", applicationTypeDTO.Title);
                        command.Parameters.AddWithValue("@Fees", applicationTypeDTO.Fees);

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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable applicationTypesTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "select ID, Title, Fees from ApplicationTypes";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            applicationTypesTable.Load(reader);
                        }
                    }
                }
            }
            catch
            {
            }

            return applicationTypesTable;
        }
    }
}