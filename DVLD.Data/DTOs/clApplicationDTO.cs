using System;

namespace DVLD.Data.DTOs
{
    public class clApplicationDTO
    {
        public int ID { get; set; } = -1;
        public int PersonID { get; set; } = -1;
        public int ApplicationTypeID { get; set; } = -1;
        public DateTime Date { get; set; } = DateTime.MinValue;
        public decimal PaidFees { get; set; } = decimal.Zero;
        public byte Status { get; set; } = 0;
        public DateTime LastStatusDate { get; set; } = DateTime.MinValue;
        public int UserID { get; set; } = -1;

        public clApplicationDTO() { }
        public clApplicationDTO(int id, int personID,int applicationTypeID,DateTime date,decimal paidFees, byte status,DateTime lastStatusDate,int userID )
        {
            ID = id;
            PersonID = personID;
            ApplicationTypeID = applicationTypeID;
            Date = date;
            PaidFees = paidFees;
            Status = status;
            LastStatusDate = lastStatusDate;
            UserID = userID;
        }
    }
}