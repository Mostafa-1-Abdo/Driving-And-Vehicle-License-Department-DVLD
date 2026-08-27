using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clCountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable Table = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = "select * from Countries";

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
