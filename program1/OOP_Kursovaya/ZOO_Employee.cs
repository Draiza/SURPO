using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOO_ZooList;

namespace ZOO_Employee
{
    internal struct Employee
    {
        //Поля структуры
        public string Name { get; set; }
        public string Job { get; set; }
        public string Contacts { get; set; }

        //Конструктор
        public Employee(string name, string job, string contacts)
        {
            Name = name;
            Job = job;
            Contacts = contacts;
        }
    }

    internal class EmployeeList : ZooList<Employee>
    {
        //Методы
        public override void ShowList()
        {
            Console.WriteLine("\nСписок сотрудников:");
            foreach (var employee in items)
                Console.WriteLine($"Имя: {employee.Name}, должность: {employee.Job}, контактная информация: {employee.Contacts}");
        }
    }
}
