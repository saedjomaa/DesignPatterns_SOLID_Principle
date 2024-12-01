using System;
using System.IO;

namespace Singleton_DP
{
    public class SingletonLogger
    {
        private static SingletonLogger _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();

        // The log file path (could be customized)
        private readonly string _logFilePath;

        // Private constructor to prevent external instantiation
        private SingletonLogger()
        {
            // Set the log file path (this could also be configurable)
            _logFilePath = "log.txt";

            // Initialize the log file or ensure it exists
            if (!File.Exists(_logFilePath))
            {
                using (StreamWriter sw = File.CreateText(_logFilePath))
                {
                    sw.WriteLine("Log file created at: " + DateTime.Now);
                }
            }
        }

        // Public method to get the instance of the Logger (Singleton)
        public static SingletonLogger GetInstance()
        {
            // Double-check lock to ensure thread safety
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonLogger();
                    }
                }
            }
            return _instance;
        }

        // Method to log a message
        public void Log(string message)
        {
            string logMessage = $"{DateTime.Now}: {message}";

            // Write the log message to the console (optional)
            Console.WriteLine(logMessage);

            // Append the log message to the log file
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}