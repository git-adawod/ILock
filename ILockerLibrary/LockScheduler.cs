using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILockerLibrary
{
    public static class LockScheduler
    {
        public static bool Lock(LockSchedule schedule)
        {
            if (FileLocker.DenyAccess(schedule.FolderPath))
            {
                ScheduleSerialiser.Serialise(schedule);
                return true;
            }

            return false;
        }
    }

    [Serializable]
    public struct LockSchedule
    {
        public string SerialName;
        public string FolderPath;
        public DateTime TimeOfLock;
        public DateTime TimeOfUnlock;
    }
}
