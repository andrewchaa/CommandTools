using System;
using NTail.Helpers;

namespace NTail.Ports
{
    public class KeywordHighlighter : IHighlighter
    {
        private readonly IHighlighter _highlighter;
        private readonly string _keyword;

        public KeywordHighlighter(IHighlighter highlighter, string keyword)
        {
            _highlighter = highlighter;
            _keyword = keyword;
        }

        public void WriteLine(string line)
        {
            if (line.Contains(_keyword, StringComparison.OrdinalIgnoreCase))
            {
                var colour = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(line);
                Console.ForegroundColor = colour;
                return;
            }
 
            _highlighter.WriteLine(line);
        }
    }
}