using System.Text.Json.Serialization;
using exam4.Patterns.State;
using exam4.Patterns.State.Interfaces;
using exam4.Patterns.Strategy;
using exam4.Patterns.Strategy.Interfaces;

namespace exam4.Classes
{
    public class Cat 
    {
        public string Name { get; set; }
        public int  Age { get; set; }
        public int SatietyValue { get; set; }
        public int MoodValue { get; set; }
        public int HealthValue { get; set; }
        public int AverageLevel { get; set; }
        [JsonIgnore] 
        public ICatActions CatActions;
        [JsonIgnore]
        public ICatState CatState;


        public void Actions()
        {
            if (this.Age > 11)
            {
                CatActions = new OldAgeCat();
            }
            else if (this.Age >= 6 && this.Age <= 10)
            {
                CatActions = new MiddleAgeCat();
            }
            else if (this.Age >= 1 && this.Age <= 5)
            {
                CatActions = new YongAgeCat();
            }
        }

        public void NextDay()
        {
            CatState.StateToNextDay(this);
        }

        public void ActionsFeedCat()
        {
            CatActions.FeedCat(this);
        }

        public void ActionsVetCat()
        {
            CatActions.VetCat(this);
        }

        public void ActionsPlayCat()
        {
            CatActions.PlayCat(this);
        }
    }
}