using System;
using System.IO;
using static System.Console;
using ArhGzip_Another.Utils_A;

namespace ArhGzip_Another
{
    public class Parameters
    {
        public readonly ProcUst Mode;
        public readonly string PathToSourceFile;
        public readonly string PathToResultFile;

        public Parameters(string[] args)
        {
            string mas;
            mas = Convert.ToString(ReadLine());
            if (mas == "compress")
            {
                Mode = ProcUst.compress;
            }
            else
            {
                Mode = ProcUst.decompress;
            }
            PathToSourceFile = Convert.ToString(ReadLine());
            PathToResultFile = Convert.ToString(ReadLine());
          
        }

       private void ModeCheckDialog(string mode)
        {
            mode = mode.ToLower();

            while (mode != "compress" && mode != "decompress")
            {
                WriteLine($"У программы нет режима {mode}.");
                WriteLine("Программа работает в двух режимах compress или decompress!");
                Write("Введите желаемый режим: ");
                mode = ReadLine();
            }
        }

        private void PathCheck(string path)
        {
            var a = Path.GetInvalidPathChars();
            if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new ArgumentException($"{path} - некорректный путь к файлу!");
        }

        private void RewriteFileDialog(string path)
        {
            WriteLine($"{path} - файл существует!");
            WriteLine("Перезаписать?(введите: да/нет)");

            var answer = ReadLine();

            while (answer != "да" && answer != "нет")
            {
                WriteLine("Перезаписать существующий файл?(введите: да/нет)");
                answer = ReadLine();
            }

            if (answer == "нет")
                throw new ArgumentException($"{path} - неверный файл.");
        }
    }
}

