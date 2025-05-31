namespace MyZoo.Models.Animals
{
    public abstract class Predator : Animal
    {
        protected Predator(string name, int food)
            : base(name, food)
        {
        }
    }
}