using DVLD.Data.DTOs;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clTestTypesData
    {
        public static clTestTypeDTO Find(int ID)
        {
            clTestTypeDTO TestTypeDTO = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select * from TestTypes
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                TestTypeDTO = new clTestTypeDTO
                                {
                                    ID = (int)Reader["ID"],
                                    Title = (string)Reader["Title"],
                                    Description = (string)Reader["Description"],
                                    Fees = (decimal)Reader["Fees"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                TestTypeDTO = null;
            }

            return TestTypeDTO;
        }

        public static bool Update(clTestTypeDTO TestTypeDTO)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"update TestTypes set Title = @Title, Description = @Description, Fees = @Fees
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", TestTypeDTO.ID);
                        Command.Parameters.AddWithValue("@Title", TestTypeDTO.Title);
                        Command.Parameters.AddWithValue("@Description", TestTypeDTO.Description);
                        Command.Parameters.AddWithValue("@Fees", TestTypeDTO.Fees);

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

        public static DataTable GetAllTestTypes()
        {
            DataTable Table = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = "select * from TestTypes";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            Table.Load(Reader);
                        }
                    }
                }

            }
            catch
            {
            }

            return Table;
        }
    }
}