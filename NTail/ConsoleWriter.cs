using System;
using NTail.Helpers;

namespace NTail
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            if (line.Contains("WARN", StringComparison.OrdinalIgnoreCase))
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (line.Contains("ERROR", StringComparison.OrdinalIgnoreCase))
                Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }
}