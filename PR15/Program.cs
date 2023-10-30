using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PR15
{
    internal class Program
    {
        public static void Error(string message, ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        class Locality
        {
            string title;
            ulong born, died, population;
            long Natural_Grows()
            {
                long natural_grows = (long)(born - died);
                if (natural_grows > 0) Console.WriteLine("Естественный прирост населения за этот месяц положительный"); 
                else  Console.WriteLine("Естественный прирост населения за этот месяц отрицательный или нулевой"); 
                return natural_grows;
            }
            ~Locality()
            {
                Console.WriteLine("Деструктор сработал!");
                Console.ReadKey();
            }

            void GetInfo()
            {
                Console.WriteLine($"\nНазвание населенного пункта : {title}");
                Console.WriteLine($"Население : {population}");
                Console.WriteLine($"Ествественный прирост населения за этот месяц равен {Natural_Grows()} человек");
            }
            public Locality(ulong born, ulong died, string title, ulong population)
            {
                this.population = population;
                this.born = born;
                this.died = died;
                this.title = title;
                GetInfo();
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                bool flag = false;
                Console.WriteLine("Здравствуйте\nПрактическая работа номер 15");
                Console.Write("Введите Y чтобы продолжить или N чтобы выйти ");
                string select_key = Console.ReadLine();
                switch (select_key)
                {
                    case "Y":
                        try
                        {
                            try
                            {

                                Console.Write(" Введите название населенного пункта ");
                                string title = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(title))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка - отсутсвует название");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Thread.Sleep(2000);
                                    continue;
                                }
                                for (int i = 0; i < title.Length; i++)
                                {
                                    if (title[i] >= '0' && title[i] <= '9')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("В названии не может быть цифр");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                }

                                Console.Write(" Введите нынешнее колличеcтво людей, проживающих в нем ");
                                ulong population = (ulong)UInt64.Parse(Console.ReadLine());
                                Console.WriteLine(" Вычисление естественного прироста населения ");
                                Console.Write(" Сколько детей родилось за этот месяц : ");
                                ulong born = (ulong)UInt64.Parse(Console.ReadLine());
                                Console.Write(" Сколько людей умерло за этот месяц : ");
                                ulong died = (ulong)UInt64.Parse(Console.ReadLine());
                                if (died> population) 
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Не может умереть больше человек, чем сейчас проживает в населеном пункте");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Thread.Sleep(2000);
                                    continue;
                                }
                                Locality obj1 = new Locality(born, died, title, population);
                            }
                            catch (FormatException fe)
                            {
                                Error(fe.Message, ConsoleColor.Red);
                            }

                        }
                        catch (Exception ex) { Error(ex.Message, ConsoleColor.Red); }
                        Console.ReadKey();
                        break;
                    case "N":
                        Console.WriteLine("До свидания");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
