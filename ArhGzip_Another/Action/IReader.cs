using System;

namespace ArhGzip_Another.Action
{
    public interface IReader : IDisposable
    {
        int TotalBlockRead { get; }
        bool TryRead(out Block block);
    }
}
