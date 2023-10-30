using System;
using System.Data;
using System.Runtime.Serialization.Json;
using System.Text;
using ConsoleApp2;
using EBookLib;
using System.Text.Json;
using System.Runtime.Serialization.Json;
class Program
{
    
    /// <summary>
    /// метод для получения списка объектов.
    /// </summary>
    /// <param name="N"> кол - во элементов.</param>
    /// <returns>список.</returns>
    public static List<PrintEdition> GetList(int N)
    {
        
        Random rand = new Random();
        List<PrintEdition> list = new List<PrintEdition>();
        GenerateName name = new GenerateName(N);

            for (int i = 0; i < N; i++)
            {
                try
                {
                    int distribution = rand.Next(0, 2);
                    if (distribution == 0)
                    {
                        list.Add( new Book(name.GetName(N), rand.Next(-10, 101), name.GetName(N)));
                 
                    }
                    else
                    {
                        list.Add(new Magazine(name.GetName(N), rand.Next(-10, 101), rand.Next(-10, 101)));
                        
                        
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    i -= 1;
                    Console.WriteLine();
                }
            }


            return list;
    }
    /// <summary>
    /// печатаем объекты.
    /// </summary>
    /// <param name="obj"> объекты. </param>
    /// <param name="e"> объект класса PrintEventArgs.</param>
    public static void PrintHandler(object obj, PrintEventArgs e) 
    {
        Console.WriteLine($"PRINTED! {e.Info}");

    }
    /// <summary>
    /// удаляет книги с буквой.
    /// </summary>
    /// <param name="obj">объекты.</param>
    /// <param name="e">объект класса  MyLibraryEventArgs.</param>
    public static void TakeHandler(object obj, MyLibraryEventArgs e)
    {
        Console.WriteLine();
        Random rand = new Random();
        MyLibrary<PrintEdition> objForThisMethod = obj as MyLibrary<PrintEdition>;
        Console.WriteLine($"ATTENTION! Books starts with {e.Info} were taken!");
        for (int i = 0; i < objForThisMethod.library.Count; i++)
        {
            if (objForThisMethod.library[i].name.StartsWith(e.Info) && objForThisMethod.library[i] is Book)
            {
                objForThisMethod.library.Remove(objForThisMethod.library[i]);
                i--;
            }
        }
        
    }
    /// <summary>
    /// Метод, производящий сериализацию объекта из json файла.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    public static void SerializeToJson(object obj, string path)
    {
        try
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(MyLibrary<PrintEdition>));
                dataContractJsonSerializer.WriteObject(fileStream, obj);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка(");
        }
    }
    /// <summary> 
    /// Метод, производящий десериализацию объекта из json файла. 
    /// </summary> 
    /// <param name="path">Путь к файлу, из которого производится десериализация объекта.</param> 
    /// <returns></returns> 
    public static object DeserializeFromJson(string path)
    {
        try
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(MyLibrary<PrintEdition>));
                return dataContractJsonSerializer.ReadObject(fileStream);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка(");
            return null;
        }
    }

    /// <summary>
    /// основная программа.
    /// </summary>
    public static void Main()
    {
        do
        {
            try
            {
                int N = 0;
                Random rand = new Random();
                int t = 0;
                while (!int.TryParse(Console.ReadLine(), out N) || !(N > 0 && N <= 10))
                {
                    Console.WriteLine("Введите цифру от 0 до 10");
                    Console.WriteLine("Вы ввели цифру не в диапазоне [0;10]");
               
                }
                List<PrintEdition> listPrintEditions;
                listPrintEditions = GetList(N);
                MyLibrary<PrintEdition> libraryObj = new MyLibrary<PrintEdition>(listPrintEditions);
                PrintEdition e;
                // Первый вывод.
                for (int i = 0; i < listPrintEditions.Count; i++)
                {
                    e = listPrintEditions[i];
                    e.OnPrint += PrintHandler;
                    e.Print();
                }
                Console.WriteLine(libraryObj);
                Console.WriteLine();
                libraryObj.onTake += TakeHandler;
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                char start = alphabet[rand.Next(0, 26)];
                libraryObj?.TakeBooks(start);
                Console.WriteLine("********************");
                // Вывод после обработки.
                foreach (var i in libraryObj.library)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
                Console.WriteLine("ПРОИЗВОДИМ СЕРИАЛИЗАЦИЮ");
                Console.WriteLine();
                SerializeToJson(libraryObj, "MyLibrary.json");
                MyLibrary<PrintEdition>? myLibrary = DeserializeFromJson("MyLibrary.json") as MyLibrary<PrintEdition>;
                // Вывод после сериализации.
                foreach(var i in myLibrary)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Количество страниц в книгах");
                Console.WriteLine(myLibrary.PagesInBook);
                Console.WriteLine("Количество страниц в журналах");
                Console.WriteLine(myLibrary.PagesInMagazine);
                Console.WriteLine("для выхода нажмите Esc, для продолжения вписывайте значения");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        } while (Console.ReadKey().Key != ConsoleKey.Escape);








    }
}