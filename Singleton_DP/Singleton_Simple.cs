using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_DP
{
    /*
     * Singleton Design Pattern is a creational pattern that ensures a class has only one instance and provides a global point of access to that instance. 
     * It is often used when exactly one instance of a class is needed to control actions, such as managing a connection to a database, logging, or a configuration manager.
     * The key characteristics:
        * Single Instance
        * Global Access
        * Lazy Initialization
     * Components:
        * Private constructor: Prevents external classes from creating instances directly.
        * Static variable: Holds the single instance of the class.
        * Public method: Provides access to the instance (commonly named GetInstance or similar).

    */
    public class Singleton
    {
        // Static variable to hold the single instance of the class
        private static Singleton _instance;

        // Locking object for thread safety
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation from outside
        private Singleton()
        {
            // Initialization code here
            Console.WriteLine("Singleton instance created.");
        }

        // Public method to provide access to the instance
        public static Singleton GetInstance()
        {
            // Check if the instance is already created
            if (_instance == null)
            {
                // Locking to ensure thread safety when creating the instance
                lock (_lock)
                {
                    // Double-check in case another thread created it in the meantime
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }

        // Example method to show functionality of the Singleton class
        public void ShowMessage()
        {
            Console.WriteLine("Hello from Singleton!");
        }
    }
}
