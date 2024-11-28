

using Dependency_Inversion_Principle;
using System;

// Dependency Injection: Passing concrete logger to OrderService
ILogger logger = new FileLogger();
OrderService orderService = new OrderService(logger);

orderService.ProcessOrder();  // Logs to file

// Changing the logger without modifying OrderService
logger = new DatabaseLogger();
orderService = new OrderService(logger);
orderService.ProcessOrder();  // Logs to database

