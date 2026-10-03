using DVLD.Data.DTOs;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class TestTypeData
    {
        public static TestTypeDTO Find(int id)
        {
            TestTypeDTO testTypeDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select ID, Title, Description, Fees from TestTypes
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                testTypeDTO = new TestTypeDTO
                                {
                                    ID = (byte)reader["ID"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    Fees = (decimal)reader["Fees"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                testTypeDTO = null;
            }

            return testTypeDTO;
        }

        public static bool Update(TestTypeDTO testTypeDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"update TestTypes set Title = @Title, Description = @Description, Fees = @Fees
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", testTypeDTO.ID);
                        command.Parameters.AddWithValue("@Title", testTypeDTO.Title);
                        command.Parameters.AddWithValue("@Description", testTypeDTO.Description);
                        command.Parameters.AddWithValue("@Fees", testTypeDTO.Fees);

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

        public static DataTable GetAllTestTypes()
        {
            DataTable testTypesTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "select ID, Title, Description, Fees from TestTypes";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            testTypesTable.Load(reader);
                        }
                    }
                }
            }
            catch
            {
            }

            return testTypesTable;
        }
    }
}