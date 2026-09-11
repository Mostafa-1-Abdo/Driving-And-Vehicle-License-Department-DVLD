using DVLD.Data.DTOs;
using System.Data;
using System.Data.SqlClient;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clLocalLicenseApplicationData
    {
        public static clLocalLicenseApplicationDTO Find(int id)
        {
            clLocalLicenseApplicationDTO localLicenseApplicationDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select ID, ApplicationID, LicenseClassID from LocalLicenseApplications
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                localLicenseApplicationDTO = new clLocalLicenseApplicationDTO
                                {
                                    ID = (int)reader["ID"],
                                    ApplicationID = (int)reader["ApplicationID"],
                                    LicenseClassID = (int)reader["LicenseClassID"]
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                localLicenseApplicationDTO = null;
            }

            return localLicenseApplicationDTO;
        }

        public static int AddNew(clLocalLicenseApplicationDTO localLicenseApplicationDTO)
        {
            int id = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"insert into LocalLicenseApplications(ApplicationID, LicenseClassID)
                                   values
                                   (@ApplicationID, @LicenseClassID)
                                   select SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", localLicenseApplicationDTO.ApplicationID);
                        command.Parameters.AddWithValue("@LicenseClassID", localLicenseApplicationDTO.LicenseClassID);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            id = insertedID;
                        }
                    }
                }
            }
            catch
            {
            }

            return id;
        }

        public static bool Delete(int id)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"delete LocalLicenseApplications
                                   where ID = @ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

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

        public static DataTable GetManageLocalLicenseApplicationsList()
        {
            DataTable localLicenseApplicationsTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"select * from ManageLocalLicenseApplication_View";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            localLicenseApplicationsTable.Load(reader);
                        }
                    }
                }

            }
            catch
            {
            }

            return localLicenseApplicationsTable;
        }
    }
}