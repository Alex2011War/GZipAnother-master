namespace ArhGzip_Another.Action
{
    public interface IProcess
        {
            int TotalBlockProcessed { get; }
            Block Process(Block block);
        }
    }

