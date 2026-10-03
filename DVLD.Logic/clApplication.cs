using DVLD.Data;
using DVLD.Data.DTOs;
using System;
using System.Data;

namespace DVLD.Logic
{
    public class clApplication
    {
        private enum enMode : byte { AddNew, Update }
        public enum enStatus : byte {  New = 1, Cancelled = 2, Completed = 3 }

        private enMode _Mode = enMode.AddNew;

        public int ApplicationID { get; set; } = -1;
        public int PersonID { get; set; } = -1;
        public int ApplicationTypeID { get; set; } = -1;
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal PaidFees { get; set; } = decimal.Zero;
        public enStatus Status { get; set; } = enStatus.New;
        public DateTime LastStatusDate { get; set; } = DateTime.Now;
        public int UserID { get; set; } = -1;

        public Person Person => PersonID != -1 ? Person.Find(PersonID) : null;

        private clApplicationDTO ApplicationDTO => new clApplicationDTO(ApplicationID, PersonID, ApplicationTypeID, Date, PaidFees, (byte)Status, LastStatusDate, UserID);

        public clApplication() { }
        public clApplication(clApplicationDTO applicationDTO)
        {
            _Mode = enMode.Update;

            ApplicationID = applicationDTO.ID;
            PersonID = applicationDTO.PersonID;
            ApplicationTypeID = applicationDTO.ApplicationTypeID;
            Date = applicationDTO.Date;
            PaidFees = applicationDTO.PaidFees;
            Status = (enStatus)applicationDTO.Status;
            LastStatusDate = applicationDTO.LastStatusDate;
            UserID = applicationDTO.UserID;
        }

        public static clApplication Find(int id) => clApplicationData.Find(id) is clApplicationDTO ApplicationDTO ? new clApplication(ApplicationDTO) : null;

        private bool _AddNew() => (ApplicationID = clApplicationData.AddNew(ApplicationDTO)) != -1;
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                default:
                    return false;
            }
        }

        public bool Cancel()
        {
            if (clApplicationData.UpdateStatus(ApplicationID, (byte)enStatus.Cancelled))
            {
                Status = enStatus.Cancelled;
                LastStatusDate = DateTime.Now;
                return true;
            }
            return false;
        }
        public bool Complete()
        {
            if (clApplicationData.UpdateStatus(ApplicationID, (byte)enStatus.Completed))
            {
                Status = enStatus.Completed;
                LastStatusDate = DateTime.Now;
                return true;
            }
            return false;
        }

        public static bool Delete(int id) => clApplicationData.Delete(id);
    }
}