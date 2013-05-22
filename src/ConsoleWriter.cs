using System;
using NTail.Helpers;

namespace NTail
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            if (line.Contains("WARN", StringComparison.OrdinalIgnoreCase))
            {
                var colour = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(line);
                Console.ForegroundColor = colour;
                return;
            } 
            
            if (line.Contains("ERROR", StringComparison.OrdinalIgnoreCase))
            {
                var colour = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(line);
                Console.ForegroundColor = colour;
                return;
            }
            
            Console.WriteLine(line);
        }
    }
}