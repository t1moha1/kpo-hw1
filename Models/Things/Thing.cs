using System;
using MyZoo.Interfaces;

namespace MyZoo.Models.Things
{
    public abstract class Thing : IInventory
    {
        public Guid Number { get; }
        public string Name { get; }

        protected Thing(string name)
        {
            Number = Guid.NewGuid();
            Name = name;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Number}]: {Name}";
        }
    }
}