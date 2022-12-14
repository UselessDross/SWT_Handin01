using System;
using System.Collections.Generic;
using System.Text;

namespace ChargingBox.ConsoleImp
{
    public class FileLogger : ILogger
    {
        public string Filepath { get; set; }

        public FileLogger(string filepath = "KeyLog.txt")
        {
            Filepath = filepath;
        }

        public void LogLock(bool lockState, object? key, DateTime time)
        {
            byte[] text = new UTF8Encoding(true).GetBytes(GetLogString(lockState, key, time));

            if (File.Exists(Filepath))
            {
                using FileStream stream = new(Filepath, FileMode.Append, FileAccess.Write);
                stream.Write(text);     
            }
            else
            {
                using FileStream stream = File.Create(Filepath);
                stream.Write(text, 0, text.Length);
            }
        }
        public void LogLock(bool lockState, object? key) => LogLock(lockState, key, DateTime.Now);

        public static string GetLogString(bool lockState, object? key, DateTime time)
            => (lockState ? "Locked" : "Unlocked")
                + $" with key {key ?? "null"} at {time:u}";
    }
}
