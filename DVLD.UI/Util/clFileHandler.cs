using System;
using System.IO;

namespace DVLD.UI.Util
{
    public static class clFileHandler
    {
        public static bool HandleFileCopy(ref string SourcePath)
        {
            if (string.IsNullOrEmpty(SourcePath) || !File.Exists(SourcePath))
                return false;

            string DestinationFolder = @"D:\DVLD-People-Images\";
            if (!Directory.Exists(DestinationFolder))
                Directory.CreateDirectory(DestinationFolder);

            string Extension = Path.GetExtension(SourcePath);
            string NewFileName = Guid.NewGuid().ToString() + Extension;
            string DestinationFile = Path.Combine(DestinationFolder, NewFileName);

            try
            {
                File.Copy(SourcePath, DestinationFile, true);
                SourcePath = DestinationFile;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool HandleFileDelete(string Path)
        {
            if (string.IsNullOrEmpty(Path) || !File.Exists(Path))
                return false;

            try
            {
                File.Delete(Path);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool HandleImages(string OldImagePath, ref string NewImagePath)
        {
            if (OldImagePath == NewImagePath)
                return true;

            if (string.IsNullOrEmpty(NewImagePath))
            {
                OldImagePath = string.Empty;
                return true;
            }

            return clFileHandler.HandleFileCopy(ref NewImagePath);
        }
    }
}
