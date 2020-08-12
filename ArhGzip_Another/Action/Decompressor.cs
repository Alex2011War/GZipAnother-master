using System.IO;
using System.IO.Compression;

namespace ArhGzip_Another.Action

    {
    public class Decompressor : IProcess
    {
        public int TotalBlockProcessed { get; private set; } = 0;

        Block IProcess.Process(Block block)
        {
            Block processedBlock;
            using (var decompressedDataStream = new MemoryStream())
            using (var compressedDataStream = new MemoryStream(block.Data))
            using (GZipStream GZipStream = new GZipStream(compressedDataStream, CompressionMode.Decompress))
            {
                GZipStream.CopyTo(decompressedDataStream);
                processedBlock = new Block(decompressedDataStream.ToArray(), block.Number);
            }
            TotalBlockProcessed++;
            return processedBlock;
        }
    }
    }


