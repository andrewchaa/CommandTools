using System;
using NTail.Helpers;

namespace NTail.Ports
{
    public class ErrorHighlighter : IHighlighter
    {
        private readonly IHighlighter _highlighter;

        public ErrorHighlighter(IHighlighter highlighter)
        {
            _highlighter = highlighter;
        }

        public void WriteLine(string line)
        {
            if (line.Contains(" ERROR "))
            {
                var colour = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(line);
                Console.ForegroundColor = colour;
                return;
            }

            _highlighter.WriteLine(line);
        }
    }
}