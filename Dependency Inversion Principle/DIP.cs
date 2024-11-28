using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_Principle
{
    /*
     * Dependency Inversion Principle it's the Dependency Injection
     * High-level modules should not depend on low-level modules. Both should depend on abstractions.
     * Abstractions should not depend on details. Details should depend on abstractions.
     * Abstraction: An interface or abstract class that defines common behavior without specifying concrete details.
     * Low-level module: A module that implements specific tasks, such as data storage, network communication, etc.
     * High-level module: A module that provides core functionality or business logic.  --> It's the Controller in MVC
     * Imagine the DatabaseContext. we shouldn't expose the store to Controller, So; we need a low level class before thr High level class to deal with every thing then the high level module will only call it without adding any functionality to it
     */


    #region Old way
    /*
     * The OrderService is tightly coupled to the FileLogger class.
     * To change the logging behavior, you need to modify the OrderService class which violates DIP.
     */
    public class FileLogger_Old
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to file: {message}");
        }
    }

    // High-level module
    public class OrderService_Old
    {
        private FileLogger_Old _logger;

        public OrderService_Old()
        {
            _logger = new FileLogger_Old(); // High-level module depends directly on low-level module
        }

        public void ProcessOrder()
        {
            // Order processing logic
            _logger.Log("Order processed.");
        }
    }
    #endregion


    #region New way
    // Abstraction
    public interface ILogger
    {
        void Log(string message);
    }

    // Low-level module
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to file: {message}");
        }
    }

    // Another low-level module (could be a database logger, for example)
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to database: {message}");
        }
    }

    // High-level module  --> It's the Controller in MVC
    public class OrderService
    {
        private readonly ILogger _logger;

        // Dependency Injection (DIP): OrderService now depends on abstraction, not concrete classes
        public OrderService(ILogger logger)
        {
            _logger = logger; // The dependency is injected through the constructor
        }

        public void ProcessOrder()
        {
            // Order processing logic
            _logger.Log("Order processed.");
        }
    }
    #endregion

}
