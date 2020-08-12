using System;

namespace ArhGzip_Another.Action
{
    public interface IWriter : IDisposable
    {
        int TotalBlockWrite { get; }
        void Write(Block processedBlock);
    }
}

