using DVLD.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DVLD.Data.clDataAccessSettings;

namespace DVLD.Data
{
    public static class clPersonData
    {
        public static clPersonDTO Find(int ID)
        {
            clPersonDTO PersonDTO = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select * from People
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                PersonDTO = new clPersonDTO
                                {
                                    ID = (int)Reader["ID"],
                                    Gender = (byte)Reader["Gender"],
                                    FirstName = (string)Reader["FirstName"],
                                    SecondName = (string)Reader["SecondName"],
                                    ThirdName = Reader["ThirdName"] != DBNull.Value ? (string)Reader["ThirdName"] : null,
                                    LastName = (string)Reader["LastName"],
                                    DateOfBirth = (DateTime)Reader["DateOfBirth"],
                                    CountryID = (int)Reader["CountryID"],
                                    NationalNumber = (string)Reader["NationalNumber"],
                                    Address = (string)Reader["Address"],
                                    Phone = (string)Reader["Phone"],
                                    Email = Reader["Email"] != DBNull.Value ? (string)Reader["Email"] : null,
                                    ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : null,
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                PersonDTO = null;
            }

            return PersonDTO;
        }

        public static int AddNew(clPersonDTO PersonDTO)
        {
            int ID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"insert into People(Gender,FirstName,SecondName,ThirdName,LastName,DateOfBirth,CountryID,NationalNumber,Address,Phone,Email,ImagePath)
                                   values
                                   (@Gender,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@CountryID,@NationalNumber,@Address,@Phone,@Email,@ImagePath)
                                   select SCOPE_IDENTITY()";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@Gender", PersonDTO.Gender);
                        Command.Parameters.AddWithValue("@FirstName", PersonDTO.FirstName);
                        Command.Parameters.AddWithValue("@SecondName", PersonDTO.SecondName);
                        Command.Parameters.AddWithValue("@ThirdName", !string.IsNullOrEmpty(PersonDTO.ThirdName) ? (object)PersonDTO.ThirdName : DBNull.Value);
                        Command.Parameters.AddWithValue("@LastName", PersonDTO.LastName);
                        Command.Parameters.AddWithValue("@DateOfBirth", PersonDTO.DateOfBirth.Date);
                        Command.Parameters.AddWithValue("@CountryID", PersonDTO.CountryID);
                        Command.Parameters.AddWithValue("@NationalNumber", PersonDTO.NationalNumber);
                        Command.Parameters.AddWithValue("@Address", PersonDTO.Address);
                        Command.Parameters.AddWithValue("@Phone", PersonDTO.Phone);
                        Command.Parameters.AddWithValue("@Email", !string.IsNullOrEmpty(PersonDTO.Email) ? (object)PersonDTO.Email : DBNull.Value);
                        Command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrEmpty(PersonDTO.ImagePath) ? (object)PersonDTO.ImagePath : DBNull.Value);

                        Connection.Open();

                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                        {
                            ID = InsertedID;
                        }
                    }
                }
            }
            catch
            {
            }

            return ID;
        }

        public static bool Update(clPersonDTO PersonDTO)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"update People set Gender = @Gender, FirstName = @FirstName, SecondName = @SecondName,ThirdName = @ThirdName, LastName = @LastName, DateOfBirth = @DateOfBirth, CountryID = @CountryID, NationalNumber = @NationalNumber, Address = @Address, Phone = @Phone, Email = @Email, ImagePath = @ImagePath
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", PersonDTO.ID);
                        Command.Parameters.AddWithValue("@Gender", PersonDTO.Gender);
                        Command.Parameters.AddWithValue("@FirstName", PersonDTO.FirstName);
                        Command.Parameters.AddWithValue("@SecondName", PersonDTO.SecondName);
                        Command.Parameters.AddWithValue("@ThirdName", !string.IsNullOrEmpty(PersonDTO.ThirdName) ? (object)PersonDTO.ThirdName : DBNull.Value);
                        Command.Parameters.AddWithValue("@LastName", PersonDTO.LastName);
                        Command.Parameters.AddWithValue("@DateOfBirth", PersonDTO.DateOfBirth.Date);
                        Command.Parameters.AddWithValue("@CountryID", PersonDTO.CountryID);
                        Command.Parameters.AddWithValue("@NationalNumber", PersonDTO.NationalNumber);
                        Command.Parameters.AddWithValue("@Address", PersonDTO.Address);
                        Command.Parameters.AddWithValue("@Phone", PersonDTO.Phone);
                        Command.Parameters.AddWithValue("@Email", !string.IsNullOrEmpty(PersonDTO.Email) ? (object)PersonDTO.Email : DBNull.Value);
                        Command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrEmpty(PersonDTO.ImagePath) ? (object)PersonDTO.ImagePath : DBNull.Value);

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

        public static bool Delete(int ID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"delete People
                                   where ID = @ID";

                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Command.Parameters.AddWithValue("@ID", ID);

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

        public static DataTable GetAllPeople()
        {
            DataTable PeopleTable = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    string SQL = @"select p.ID,Gender = 
                                    case
                                   	    when p.Gender = 0 then 'Male'
                                   	    when p.Gender = 1 then 'Female'
                                    end,
                                   p.FirstName,p.SecondName,p.ThirdName,p.LastName,p.DateOfBirth,Country = c.Name,p.NationalNumber,p.Address,p.Phone,p.Email,p.ImagePath from People p
                                   join Countries c on p.CountryID = c.ID";


                    using (SqlCommand Command = new SqlCommand(SQL, Connection))
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            PeopleTable.Load(Reader);
                        }
                    }
                }

            }
            catch
            {

            }

            return PeopleTable;
        }
        //public static DataTable FindAccording(string ColumnName, string Value, bool IsExactMatch)
        //{
        //    DataTable PeopleTable = new DataTable();
        //    string Operator = IsExactMatch ? "=" : "like";

        //    try
        //    {
        //        using (SqlConnection Connection = new SqlConnection(ConnectionString))
        //        {
        //            string SQL = $@"select p.ID,Gender = 
        //                            case
        //                           	    when p.Gender = 0 then 'Male'
        //                           	    when p.Gender = 1 then 'Female'
        //                            end,
        //                           p.FirstName,p.SecondName,p.ThirdName,p.LastName,p.DateOfBirth,Country = c.Name,p.NationalNumber,p.Address,p.Phone,p.Email,p.ImagePath from People p
        //                           join Countries c on p.CountryID = c.ID
        //                           where {ColumnName} {Operator} @Value";

        //            using (SqlCommand Command = new SqlCommand(SQL, Connection))
        //            {
        //                if (ColumnName == "p.ID")
        //                    Command.Parameters.AddWithValue("@Value", int.TryParse(Value, out int ID) ? ID : -1);
        //                else
        //                    Command.Parameters.AddWithValue("@Value", IsExactMatch ? Value : $"%{Value}%");


        //                Connection.Open();

        //                using (SqlDataReader Reader = Command.ExecuteReader())
        //                {
        //                    PeopleTable.Load(Reader);
        //                }
        //            }
        //        }

        //    }
        //    catch
        //    {

        //    }

        //    return PeopleTable;

        //}
    }
}
