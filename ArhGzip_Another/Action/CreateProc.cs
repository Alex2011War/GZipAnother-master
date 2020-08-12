using System;
using ArhGzip_Another.Utils_A;

namespace ArhGzip_Another.Action
{
    public class ProcessorCreator
    {
        public IProcess CreateProcessor(ProcUst mode)
        {
            IProcess processor;
            switch (mode)
            {
                case ProcUst.compress:
                {
                    processor = new Compressor();
                    break;
                }
                case ProcUst.decompress:
                {
                    processor = new Decompressor();
                    break;
                }
                default:
                {
                    throw new Exception("Неверный режим работы программы!");
                }
            }
            return processor;
        }
    }
}


