namespace DVLD.Data.DTOs
{
    public class clTestDTO
    {
        public int ID { get; set; } = -1;
        public int AppointmentID { get; set; } = -1;
        public bool Result { get; set; } = false;
        public string Notes { get; set; } = null;
        public int UserID { get; set; } = -1;

        public clTestDTO() { }
        public clTestDTO(int id,int appointmentID,bool result,string notes,int userID)
        {
            ID = id;
            AppointmentID = appointmentID;
            Result = result;
            Notes = notes;
            UserID = userID;
        }
    }
}