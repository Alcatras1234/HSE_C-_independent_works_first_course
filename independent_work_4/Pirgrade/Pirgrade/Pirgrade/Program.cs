using System;
using System.Text;
using EKRLib;

namespace Peergrade;

class Program
{
    /// <summary>
    /// метод для формирования модели из случайных строчных букв и цифр
    /// </summary>
    /// <returns>возвращает сгенирированую модель</returns>
    public static string GenerationModel()
    {
        Random rand = new Random();
        string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string model = String.Empty;
        for (int i = 0; i < 5; i++)
        {
            model += symbols[rand.Next(0, 36)];
        }

        return model;
    }
    /// <summary>
    /// Метод, для работы со списками. Здесь создается случайным образом список из объектов, а далее происходи вывод звука и запись в файлы
    /// </summary>
    /// <param name="transports"> список объектов Car and MotorBoat </param>
    /// <param name="listsoundcar"> спикок звуков объектов Car</param>
    /// <param name="listsoundmotorboat"> список звуков объектов MotorBoat </param>
    public static void Listworks(List<Transport> transports, List<string> listsoundcar, List<string> listsoundmotorboat)
    {
        Random rand = new Random();
        for (int i = 0; i < rand.Next(6, 10); i++)
        {
            try
            {
                int distribution = rand.Next(0, 2);


                if (distribution == 0)
                {
                    transports.Add(new Car(GenerationModel(), (uint)rand.Next(10, 100)));
                }
                else
                {
                    transports.Add(new MotorBoat(GenerationModel(), (uint)rand.Next(10, 100)));
                }
            }
            catch (TransportException e)
            {
                Console.WriteLine(e.Message);
                i = 0;
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                i = 0;
                Console.WriteLine();
            }
        }

        for (int i = 0; i < transports.Count; i++)
        {
            if (transports[i] is Car)
            {
                listsoundcar.Add(transports[i].ToString());
            }
            else
            {
                listsoundmotorboat.Add(transports[i].ToString());
            }
            Console.WriteLine(transports[i].StartEngine());
        }
    }
    /// <summary>
    /// основной Мейн, происходит связь между всеми методами и классами а так же происходит повтор решения.
    /// </summary>
    public static void Main()
    {
        string exit;
        do
        {
            List<Transport> transports = new List<Transport>();
            List<string> listsoundcar = new List<string>();
            List<string> listsoundmotorboat = new List<string>();
            Listworks(transports, listsoundcar, listsoundmotorboat);
            File.WriteAllLines("../../../Cars.txt", listsoundcar, new UnicodeEncoding());
            File.WriteAllLines("../../../MotorBoats.txt", listsoundmotorboat, new UnicodeEncoding());
            Console.WriteLine("Информация записана в файлы Cars.txt и MotorBoats.txt");
            Console.WriteLine(
                "Если хотите выйти введите 0, если хотите остаться, нажмите любую клавишу, а затем Enter");
            exit = Console.ReadLine();

        } while (exit != null && !exit.Contains("0"));
    }
}