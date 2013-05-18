using System;
using System.IO;

namespace NTail.Validation
{
    public class FileMustExistValidator : IArgumentValidator
    {
        public void Vaidate(string[] args)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("\r\nCould not find the file '{0}'.", args[0]);
                throw new FileNotFoundException();
            }
                
        }
    }
}