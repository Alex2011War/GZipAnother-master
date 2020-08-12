using System;
using static System.Console;

namespace ArhGzip_Another
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;
            CancelKeyPress += CancelKeyHandler;
            new Application(new Parameters(args)).Run();
        }

        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            WriteLine((args.ExceptionObject as Exception).Message);
            Environment.Exit(1);
        }

        private static void CancelKeyHandler(object sender, ConsoleCancelEventArgs args)
        {
            WriteLine("Прервано пользователем.");
            Environment.Exit(1);
        }

    }
}

