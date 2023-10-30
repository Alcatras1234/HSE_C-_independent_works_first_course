using System.Data;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace CP1_second_module
{
    internal class Program
    {
        /// <summary>
        /// в данном методе мы проверяем, совпадает ли имя введенное пользователем с расширением csv.
        /// </summary>
        /// <param name="name">переменная нужна для работы в методе.</param>
        /// <returns> возвращаем true или false для завершения цикла ввода.
        /// </returns>
        static bool FileObr(string name)
        {
            if (!name.EndsWith(".csv"))
            {
                Console.WriteLine("Ваш файл не совпадает с расширением .csv, введите данные заново\n" +
                                  "");
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// в этом методе проверяютсе верхний хедр.
        /// </summary>
        /// <param name="name">нужна для if.</param>
        /// <returns>возвращает true or false для завершения или возобновления цикла ввода.</returns>
        static bool Check(string name)
        {
            if (!File.Exists(name))
            {
                Console.WriteLine("Файла не существует\n" +
                                  "");
                return false;
            }
            else
            {
                string[] strings = File.ReadAllLines(name);
                if (strings[0] != "\"gender\",\"race/ethnicity\",\"parental level of education\",\"lunch\",\"test preparation course\",\"math score\",\"reading score\",\"writing score\"")
                {
                    Console.WriteLine("Файл не имеет нужных данных:)\n" + 
                                      "");
                    return false;
                }
            }
            return true;
        } 
        /// <summary>
        /// в данном методе мы вызываем класс для выполнения 2 пункта в ср
        /// </summary>
        /// <param name="name"> это имя файла, который мы посылаем</param>
        static void secondtask(string name)
        {
            completed com = new completed(name);
            foreach (var i in com.Lines())
            {
                Console.WriteLine(i);
            }
            File.WriteAllLines("Test_Preparation.csv", com.Lines());
        }
        /// <summary>
        /// в данном методе мы вызываем класс для выполнения 3 пункта в ср
        /// </summary>
        /// <param name="name"> это имя файла, которое мы посылаем</param>
        static void thirdtask(string name)
        {
            completed com = new completed(name);
            foreach (var i in com.ThirdTsk())
            {
                Console.WriteLine(i);
            }
            File.WriteAllLines("Sorted_Students.csv", com.ThirdTsk());

        }/// <summary>
         /// здесь мы делаем четвертое задание 
         /// </summary>
         /// <param name="name">имя нашего файла с которым работаем</param>
         /// <param name="name2">имя файла куда записываем</param>
        static void fourgthtask(string name, string name2)
        {
            completed com = new completed(name);
            foreach (var i in com.Fourght())
            {
                Console.WriteLine(i);
            }
            File.WriteAllLines(name2, com.Fourght());
        }/// <summary>
         /// здесь мы делаем 5 задание.
         /// </summary>
         /// <param name="name">имя нашего файла с которым работаем</param>
        static void Fifth(string name)
        {
            string[] line = File.ReadAllLines(name);
            Console.WriteLine("All lines: " + (line.Length - 1));
            string[] gr = new string[line.Length];
            int count = 0;
            for (int i = 1; i < line.Length; i++)
            {
                string[] linew = line[i].Split(",");
                linew[1] = linew[1][1..^1];
                if (!gr.Contains(linew[1]))
                {
                    gr[count] = linew[1];
                    count++;
                }
                
            }

            string[] gr_1 = new string[gr.Length];
            int count2 = 0;
            for (int i = 0; i < gr.Length; i++)
            {
                
                if (gr[i] != null)
                {
                    gr_1[count2] = gr[i];
                    count2++;
                }
            }
            Array.Resize(ref gr_1, count2);
            Console.WriteLine($"Количество групп: {gr_1.Length}");
            int[] members = new int[gr_1.Length];
            for (int i = 0; i < line.Length; i++)
            {
                string[] linew = line[i].Split(",");
                linew[1] = linew[1][1..^1];
                for (int j = 0; j < gr_1.Length; j++)
                {
                    if (linew[1] == gr_1[j])
                    {
                        members[j]++;
                    }
                }
                
            }

            for (int i = 0; i < gr_1.Length; i++)
            {
                Console.WriteLine(gr_1[i] + " " + members[i]);
            }
            


            int mathcs = 0;
            int readingsc = 0;
            int writingsc = 0;
            int[] r = new int[line.Length];
            int[] r1 = new int[line.Length];
            int[] r2 = new int[line.Length];
            for (int i = 1; i < line.Length; i++)
            {
                string[] linew2 = line[i].Split(",");
                linew2[5] = linew2[5][1..^1];
                linew2[6] = linew2[6][1..^1];
                linew2[7] = linew2[7][1..^1];
                r[i] = int.Parse(linew2[5]);
                if (r[i] > 50)
                {
                    mathcs++;
                }

                r1[i] = int.Parse(linew2[6]);
                if (r1[i] > 50)
                {
                    readingsc++;
                }
                r2[i] = int.Parse(linew2[7]);
                if (r2[i] > 50)
                {
                    writingsc++;
                }

            }
            Console.WriteLine($"Members, who write math > 50: {mathcs}\n" +
                              $"Members, who write reading > 50: {readingsc}\n" +
                              $"Members, who write writing > 50: {writingsc}\n" +
                              $"\n" +
                              $"\n");


        }
        /// <summary>
        /// мейн в котором обрабатываем данные, введенные пользователем.
        /// </summary>
        /// <param name="args">для переменных</param>
        
        static void Main(string[] args)
        {
            Console.WriteLine("Input number to use menu");
            string name = "exams.csv";
            string name2;
            string name3;
            
            while (true)
            {
                
                Console.WriteLine("Enter 0 to exit\n" +
                    "Enter 1 to to change your file in the programm\n" +
                    "Enter 2 to do second task\n" +
                    "Enter 3 to do third task\n" +
                    "Enter 4 to do fourth task\n" +
                    "Enter 5 to do fifth task");
                string number = Console.ReadLine();


                try
                {


                    switch (number)
                    {
                        case "0":
                            return;

                        case "1":
                            Console.WriteLine("Input your way to file");
                            try
                            {
                                name3 = Console.ReadLine();
                                if (!FileObr(name3) & !Check(name3))
                                    name = name3;
                                else
                                {
                                    Console.WriteLine("ПРОГРАММА БУДЕТ РАБОТАТЬ С ФАЙЛОМ exams.csv");
                                }


                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }



                            break;
                        case "2":
                            if (FileObr(name) || Check(name))
                            {
                                Console.WriteLine("Proccesing to do 2 task");
                                secondtask(name);
                            }

                            break;
                        case "3":
                            if (FileObr(name) || Check(name))
                            {
                                Console.WriteLine("Proccesing to do 3 task");
                                thirdtask(name);
                            }

                            break;
                        case "4":
                            if (FileObr(name) || Check(name))
                            {
                                Console.WriteLine("Proccesing to do 4 task");
                                Console.WriteLine("Input your csv file");
                                name2 = Console.ReadLine();
                                if (!FileObr(name2))
                                {
                                    fourgthtask(name, name2);
                                }
                            }

                            break;
                        case "5":
                            if (FileObr(name) || Check(name))
                            {
                                Fifth(name);
                            }

                            break;



                        default:
                            Console.WriteLine("Введите число из меню");
                            break;
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    /// <summary>
    /// в данном классе мы выполняем 2 - 4 задания
    /// </summary>
    class completed
    {
        string mas; // имя файла
        public completed(string mas)
        {
            this.mas = mas;
        }
       /// <summary>
       /// здесь выполняем работу, связанную со вторым заданием
       /// </summary>
       /// <returns>выводим массив с обработанными данными</returns>
        public string[] Lines()
        {

            string[] lines2 = File.ReadAllLines(mas); // массив, заполняемый строками файла
            string[] linesoff = new string[lines2.Length]; //новый массив, в котором мы записываем элемнты сompleted
            string[] e = new string[lines2.Length]; //массив для новых строк без пустых строк
            int y = 0;
            for(int i = 0; i < lines2.Length; i++)
            {
                string[] linework = lines2[i].Split(","); // засплитили и разбили массив для обработки его по столбцам
                linework[4] = linework[4][1..^1];
                if (linework[4] == "completed")
                {
                    linesoff[i] = lines2[i];
                }
            }
            for(int i = 0; i < lines2.Length; i++)
            {
                if (linesoff[i] != null)
                {
                    e[y] = linesoff[i];
                    y++;
                    
                }
               
            }
            Array.Resize(ref e, y);
            return e;
        }/// <summary>
         /// выполняем тут 3 задание
         /// </summary>
         /// <returns>выводим массив с данными, которые просили</returns>
        public string[] ThirdTsk()
        {
            string[] lines3 = File.ReadAllLines(mas);
            string[] standart = new string[lines3.Length];
            string[] free = new string[lines3.Length];
            string[] standart_1 = new string[lines3.Length];
            string[] free_1 = new string[lines3.Length];
            int x = 0;//для стандарт
            int y = 0;//для фри
            for(int i = 0; i < lines3.Length; i++)
            {
                string[] le = lines3[i].Split(",");
                le[3] = le[3][1..^1];
                
                if (le[3] == "standard")
                {
                    standart[i] = lines3[i];
                }
                if (le[3] == "free/reduced")
                {
                    free[i] = lines3[i];
                }
                
            }
            for(int i = 0; i < standart.Length; i++)
            {
                if (standart[i] != null)
                {
                    standart_1[x] = standart[i];
                    x++;
                }
            }
            for (int i = 0; i < free.Length; i++)
            {
                if (free[i] != null)
                {
                    free_1[y] = free[i];
                    y++;
                }
            }
            Array.Resize(ref standart_1, x);
            Array.Resize(ref free_1, y);
            int[] s = new int[x];
            int[] f = new int[y];
            for (int i = 0; i < x; i++)
            {
                string[] s_1 = standart_1[i].Split(",");
                s_1[5] = s_1[5][1..^1];
                s[i] = int.Parse(s_1[5]);   
            }
            for (int i = 0; i < y; i++)
            {
                string[] f_1 = free_1[i].Split(",");
                f_1[5] = f_1[5][1..^1];
                f[i] = int.Parse(f_1[5]);
            }
            int maxs = s.Max();
            int mins = s.Min();
            int maxf = f.Max();
            int minf = f.Min();
            Console.WriteLine($"Дельта в массиве Standart = {maxs - mins}, Дельта в массиве Free = {maxf - minf}");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Array.Sort(s, standart_1);
            Array.Sort(f, free_1);
            var z = new string[x + y + 5];
            standart_1.CopyTo(z, 0);
            free_1.CopyTo(z, x + 5);
            return z;

        }/// <summary>
         /// выполняем 4 задание.
         /// </summary>
         /// <returns>выводим массив, который просили</returns>
        public string[] Fourght()
        {
            string[] line = File.ReadAllLines(mas);
            string[] female = new string[line.Length];
            string[] female_1 = new string[line.Length];
            int femalecount = 0;
            
            for(int i = 0; i < line.Length; i++)
            {
                string[] line1 = line[i].Split(",");
                line1[0] = line1[0][1..^1];
                if (line1[0] == "female")
                {
                    female[i] = line[i];
                }
            }
            for(int i = 0; i < female.Length; i++)
            {
                if (female[i] != null)
                {
                    female_1[femalecount] = female[i];
                    femalecount++;
                }
            }
            Array.Resize(ref female_1, femalecount);
            double[] aver = new double[female_1.Length + 1];
            for (int i = 0; i < female_1.Length - 1; i++)
            {
                string[] line4 = female_1[i].Split(",");
                line4[5] = line4[5][1..^1];
                line4[6] = line4[6][1..^1];
                line4[7] = line4[7][1..^1];
                aver[i] = (double.Parse(line4[5]) + double.Parse(line4[6]) + double.Parse(line4[7])) / 3;
            }


            
            var z = new string[female_1.Length];
            for (int i = 0; i < z.Length - 1; i++)
            {
                z[i] = female_1[i] + " " + " " + "Averange = " + aver[i].ToString();
            }
            return z;
        }

        

            

    
    
   
    }
    
}