using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class ApplicationType
    {
        public enum enApplicationType : byte
        {
            None = 0, NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5, NewInternationalDrivingLicense = 6, RetakeTest = 7
        }

        public enApplicationType ID { get; private set; } = enApplicationType.None;
        public string Title { get; set; } = string.Empty;
        public decimal Fees { get; set; } = decimal.Zero;

        public ApplicationTypeDTO ApplicationTypeDTO => new ApplicationTypeDTO((byte)ID, Title, Fees);

        public ApplicationType() { }
        public ApplicationType(ApplicationTypeDTO applicationTypeDTO)
        {
            ID = (enApplicationType)applicationTypeDTO.ID;
            Title = applicationTypeDTO.Title;
            Fees = applicationTypeDTO.Fees;
        }

        public static ApplicationType Find(enApplicationType id) => ApplicationTypeData.Find((int)id) is ApplicationTypeDTO applicationTypeDTO ? new ApplicationType(applicationTypeDTO) : null;

        private bool _Update() => ApplicationTypeData.Update(ApplicationTypeDTO);
        public bool Save() => _Update();

        static public DataTable GetAllApplicationTypes() => ApplicationTypeData.GetAllApplicationTypes();
    }
}