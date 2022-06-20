using exam4.Classes;

namespace exam4.Patterns.State.Interfaces
{
    public interface ICatState
    {
        public void StateToNextDay(Cat cat);
    }
}