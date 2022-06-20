using System;
using exam4.Classes;
using exam4.Patterns.Strategy.Interfaces;

namespace exam4.Patterns.Strategy
{
    public class OldAgeCat : ICatActions
    {
        public void FeedCat(Cat cat)
        {
            cat.SatietyValue += 4;
            cat.MoodValue += 4;
            cat.AverageLevel = (cat.SatietyValue + cat.MoodValue + cat.HealthValue) / 3;
            Console.WriteLine($"Вы покормили кота: {cat.Name}.\nУровень сытости: {cat.SatietyValue}\n" +
                              $"Уровень настроения: {cat.MoodValue}");
            cat.CatState = null;
        }

        public void VetCat(Cat cat)
        {
            cat.HealthValue += 4;
            cat.SatietyValue -= 6;
            cat.MoodValue -= 6;
            cat.AverageLevel = (cat.SatietyValue + cat.MoodValue + cat.HealthValue) / 3;
            Console.WriteLine($"Вы полечили кота: {cat.Name}.\nУровень здоровья: {cat.HealthValue} \nУровень сытости: {cat.SatietyValue}\n" +
                              $"Уровень настроения: {cat.MoodValue} ");
            cat.CatState = null;
        }

        public void PlayCat(Cat cat)
        {
            cat.HealthValue += 4;
            cat.SatietyValue -= 6;
            cat.MoodValue += 4;
            cat.AverageLevel = (cat.SatietyValue + cat.MoodValue + cat.HealthValue) / 3;
            Console.WriteLine($"Вы поиграли с котом: {cat.Name}.\nУровень здоровья: {cat.HealthValue} \nУровень сытости: {cat.SatietyValue}\n" +
                              $"Уровень настроения: {cat.MoodValue} ");
            cat.CatState = null;
        }
    }
}