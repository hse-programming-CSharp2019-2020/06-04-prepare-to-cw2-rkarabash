using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using EKRLib;

namespace EKR_2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Collection<Box> boxes = new Collection<Box>(JsonConvert.DeserializeObject<List<Box>>(File.ReadAllText(@"../../../EKR-1/bin/Debug/boxes.json")));
                    Console.WriteLine("LINQ 1");
                    foreach (var item in boxes.Where(x => x.GetLongestSide() > 3).OrderByDescending(x => x.GetLongestSide()))
                        Console.WriteLine(item);
                    Console.WriteLine();
                    Console.WriteLine("Linq 2");
                    foreach (var item in boxes.GroupBy(x => x.Weight))
                    {
                        Console.WriteLine("Масса: " + item.Select(x=>x.Weight).FirstOrDefault());
                        foreach (var it in item)
                        {
                            Console.WriteLine(it);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Linq 3");
                    foreach (var item in boxes.Where(x => x.Weight == boxes.Select(y => y.Weight).Max()))
                    {
                        Console.WriteLine(item);
                    }
                    var max = boxes.Select(y => y.Weight).OrderByDescending(x=>x).FirstOrDefault();
                    Console.WriteLine($"Count: {boxes.Where(x => x.Weight == max).Count()}");
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
