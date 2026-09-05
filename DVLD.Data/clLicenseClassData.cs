using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clLicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable licenseClassesTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "select * from LicenseClasses";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            licenseClassesTable.Load(reader);
                        }
                    }
                }
            }
            catch
            {
            }

            return licenseClassesTable;
        }
    }
}