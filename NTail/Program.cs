using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CommandTools
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            Console.WriteLine(fileName);

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

                    string line = string.Empty;
                    while((line = reader.ReadLine()) != null)
                        Console.WriteLine(line);

                    lastMaxOffset = reader.BaseStream.Position;
                }
            }
        }
    }
}
