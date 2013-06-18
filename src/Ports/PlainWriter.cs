using System;

namespace NTail.Ports
{
    public class PlainWriter : IHighlighter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}