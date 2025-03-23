using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using ZOO_Animal;
using ZOO_Employee;
using ZOO_Service;

{
    //Основная программа

    //Создаём новый список животных
    AnimalList animals = new AnimalList();
    //Создаём новый список сотрудников
    EmployeeList employees = new EmployeeList();
    //Создаём новый список дополнительных услуг
    ServiceList services = new ServiceList();

    string choice = "1";

    //Выбор функции программы с которой мы хотим работать или завершение программы.
    //По окончанию работы одной функции можно не перезапуская программу снова обратиться к ней же или другой функции.
    while(choice == "1" || choice == "2" || choice == "3")
    {
        Console.WriteLine("\nЧтобы изменить или просмотреть список животных введите 11111.\nчтобы изменить или просмотреть список сотрудников введите 2.\nчтобы изменить стоимость билетов, список услуг или получить квитанцию введите 3.\nЧтобы завершить работу введите любую другую цифру.");
        choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AnimalsProgram(animals);
                break;
            case "2":
                EmployeesProgram(employees);
                break;
            case "3":
                PriceProgram(services);
                break;
        }
    }
    




    //Получение и удаление информации о животных. Получение списка животных.
    void AnimalsProgram(AnimalList animals)
    {
        int exit;
        do
        {
            Console.Write("\nЧтобы добавить животное введите 1, чтобы удалить животное введите 2, чтобы закончить введите любую цифру: ");
            string input = Console.ReadLine();
            try
            {
                exit = Int32.Parse(input);
            }
            catch
            {
                exit = 4;
            }

            //Добавление животного в список
            if (exit == 1)
            {
                Console.WriteLine("\nВведите данные животного:");

                Console.Write("Имя: ");
                string name = Console.ReadLine();
                if(name == "")
                    throw new ArgumentException("Имя не может быть пустым!");

                Console.Write("Вид: ");
                string species = Console.ReadLine();
                if (species == "")
                    throw new ArgumentException("Вид не может быть пустым!");

                Console.Write("Характеристики: ");
                string characteristics = Console.ReadLine();

                Animal animal = new Animal(name, species, characteristics);

                animals.AddList(animal);
            }

            //Удаление животного из списка
            if (exit == 2)
            {
                Console.WriteLine("\nВведите имя, вид и характеристики животного, которое вы хотите удалить:");

                Console.Write("Имя: ");
                string name = Console.ReadLine();
                if (name == "")
                    throw new ArgumentException("Имя не может быть пустым!");

                Console.Write("Вид: ");
                string species = Console.ReadLine();
                if (species == "")
                    throw new ArgumentException("Вид не может быть пустым!");

                Console.Write("Характеристики: ");
                string characteristics = Console.ReadLine();

                Animal animal = new Animal(name, species, characteristics);

                animals.RemoveList(animal);
            }
        } while (exit == 1 || exit == 2);
        animals.ShowList(); //В конце работы метода показывается получившийся в итоге список животных
    }

    

    //Получение и удаление информации о сотрудниках. Получение списка сотрудников.
    void EmployeesProgram(EmployeeList employees)
    {
        int exit;
        do
        {
            Console.Write("\nЧтобы добавить сотрудника введите 1, чтобы удалить сотрудника введите 2, чтобы закончить введите любую цифру: ");
            string input = Console.ReadLine();
            try
            {
                exit = Int32.Parse(input);
            }
            catch
            {
                exit = 4;
            }

            //Добавление сотрудника в список
            if (exit == 1)
            {
                Console.WriteLine("\nВведите данные сотрудника:");

                Console.Write("Имя: ");
                string name = Console.ReadLine();
                if (name == "")
                    throw new ArgumentException("Имя не может быть пустым!");

                Console.Write("Должность: ");
                string job = Console.ReadLine();
                if (job == "")
                    throw new ArgumentException("Должность не указана!");

                Console.Write("Контактная информация: ");
                string contacts = Console.ReadLine();
                if (contacts == "")
                    throw new ArgumentException("Контактная информация не указана!");

                Employee employee = new Employee(name, job, contacts);

                employees.AddList(employee);
            }

            //Удаление сотрудника из списка
            if (exit == 2)
            {
                Console.WriteLine("\nВведите имя, должность и контактную информацию сотрудника, которого вы хотите удалить:");

                Console.Write("Имя: ");
                string name = Console.ReadLine();
                if (name == "")
                    throw new ArgumentException("Имя не может быть пустым!");

                Console.Write("Должность: ");
                string job = Console.ReadLine();
                if (job == "")
                    throw new ArgumentException("Должность не указана!");

                Console.Write("Контактная информация: ");
                string contacts = Console.ReadLine();
                if (contacts == "")
                    throw new ArgumentException("Контактная информация не указана!");

                Employee employee = new Employee(name, job, contacts);

                employees.RemoveList(employee);
            }
        } while (exit == 1 || exit == 2);
        employees.ShowList(); //В конце работы метода показывается получившийся в итоге список сотрудников
    }



    //Получение информации о стоимости билетов. Получение и удаление информации о дополнительных услугах. Генерация квитанции.
    void PriceProgram(ServiceList services)
    {
        //Получение информации о билетах
        float adultTicket;
        float childTicket;
        float discountTicket;

        Console.WriteLine("\nВведите стоимость билетов:");
        Console.Write("Взрослый: ");
        string inputPrice = Console.ReadLine();
        try
        {
            adultTicket = float.Parse(inputPrice);
        }
        catch
        {
            throw new ArgumentException("Введённое значение не является числом!");
        }

        Console.Write("Детский: ");
        inputPrice = Console.ReadLine();
        try
        {
            childTicket = float.Parse(inputPrice);
        }
        catch
        {
            throw new ArgumentException("Введённое значение не является числом!");
        }

        Console.Write("Скидочный: ");
        inputPrice = Console.ReadLine();
        try
        {
            discountTicket = float.Parse(inputPrice);
        }
        catch
        {
            throw new ArgumentException("Введённое значение не является числом!");
        }



        //Получение информации о дополнительных услугах
        int exit;
        do
        {
            Console.Write("\nЧтобы добавить услугу введите 1, чтобы удалить услугу введите 2, чтобы закончить введите любую цифру: ");
            string inputn = Console.ReadLine();
            try
            {
                exit = Int32.Parse(inputn);
            }
            catch
            {
                exit = 3;
            }

            //Добавление услуги в список
            if (exit == 1)
            {
                Console.WriteLine("\nВведите данные услуги:");

                Console.Write("Название: ");
                string name = Console.ReadLine();
                if (name == "")
                    throw new ArgumentException("Название услуги не может быть пустым!");

                Console.Write("Стоимость: ");
                inputPrice = Console.ReadLine();
                float price;
                try
                {
                    price = float.Parse(inputPrice);
                }
                catch
                {
                    throw new ArgumentException("Введённое значение не является числом!");
                }

                Service service = new Service(name, price);

                services.AddList(service);
            }

            //Удаление услуги из списка
            if (exit == 2)
            {
                Console.WriteLine("\nВведите данные услуги, которую вы хотите удалить:");

                Console.Write("Название: ");
                string name = Console.ReadLine();
                if (name == "")
                    throw new ArgumentException("Название услуги не может быть пустым!");
                float price;

                Console.Write("Стоимость: ");
                inputPrice = Console.ReadLine();
                try
                {
                    price = float.Parse(inputPrice);
                }
                catch
                {
                    throw new ArgumentException("Введённое значение не является числом!");
                }

                Service service = new Service(name, price);

                services.RemoveList(service);
            }
        } while (exit == 1 || exit == 2);



        //Вывод списка доступных услуг
        services.ShowList();

        //Получение квитанции
        float finalPrice = 0;
        Console.Write("\nВыберите билет (взрослый - 1, детский - 2, скидочный - 3): ");
        string input = Console.ReadLine();
        int ticketType = Int32.Parse(input);

        //Добавление стоимости билета
        switch (ticketType)
        {
            case 1:
                finalPrice += adultTicket;
                break;
            case 2:
                finalPrice += childTicket;
                break;
            case 3:
                finalPrice += discountTicket;
                break;
            default:
                throw new ArgumentException("Неправильный билет!");
        }

        //Поиск услуги по имени для получения её стоимости
        string searchService;
        do
        {
            Console.Write("\nВведите название услуги, чтобы выбрать её или 0 чтобы продолжить: ");
            searchService = Console.ReadLine();
            finalPrice += services.GetServicePrice(searchService);
        } while (searchService != "0");

        //Вывод итоговой стоимости билета
        Console.WriteLine($"\nИтоговая стоимость билета: {finalPrice} Руб.");
    }
}




