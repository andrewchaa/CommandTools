namespace NTail.Domain
{
    public class TailState : ITailState
    {
        public bool IsPaused { get; set; }
        public bool IsMarked { get; set; }
    }
}