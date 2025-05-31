using System;
using MyZoo.Models.Animals;

namespace MyZoo.Interfaces
{
   public interface IVetClinic
{
    bool CheckHealth(Animal animal);
}
}