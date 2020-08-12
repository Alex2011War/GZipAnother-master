using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace ArhGzip_Another

{
    public class BroadThread
    {
        private List<Thread> threads = new List<Thread>();
        private readonly object mutex = new object();

        public void Run(int threadCount, Handler handler)
        {
            var threadRead = CreateThread(handler.Reading, "Read");
            threadRead.Start();

            for (int i = 0; i < threadCount - 2; i++)
            {
                var thread = CreateThread(handler.Processing, $"Processing {i}");
                threads.Add(thread);
            }

            foreach (var t in threads)
            {
                t.Start();
            }

            // В основном потоке
            handler.Writing();
        }

        public void Stop()
        {
            foreach (var t in threads)
            {
                t.Join();
            }
        }

        private Thread CreateThread(System.Action threadAction, string name)
        {
            return new Thread(() => TryRunAction(threadAction))
            {
                Name = name
            };
        }

        private void TryRunAction(System.Action threadAction)
        {
            try
            {
                threadAction();
            }
            catch (Exception e)
            {
                lock (mutex)
                {
                    WriteLine($"В потоке \"{Thread.CurrentThread.Name}\" возникло исключение:");
                    WriteLine(e.Message);
                    Environment.Exit(1);
                }
            }
        }
    }
}

