namespace NTail
{
    public interface ITailState
    {
        bool IsPaused { get; set; }
        bool IsMarked { get; set; }
    }
}