using System;
using System.Collections.Generic;
using System.Linq;
using MyZoo.Interfaces;
using MyZoo.Models.Animals;
using MyZoo.Models.Things;

namespace MyZoo.Services
{
    public class Zoo
    {
        private readonly List<Animal> _animals = new();
        private readonly List<Thing> _things = new();
        private readonly IVetClinic _clinic;

        public Zoo(IVetClinic clinic)
        {
            _clinic = clinic;
        }

        public void AddAnimal(Animal animal)
        {
            if (_clinic.CheckHealth(animal))
            {
                _animals.Add(animal);
                Console.WriteLine($"Животное {animal.Name} принято в зоопарк.");
            }
            else
            {
                Console.WriteLine($"Животное {animal.Name} не принято в зоопарк.");
            }
        }

        public void AddThing(Thing thing)
        {
            _things.Add(thing);
            Console.WriteLine($"Вещь \"{thing.Name}\" добавлена на баланс.");
        }

        public void PrintAllAnimals()
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("Животные отсутствуют.");
                return;
            }

            Console.WriteLine("Животные в зоопарке:");
            foreach (var animal in _animals)
            {
                Console.WriteLine(animal);
            }
        }

        public void PrintAllThings()
        {
            if (_things.Count == 0)
            {
                Console.WriteLine("Инвентарные вещи отсутствуют.");
                return;
            }

            Console.WriteLine("Вещи на балансе:");
            foreach (var thing in _things)
            {
                Console.WriteLine(thing);
            }
        }

        public void PrintTotalFoodPerDay()
        {
            var total = _animals.Sum(a => a.Food);
            Console.WriteLine($"Всего требуется корма в день: {total} кг");
        }

        public void PrintContactZooCandidates()
        {
            var candidates = _animals
                .OfType<Herbo>()
                .Where(a => a.IsContactZooFriendly)
                .ToList();

            if (candidates.Count == 0)
            {
                Console.WriteLine("Нет животных для контактного зоопарка.");
                return;
            }

            Console.WriteLine("Животные, подходящие для контактного зоопарка:");
            foreach (var animal in candidates)
            {
                Console.WriteLine(animal);
            }
        }

        public void PrintFullInventory()
        {
            Console.WriteLine("Инвентарные номера всех объектов (животные и вещи):");

            foreach (var item in _animals)
            {
                Console.WriteLine($"{item.GetType().Name} — {item.Number}");
            }
            foreach (var item in _things)
            {
                Console.WriteLine($"{item.GetType().Name} — {item.Number}");
            }

        }

    }
}
