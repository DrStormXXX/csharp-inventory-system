using System;

namespace myConsoleHelper
{
    public static class ConsoleHelper
    {
        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Success: {message}");
            Console.ResetColor();
        }
        
        
    }
}