using System;
using MyZoo.Models.Animals;

namespace MyZoo.Services
{
    public class VetClinic
    {
        private readonly Random _random = new();

        public bool CheckHealth(Animal animal)
        {
            Console.WriteLine($"Проверка здоровья животного: {animal.Name}...");
            var isHealthy = _random.Next(0, 2) == 1;

            if (isHealthy)
                Console.WriteLine("Животное признано здоровым.");
            else
                Console.WriteLine("Животное НЕ прошло ветеринарный контроль.");

            return isHealthy;
        }
    }
}