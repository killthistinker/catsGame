using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exam4.Classes.Sorting;
using exam4.Patterns.State;

namespace exam4.Classes
{
    public delegate void Action();
    public class GameManager 
    {
        private List<Cat> _cats;
        private static Random _rnd = new Random();
        private bool _exit = true;
        private bool _sorting = true;

        public GameManager()
        {
            _cats = DataManager.GetCats();
        }

        public void Menu()
        {
            NextDay();
            while (_exit)
            {
                PrintCats();
                PrintActions();
                Actions();
            }
        }

        private int MarkCat()
        {
            Console.WriteLine("Введите номер кота:");
            string value = UserInput();
            if (!int.TryParse(value, out int number) | (number > _cats.Count))
            {
                Console.WriteLine("Введено неверное значение, повторите попытку");
                return MarkCat();
            }

            return number - 1;
        }

        private void GetState(Cat cat, Action action)
        {
            if (cat.CatState == null)
            {
                Console.WriteLine($"Вы уже делали это сегодня с котом {cat.Name}.Ждите новый день");
            }
            else
            { 
               action.Invoke();
               DataManager.SaveCats(_cats);
               cat.Name = new string($"* {cat.Name}");
            }
        }

        private void Actions()
        {
            Action action;
            string input = UserInput();
            int index;
            switch (input)
            {
                case "1":
                    index = MarkCat();
                    action = _cats[index].Actions;
                    action += _cats[index].ActionsFeedCat;
                    GetState(_cats[index], action);
                    break;
                case "2" :
                    index = MarkCat();
                    action = _cats[index].Actions;
                    action += _cats[index].ActionsVetCat;
                    GetState(_cats[index], action);
                    break;
                case "3" :
                    index = MarkCat();
                    action = _cats[index].Actions;
                    action += _cats[index].ActionsPlayCat;
                    GetState(_cats[index], action);
                    break;
                case "a":
                    AddCat();
                    break;
                case "b":
                    NextDay();
                    break;
                case "s":
                    _cats = CatSorting.CatSort(_cats);
                    DataManager.SaveCats(_cats);
                    _sorting = false;
                    break;
                case "выйти":
                    _exit = false; 
                    break;
                default:
                    Console.WriteLine("Введено неверное значение, потворите попытку");
                    Actions();
                    break;
            }
        }

        private void NextDay()
        {
            Console.WriteLine("Наступил новый день!");
            foreach (var cat in _cats)
            {
                cat.CatState = new NextDay();
                cat.NextDay();
            }
            DataManager.SaveCats(_cats);
        }

        private void PrintActions()
        {
            Console.WriteLine("Выберите действие :");
            Console.WriteLine("1: Покормить кота");
            Console.WriteLine("2: Лечить кота ");
            Console.WriteLine("3: Поиграть с котом");
            Console.WriteLine("a: Завести нового питомца");
            Console.WriteLine("b: Следующий день");
            Console.WriteLine("s: Для сортировки");
            Console.WriteLine("Введите \"выйти\" для выхода из программы");
        }
        

        private void AddCat()
        {
            Cat cat = new Cat();
            Console.WriteLine("Введите имя");
            cat.Name = UserInput();
            Console.WriteLine("Введите возраст");
            cat.Age = CatAge();
            cat = RandomParameters(cat);
            cat.AverageLevel = AverageLevel(cat);
            cat.CatState = new NextDay();
            _cats.Add(cat);
            Console.WriteLine("Кот добавлен.");
            DataManager.SaveCats(_cats);
            PrintCats();
        }

        public static Cat RandomParameters(Cat cat)
        {
            cat.HealthValue = _rnd.Next(20, 81);
            cat.MoodValue = _rnd.Next(20, 81);
            cat.SatietyValue = _rnd.Next(20, 81);
            return cat;
        }

        private int AverageLevel(Cat cat)
        {
            cat.AverageLevel = (cat.HealthValue + cat.MoodValue + cat.SatietyValue) / 3;
            return cat.AverageLevel;
        }
        

        private int CatAge()
        {
            string age = UserInput();
            if (!int.TryParse(age, out int catage) | (catage >= 18 | catage <= 0))
            {
                Console.WriteLine("Введено неверное значение, повторите попытку");
                return CatAge();
            }

            return catage;
        }
        private string UserInput()
        {
            try
            {
                return Console.ReadLine().Trim().ToLower();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Неверный формат ввода. Повторите попытку");
                return UserInput();
            }
            
        }

        private void SortingCats(ref List<Cat> cats)
        {
            var sort = from cat in cats orderby cat.AverageLevel descending select cat;
            var list = sort.ToList();
            cats = list;
        }
        
        private void PrintCats()
        {
            int i = 1;
            PrintTab();
            if(_sorting) SortingCats(ref _cats);
            foreach (var cat in _cats)
            {
                Console.WriteLine($" {i} | {cat.Name, 5} {"|", 4} {cat.Age, 7} {"|", 2} {cat.HealthValue, 8} " +
                                  $"{"|", 1} {cat.MoodValue, 10} {"|", 2} {cat.SatietyValue, 7}" +
                                  $" {"|", 2} {cat.AverageLevel, 10} {"|", 5}");
                i++;
            }
            PrintBody();
            DataManager.SaveCats(_cats);
        }
        
        private void PrintTab()
        {
            PrintBody();
            Console.WriteLine($" # | {"имя", 5} {"|", 4} {"возраст", 5} {"|", 2} {"здоровье", 5} {"|", 1} {"настроение", 5} {"|", 2} {"сытость", 5}" +
                          $" {"|", 2} {"Средний Уровень", 5}{"|", -2}");
        }

        private void PrintBody()
        {
            Console.Write($"{new string('-',3)}+{new string ('-',10)}+");
            Console.Write($"{new string ('-',10)}+{new string ('-',10)}+");
            Console.WriteLine($"{new string ('-',13)}+{new string ('-',10)}+{new string ('-',16)}+");
        }
    }
}