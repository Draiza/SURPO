using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOO_ZooList;

namespace ZOO_Animal
{
    internal struct Animal
    {
        //Поля структуры
        public string Name { get; set; }
        public string Species { get; set; }
        public string Characteristics { get; set; }

        //Конструктор
        public Animal(string name, string species, string characteristics)
        {
            Name = name;
            Species = species;
            Characteristics = characteristics;
        }
    }

    internal class AnimalList : ZooList<Animal>
    {
        public override void ShowList()
        {
            Console.WriteLine("\nСписок животных:");
            foreach (var animal in items)
                Console.WriteLine($"Имя: {animal.Name}, вид: {animal.Species}, характеристики: {animal.Characteristics}");
        }
    }
}
