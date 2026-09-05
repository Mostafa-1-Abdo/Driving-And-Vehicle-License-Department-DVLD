using DVLD.Data;
using DVLD.Data.DTOs;
using System.Data;

namespace DVLD.Logic
{
    public class clApplicationType
    {
        public enum enApplicationType : byte { None =0 , NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense=4, ReleaseDetainedDrivingLicense=5, NewInternationalDrivingLicense=6, RetakeTest=7}

        public enApplicationType ID { get; private set; } = enApplicationType.None;
        public string Title { get; set; } = string.Empty;
        public decimal Fees { get; set; } = decimal.Zero;

        public clApplicationTypeDTO ApplicationTypeDTO => new clApplicationTypeDTO((int)ID, Title, Fees);

        public clApplicationType() { }
        public clApplicationType(clApplicationTypeDTO applicationTypeDTO)
        {
            ID = (enApplicationType)applicationTypeDTO.ID;
            Title = applicationTypeDTO.Title;
            Fees = applicationTypeDTO.Fees;
        }

        public static clApplicationType Find(enApplicationType id) => clApplicationTypeData.Find((int)id) is clApplicationTypeDTO ApplicationTypeDTO ? new clApplicationType(ApplicationTypeDTO) : null;

        private bool _Update() => clApplicationTypeData.Update(ApplicationTypeDTO);
        public bool Save() => _Update();

        static public DataTable GetAllApplicationTypes() => clApplicationTypeData.GetAllApplicationTypes();
    }
}