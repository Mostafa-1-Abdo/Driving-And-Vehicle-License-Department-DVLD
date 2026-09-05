using DVLD.Data.DTOs;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clApplicationTypeData
    {
        public static clApplicationTypeDTO Find(int id)
        {
            clApplicationTypeDTO applicationTypeDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select * from ApplicationTypes
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                applicationTypeDTO = new clApplicationTypeDTO
                                {
                                    ID = (int)reader["ID"],
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

        public static bool Update(clApplicationTypeDTO applicationTypeDTO)
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
                    string sql = "select * from ApplicationTypes";

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