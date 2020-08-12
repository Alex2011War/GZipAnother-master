using System;
using System.IO;
using System.IO.Compression;
using ArhGzip_Another.Utils_A;

namespace ArhGzip_Another.Action
{
    public class Compressor :IProcess
    {
        public int TotalBlockProcessed { get; private set; } = 0;

        public Block Process(Block block)
        {
            throw new NotImplementedException();
        }

        Block IProcess.Process(Block block)
        {
            Block processedBlock;
            using (var compressedDataStream = new MemoryStream())
            {
                using (var GZipStream = new GZipStream(compressedDataStream, CompressionMode.Compress))
                {
                    GZipStream.Write(block.Data, 0, block.Size);
                }

                processedBlock = new Block(GZipTools.AddSizeInfo(compressedDataStream.ToArray()), block.Number);
            }
            TotalBlockProcessed++;
            return processedBlock;
        }
    }

}




