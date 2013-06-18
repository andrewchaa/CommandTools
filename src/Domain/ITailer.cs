namespace NTail.Domain
{
    public interface ITailer
    {
        void Tail(string fileName);
    }
}