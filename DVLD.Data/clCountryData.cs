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
        public static clCountryDTO FindCountry(int ID)
        {
            clCountryDTO CountryDTO = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select * from Countries 
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                CountryDTO = new clCountryDTO
                                {
                                    ID = (int)Reader["ID"],
                                    Name = (string)Reader["Name"]
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
        public static clCountryDTO FindCountry(string Name)
        {
            clCountryDTO CountryDTO = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select * from Countries 
                                   where Name = @Name";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@Name", Name);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                CountryDTO = new clCountryDTO
                                {
                                    ID = (int)Reader["ID"],
                                    Name = (string)Reader["Name"]
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
