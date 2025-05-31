using System;
using MyZoo.Interfaces;

namespace MyZoo.Models.Animals
{
    public abstract class Animal : IAlive, IInventory
    {
        public Guid Number { get; }
        public string Name { get; }
        public int Food { get; }

        protected Animal(string name, int food)
        {
            Number = Guid.NewGuid();
            Name = name;
            Food = food;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Number}]: {Name}, ест {Food} кг/день";
        }
    }
}