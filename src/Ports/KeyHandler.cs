using System;
using NTail.Domain;

namespace NTail.Ports
{
    public class KeyHandler : IKeyHandler
    {
        private readonly ITailState _tailState;
        private ConsoleColor _originalBackgrounColour;

        public KeyHandler(ITailState tailState)
        {
            _tailState = tailState;
            _originalBackgrounColour = Console.BackgroundColor;
        }

        public void Handle()
        {
            while (true)
            {
                var input = Console.ReadKey(true);
                if ((input.Modifiers & ConsoleModifiers.Control) != 0 && input.Key == ConsoleKey.N)
                    Console.Clear();

                if (input.Key == ConsoleKey.Spacebar)
                {
                    _tailState.IsPaused = !_tailState.IsPaused;

                    var colour = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (_tailState.IsPaused)
                        Console.WriteLine("\r\n      --- Paused ---\r\n");
                    else
                        Console.WriteLine("\r\n      --- Tailing ... ---\r\n");
                    Console.ForegroundColor = colour;
                }

                if (input.Key == ConsoleKey.M && (input.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    _tailState.IsMarked = !_tailState.IsMarked;
                    Console.BackgroundColor = _tailState.IsMarked ? ConsoleColor.Blue: _originalBackgrounColour;
                }
                    
            }
        }
    }
}