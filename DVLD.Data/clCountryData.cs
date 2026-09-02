using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clCountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable countriesTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "select * from Countries";

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