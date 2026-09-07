using DVLD.Data.DTOs;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clCountryData
    {
        public static clCountryDTO Find(int id)
        {
            clCountryDTO CountryDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select ID, Name from Countries
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CountryDTO = new clCountryDTO
                                {
                                    ID = (int)reader["ID"],
                                    Name = (string)reader["Name"],
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                CountryDTO = null;
            }

            return CountryDTO;
        }

        public static DataTable GetAllCountries()
        {
            DataTable countriesTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "select ID, Name from Countries";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            countriesTable.Load(reader);
                        }
                    }
                }
            }
            catch
            {
            }

            return countriesTable;
        }
    }
}