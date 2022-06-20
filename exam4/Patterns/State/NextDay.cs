using System;
using System.Collections.Generic;
using exam4.Classes;
using exam4.Patterns.State.Interfaces;

namespace exam4.Patterns.State
{
    public class NextDay : ICatState
    {
        private Random _rnd = new Random();
        public void StateToNextDay(Cat cat)
        {
            if(cat.Name.Contains('*'))
            {
                cat.Name = cat.Name.Remove(0,1);
            }
            cat.SatietyValue += _rnd.Next(1, 6);
            cat.HealthValue += _rnd.Next(-3, 4);
            cat.MoodValue += _rnd.Next(-3, 4);
            cat.AverageLevel = (cat.SatietyValue + cat.HealthValue + cat.MoodValue) / 3;

        }
    }
}