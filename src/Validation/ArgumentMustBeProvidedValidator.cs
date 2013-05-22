using System;

namespace NTail.Validation
{
    public class ArgumentMustBeProvidedValidator : IArgumentValidator
    {
        public bool Vaidate(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\nUsage\r\n");
                Console.WriteLine("ntail example.log");
                Console.WriteLine("SPACE to pause");
                Console.WriteLine("CTRL + N to clear the console");
                Console.WriteLine("CTRL + M to mark the following output");
                Console.ResetColor();
                return false;
            }

            return true;
        }
    }
}