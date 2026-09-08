namespace DVLD.Data.DTOs
{
    public class clLocalLicenseApplicationDTO
    {
        public int ID { get; set; } = -1;
        public int ApplicationID { get; set; } = -1;
        public int LicenseClassID { get; set; } = -1;

        public clLocalLicenseApplicationDTO() { }
        public clLocalLicenseApplicationDTO(int id, int applicationID, int licenseClassID)
        {
            ID = id;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }
    }
}