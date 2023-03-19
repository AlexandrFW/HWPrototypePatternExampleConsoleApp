using HWPrototypePatternExampleConsoleApp.Model;

namespace HWPrototypePatternExampleConsoleApp;

/* Демонстрация работы паттерна Прототип
 * 
 * Была создана своя реализация интерфеса IClonable - IMyClonable<T>, которая является generic
 * Преимущества данной реализации перед стандарным интерфейсом IClonalble в том, 
 * что данный интерфей строго типизирован и при клонирование нет необходимости заниматься приведением типов,
 * что могло бы вызвать операции упаковки/распаковки
 * 
 * Было создано несколько классов Person, Employee (наследует от Person) и Manager(наследует от Employee)
 * Все данные классы реализуют интерфейс IMyClonable<T>
 * Для копирования объектов был создан приватный конструктов, котоый создаёт новый, такой же, объект
 * на основе свойст текущего
 * 
 */

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Home Work: Prototype pattern example.");
        Console.WriteLine();

        TestIMyclonableInterfaceMethod();

        TestStandardICloanbleInterfaceMethod();

        Console.ReadKey();
    }

    private static void TestIMyclonableInterfaceMethod()
    {
        var employee = new Employee()
        {
            FirstName = "Василий",
            LastName = "Некрасов",
            EmailAddress = "vasiliy.nekrasov@gmail.com"
        };

        Console.WriteLine($"Работник 1:\r\n{employee.FirstName}\r\n{employee.LastName}\r\n{employee.EmailAddress}");
        Console.WriteLine();
        Console.WriteLine("Клонируем Работника 1...");
        Console.WriteLine();

        var newEmployee = employee.ThisClone();

        Console.WriteLine($"Работник 1 (поле клонирования):\r\n{newEmployee.FirstName}\r\n{newEmployee.LastName}\r\n{newEmployee.EmailAddress}");
        Console.WriteLine();

        Console.WriteLine("Теперь Работника 1 - это Работник 2. Определим его имя, фамилию и эл. почту");
        Console.WriteLine();

        newEmployee.FirstName = "Андрей";
        newEmployee.LastName = "Петров";
        newEmployee.EmailAddress = "andrey.petrov@bk.ru";

        Console.WriteLine($"Работник 2:\r\n{newEmployee.FirstName}\r\n{newEmployee.LastName}\r\n{newEmployee.EmailAddress}");
        Console.WriteLine();

        Console.WriteLine("При этом работник 1 не изменился");
        Console.WriteLine($"Работник 1 (для проверки):\r\n{employee.FirstName}\r\n{employee.LastName}\r\n{employee.EmailAddress}");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Создаём менеджера...");

        var manager = new Manager()
        {
            FirstName = "Александр",
            LastName = "Смирнов",
            EmailAddress = "alexandr.smirnov@yandex.ru",
            ManagerType = "Топ менеджер"
        };

        Console.WriteLine($"Менеджер:\r\n{manager.FirstName}\r\n{manager.LastName}\r\n{manager.EmailAddress}\r\n{manager.ManagerType}");
        Console.WriteLine();

        Console.WriteLine("Клонируем Менеджера...");

        var managerNew = manager.ThisClone();

        Console.WriteLine($"Менеджер (после клонирования):\r\n{managerNew.FirstName}\r\n{managerNew.LastName}\r\n{managerNew.EmailAddress}\r\n{managerNew.ManagerType}");
        Console.WriteLine();

        Console.WriteLine("Теперь Менеджер 1 - это Менеджер 2. Определим его имя, фамилию, эл. почту и тип");
        Console.WriteLine();

        managerNew.FirstName = "Борис";
        managerNew.LastName = "Абрамов";
        managerNew.EmailAddress = "boris.abramov@yandex.ru";
        managerNew.ManagerType = "Менеджер среднего звена";

        Console.WriteLine($"Менеджер 2:\r\n{managerNew.FirstName}\r\n{managerNew.LastName}\r\n{managerNew.EmailAddress}\r\n{managerNew.ManagerType}");
        Console.WriteLine();

        Console.WriteLine("При этом менеджер 1 не изменился");
        Console.WriteLine();

        Console.WriteLine($"Менеджер (для проверки):\r\n{manager.FirstName}\r\n{manager.LastName}\r\n{manager.EmailAddress}\r\n{manager.ManagerType}");
        Console.WriteLine();
    }

    private static void TestStandardICloanbleInterfaceMethod()
    {
        Console.WriteLine("Создаём менеджера (IClonable интерфейс)...");

        var manager = new Manager()
        {
            FirstName = "Пётр",
            LastName = "Харламов",
            EmailAddress = "peter.harlamov@yandex.ru",
            ManagerType = "Топ менеджер"
        };

        Console.WriteLine($"Менеджер:\r\n{manager.FirstName}\r\n{manager.LastName}\r\n{manager.EmailAddress}\r\n{manager.ManagerType}");
        Console.WriteLine();

        Console.WriteLine("Клонируем Менеджера...");

        var managerNew = (Manager)manager.Clone(); // Происходит приведение типов, а также операция упаковки/распаковки

        Console.WriteLine($"Менеджер (после клонирования):\r\n{managerNew.FirstName}\r\n{managerNew.LastName}\r\n{managerNew.EmailAddress}\r\n{managerNew.ManagerType}");
        Console.WriteLine();

        Console.WriteLine("Теперь Менеджер 1 - это Менеджер 2. Определим его имя, фамилию, эл. почту и тип");
        Console.WriteLine();

        managerNew.FirstName = "Борис";
        managerNew.LastName = "Абрамов";
        managerNew.EmailAddress = "boris.abramov@yandex.ru";
        managerNew.ManagerType = "Менеджер среднего звена";

        Console.WriteLine($"Менеджер 2:\r\n{managerNew.FirstName}\r\n{managerNew.LastName}\r\n{managerNew.EmailAddress}\r\n{managerNew.ManagerType}");
        Console.WriteLine();

        Console.WriteLine("При этом менеджер 1 не изменился");
        Console.WriteLine();

        Console.WriteLine($"Менеджер (для проверки):\r\n{manager.FirstName}\r\n{manager.LastName}\r\n{manager.EmailAddress}\r\n{manager.ManagerType}");
        Console.WriteLine();
    }
}