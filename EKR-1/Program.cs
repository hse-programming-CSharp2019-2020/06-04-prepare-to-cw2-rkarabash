using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using EKRLib;

namespace EKR_1
{
    class Program
    {
        static Random rnd = new Random();
        static double GetDouble() => rnd.Next(-300, 1000) / 100.0;
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Collection<Item> boxes = new Collection<Item>();
                    int num = 0;
                    do
                        Console.WriteLine("Введите кол-во коробок: ");
                    while (!int.TryParse(Console.ReadLine(), out num) && num > 0);
                    for (int i = 0; i < num; i++)
                    {
                        try
                        {
                            boxes.Add(new Box(GetDouble(), GetDouble(), GetDouble(), GetDouble()));
                        }
                        catch (Exception e)
                        {
                            i--;
                            Console.WriteLine(e.Message);
                            continue;
                        }
                    }
                    foreach (var item in boxes)
                        Console.WriteLine(item);
                    File.WriteAllText(@"boxes.json", JsonConvert.SerializeObject(boxes));
                    Console.WriteLine(Environment.NewLine + "Для выхода нажмите ESCAPE...");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
