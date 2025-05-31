namespace MMyZoo.Models.Animals
{
    public abstract class Herbo : Animal
    {
        public int Kindness { get; }

        protected Herbo(string name, int food, int kindness)
            : base(name, food)
        {
            Kindness = kindness;
        }

        public bool IsContactZooFriendly => Kindness > 5;

        public override string ToString()
        {
            return base.ToString() + $", доброта: {Kindness}";
        }
    }
}