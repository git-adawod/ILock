using System;
using System.Security.AccessControl;
using System.IO;

namespace ILockerLibrary
{
    public static class FileLocker
    {
        private static FileSystemAccessRule _fileSystemAccessRule = new FileSystemAccessRule(
                    Environment.UserName,
                    FileSystemRights.FullControl,
                    AccessControlType.Deny
                    );

        private static DirectorySecurity _directorySecurity = new DirectorySecurity();

        public static bool DenyAccess(string folderPath)
        {
            try
            {
                _directorySecurity.AddAccessRule(_fileSystemAccessRule);
                Directory.SetAccessControl(folderPath, _directorySecurity);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GainAcess(string folderPath)
        {
            try
            {
                _directorySecurity.RemoveAccessRule(_fileSystemAccessRule);
                Directory.SetAccessControl(folderPath, _directorySecurity);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
