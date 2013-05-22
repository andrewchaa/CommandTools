using System;

namespace NTail.Validation
{
    public class ArgumentMustBeProvidedValidator : IArgumentValidator
    {
        public bool Vaidate(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("\r\nUsage: ntail example.log");
                return false;
            }

            return true;
        }
    }
}