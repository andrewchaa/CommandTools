using System;
using System.IO;
using System.Threading;
using NTail.Validation;
using Ninject;

namespace NTail
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new NTailModule());
            var validators = kernel.GetAll<IArgumentValidator>();
            
            foreach (var validator in validators)
            {
                try
                {
                    validator.Vaidate(args);
                }
                catch (Exception ex)
                {
                    if (ex is NoArgumentException || ex is FileNotFoundException)
                    {
                        return;
                    }

                    throw;
                }
            }
            
            string fileName = args[0];
            using (var reader = new StreamReader(
                new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                )
            {
                long lastMaxOffset = reader.BaseStream.Length;

                while (true)
                {
                    Thread.Sleep(100);
                    
                    if (reader.BaseStream.Length == lastMaxOffset)
                        continue;

                    reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                    int i;
                    while((i = reader.Read()) > 0)
                        Console.Write((char)i);

                    lastMaxOffset = reader.BaseStream.Position;
                }
            }
        }
    }
}
