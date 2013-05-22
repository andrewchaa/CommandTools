using System;

namespace NTail
{
    public class KeyHandler : IKeyHandler
    {
        private readonly ITailState _tailState;

        public KeyHandler(ITailState tailState)
        {
            _tailState = tailState;
        }

        public void Handle()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if ((key.Modifiers & ConsoleModifiers.Control) != 0 && key.Key == ConsoleKey.N)
                    Console.Clear();

                if (key.Key == ConsoleKey.Spacebar)
                {
                    _tailState.IsPaused = !_tailState.IsPaused;
                    Console.ForegroundColor  = ConsoleColor.Green;
                    Console.WriteLine("\r\n      --- Paused ---\r\n");
                    Console.ResetColor();
                }
                    
            }
        }
    }
}