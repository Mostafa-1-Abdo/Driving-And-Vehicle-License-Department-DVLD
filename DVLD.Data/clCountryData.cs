using DVLD.Data.DTOs;
using DVLD.Data;
using System;
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
            SqlConnection Connection = null;

            try
            {
                Connection = new SqlConnection(clDataAccessSettings.ConnectionString);
                Connection.Open();

                string SQL = "select * from Countries";
                SqlCommand Command = new SqlCommand(SQL, Connection);

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    Table.Load(Reader);

                Reader.Close();
            }
            catch
            {
                //Code
            }
            finally
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return Table;
        }
    }
}
