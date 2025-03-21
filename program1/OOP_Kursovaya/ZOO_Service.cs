using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOO_ZooList;

namespace ZOO_Service
{
    internal struct Service
    {
        //Поля структуры
        public string Name { get; set; }
        public float Price { get; set; }

        //Конструктор
        public Service(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }

    internal class ServiceList : ZooList<Service>
    {
        public override void ShowList()
        {
            Console.WriteLine("\nСписок дополнительных услуг:");
            foreach (var service in items)
                Console.WriteLine($"Услуга: {service.Name}, стоимость: {service.Price}");
        }

        public float GetServicePrice(string name)
        {
            float search = 0;
            foreach (var service in items)
                if (service.Name == name)
                {
                    search = service.Price;
                    Console.WriteLine($"\nВыбрана услуга: {service.Name}");
                }
            return search;
        }
    }
}
