using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exam4.Classes.Sorting
{
    public class CatSorting
    {
        public static List<Cat> CatSort(List<Cat> cat)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("Сортировка по:");
            Console.WriteLine("1 - имени, 2 -возрасту, 3 - здоровью.");
            Console.WriteLine("4 - настроению, 5 - сытости, 6 - среднему значению.");
            string index = Console.ReadLine();
            if (index == null)
            {
                Console.WriteLine("Вы ввели неверное значение, повторите попытку");
                return CatSort(cat);
            }
            switch (index)
            {
                case "1":
                    cat = cat.OrderBy(x => x.Name).ToList();
                    break;
                case "2":
                    cat = cat.OrderByDescending(x => x.Age).ToList();
                    break;
                case "3":
                    cat = cat.OrderByDescending(x => x.HealthValue).ToList();
                    break;
                case "4":
                    cat = cat.OrderByDescending(x => x.MoodValue).ToList();
                    break;
                case "5":
                    cat = cat.OrderByDescending(x => x.SatietyValue).ToList();
                    break;
                case "6":
                    cat = cat.OrderByDescending(x => x.AverageLevel).ToList();
                    break;
                default:
                    Console.WriteLine("Неверный ввод, повторите попытку");
                    CatSort(cat);
                    break;
            }
            return cat;
        }
    }
}