using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ILockerLibrary
{
    public static class ScheduleSerialiser
    {
        private static string SerialObjectsDirectory =
            Environment.CurrentDirectory
            .Substring(0, Environment.CurrentDirectory.LastIndexOf("ILockerLibrary"))
            + "SerialObjects";

        public static bool Serialise(LockSchedule schedule)
        {
            try
            {
                Stream stream = new FileStream(
                        $@"{SerialObjectsDirectory}\{schedule.SerialName}",
                        FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, schedule);
                stream.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<LockSchedule> Deserialise()
        {
            string[] files = Directory.GetFiles(SerialObjectsDirectory);
            List<LockSchedule> schedules = new List<LockSchedule>();

            foreach(string file in files)
            {
                Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();

                schedules.Add((LockSchedule) formatter.Deserialize(stream));
                stream.Close();
            }

            return schedules;
        }
    }
}
