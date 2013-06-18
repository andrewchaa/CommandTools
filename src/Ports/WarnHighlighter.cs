using System;
using NTail.Helpers;

namespace NTail.Ports
{
    public class WarnHighlighter : IHighlighter
    {
        private readonly IHighlighter _highlighter;

        public WarnHighlighter(IHighlighter highlighter)
        {
            _highlighter = highlighter;
        }

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

            _highlighter.WriteLine(line);
        }
    }
}