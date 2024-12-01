using Singleton_DP;

Singleton singleton1 = Singleton.GetInstance();
singleton1.ShowMessage();

// Access the same instance again
Singleton singleton2 = Singleton.GetInstance();
singleton2.ShowMessage();

// Check if both references point to the same instance
Console.WriteLine("Are both instances the same? " + (singleton1 == singleton2));




SingletonLogger logger = SingletonLogger.GetInstance();

// Log some messages
logger.Log("Application started.");
logger.Log("Performing some operation...");

// Access the Singleton instance again (should be the same instance)
SingletonLogger anotherLogger = SingletonLogger.GetInstance();
anotherLogger.Log("Application ended.");

// Check if both references point to the same instance
Console.WriteLine("Are both Logger instances the same? " + (logger == anotherLogger));
  