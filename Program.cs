using System;
using Microsoft.Extensions.DependencyInjection;
using MyZoo.Models.Animals;
using MyZoo.Models.Things;
using MyZoo.Services;
using MyZoo.Interfaces;

namespace MyZoo
{
    internal class Program
    {
        private static void Main()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IVetClinic, VetClinic>();
            services.AddSingleton<Zoo>();

            var provider = services.BuildServiceProvider();
            var zoo = provider.GetRequiredService<Zoo>();

            while (true)
            {
                Console.WriteLine("\n=== Меню ===");
                Console.WriteLine("1. Добавить животное");
                Console.WriteLine("2. Общий расход корма в день");
                Console.WriteLine("3. Контактный зоопарк");
                Console.WriteLine("4. Показать всех животных");
                Console.WriteLine("5. Добавить вещь");
                Console.WriteLine("6. Показать все вещи");
                Console.WriteLine("7. Показать все, что на балансе зоопарка");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { AddAnimal(zoo); break; }
                    case "2": { zoo.PrintTotalFoodPerDay(); break; }
                    case "3": { zoo.PrintContactZooCandidates(); break; }
                    case "4": { zoo.PrintAllAnimals(); break; }
                    case "5": { AddThing(zoo); break; }
                    case "6": { zoo.PrintAllThings(); break; }
                    case "7": { zoo.PrintFullInventory(); break; }
                    case "0": { return; }
                    default: { Console.WriteLine("Неизвестный пункт. Попробуйте еще раз"); break; }
                }
            }
        }

        private static void AddAnimal(Zoo zoo)
        {
            Console.Write("Имя животного: ");
            var name = Console.ReadLine() ?? "Unknown";

            Console.Write("Тип животного (rabbit, monkey, tiger, wolf): ");
            var type = Console.ReadLine()?.Trim().ToLower();

            Console.Write("Сколько кг еды в день: ");
            if (!int.TryParse(Console.ReadLine(), out var food))
            {
                Console.WriteLine("Ошибка: еда должна быть числом.");
                return;
            }

            Animal? animal = type switch
            {
                "rabbit" or "monkey" => CreateHerbo(name, food, type),
                "tiger" => new Tiger(name, food),
                "wolf" => new Wolf(name, food),
                _ => null
            };

            if (animal != null)
            {
                zoo.AddAnimal(animal);
            }
            else
            {
                Console.WriteLine("Ошибка: неизвестный тип животного.");
            }
        }

        private static Herbo? CreateHerbo(string name, int food, string type)
        {
            Console.Write("Уровень доброты (0–10): ");
            if (!int.TryParse(Console.ReadLine(), out var kindness))
            {
                Console.WriteLine("Ошибка: доброта должна быть числом.");
                return null;
            }

            return type == "rabbit"
                ? new Rabbit(name, food, kindness)
                : new Monkey(name, food, kindness);
        }

        private static void AddThing(Zoo zoo)
        {
            Console.Write("Тип вещи (table, computer): ");
            var type = Console.ReadLine()?.Trim().ToLower();

            Console.Write("Название вещи: ");
            var name = Console.ReadLine() ?? "Unknown";

            Thing? thing = type switch
            {
                "table" => new Table(name),
                "computer" => new Computer(name),
                _ => null
            };

            if (thing != null)
            {
                zoo.AddThing(thing);
            }
            else
            {
                Console.WriteLine("Ошибка: неизвестный тип вещи.");
            }
        }
    }
}
