﻿using System;
using System.IO;
using System.Threading;

namespace NTail
{
    public class Tailer : ITailer
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ITailState _tailState;

        public Tailer(IConsoleWriter consoleWriter, ITailState tailState)
        {
            _consoleWriter = consoleWriter;
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
                            _consoleWriter.WriteLine(line);
                    }

                    lastMaxOffset = reader.BaseStream.Position;
                }
            }
        }
    }
}