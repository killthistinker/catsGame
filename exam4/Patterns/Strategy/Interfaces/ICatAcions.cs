using exam4.Classes;

namespace exam4.Patterns.Strategy.Interfaces
{
    public interface ICatActions
    {
        public void FeedCat(Cat cat);
        public void VetCat(Cat cat);
        public void PlayCat(Cat cat);
    }
}