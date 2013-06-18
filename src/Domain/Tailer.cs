using System.IO;
using System.Threading;
using NTail.Ports;

namespace NTail.Domain
{
    public class Tailer : ITailer
    {
        private readonly IHighlighter _highlighter;
        private readonly ITailState _tailState;

        public Tailer(IHighlighter highlighter, ITailState tailState)
        {
            _highlighter = highlighter;
            _tailState = tailState;
        }

        public void Tail(string fileName)
        {
            using (var reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                long lastMaxOffset = reader.BaseStream.Length;

                while (true)
                {
                    Thread.Sleep(100);

                    if (reader.BaseStream.Length == lastMaxOffset)
                        continue;

                    reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                    if (!_tailState.IsPaused)
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            _highlighter.WriteLine(line);
                    }

                    lastMaxOffset = reader.BaseStream.Position;
                }
            }
        }
    }
}