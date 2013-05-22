using System;
using System.IO;

namespace NTail.Validation
{
    public class FileMustExistValidator : IArgumentValidator
    {
        public bool Vaidate(string[] args)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("\r\nCould not find the file '{0}'.", args[0]);
                return false;
            }

            return true;
        }
    }
}