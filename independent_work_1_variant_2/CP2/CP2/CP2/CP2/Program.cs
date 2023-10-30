using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CP2;

class Program
{
    /// <summary>
    /// Место, где выполняется передача команд к классам и происходит запись
    /// </summary>
    /// <exception cref="ArgumentException">ошибка для отлова в catch</exception>
    public static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        int strike = Int32.MaxValue;
        while (strike != 0)
        {
            try
            {
                Console.WriteLine("Введите количество знаков после запятой.");
                int N = int.Parse(Console.ReadLine());
                if (N <= 1)
                {
                    throw new ArgumentException("Число N > 1");
                }
                Console.WriteLine("Введите имя файла");
                string filename = Console.ReadLine();
                if (filename == null)
                {
                    throw new ArgumentException("Введите имя файла.");
                }
                if (!File.Exists(filename))
                {
                    throw new ArgumentException("Файл не найден :)");
                }
                string[] fileread = File.ReadAllLines(filename);
                List<string> fileint = new List<string>();
                List<string> file = new List<string>();
                DoublePreciseFilter x = new DoublePreciseFilter(N);
                IntPreciseFilter y = new IntPreciseFilter(N);
                Precisfilter e = new Precisfilter(N);
                for (int i = 0; i < fileread.Length; ++i)
                {
                    if (double.Parse(fileread[i].Replace(".", ",")) % 1 == 0)
                    {
                        fileint.Add(y.Filter(double.Parse(fileread[i].Replace(".", ","))));
                        file.Add(y.Filter(double.Parse(fileread[i].Replace(".", ","))));
                    }
                    else
                    {
                        file.Add(x.Filter(double.Parse(fileread[i].Replace(".", ","))));
                    }
                }
                Console.WriteLine("Введите имя файла куда хотите сохранить целые значения");
                string filesavenameint = Console.ReadLine();
                Console.WriteLine("Введите название файла куда ходите сохранить остальные отфильтрованные значения");
                string filesavenameother = Console.ReadLine();
                File.AppendAllLinesAsync(filesavenameint, fileint, Encoding.GetEncoding(1251));
                File.AppendAllLinesAsync(filesavenameother, file, Encoding.GetEncoding(1251));
                Console.WriteLine("Все данные сохранены в файлы\n" +
                                  "");
                Console.WriteLine("Если желаете продолжить, введите любое число");
                Console.WriteLine("Если желаете выйти введите 0");
                strike = int.Parse(Console.ReadLine());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
