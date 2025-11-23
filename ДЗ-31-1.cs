using System;

class Program
{
    static void Main()
    {
        const string AddDossier = "1";
        const string PrintAllDossiers = "2";
        const string RemoveDossier = "3";
        const string SearchByLastname = "4";
        const string Exit = "5";

        string[] fullNames = new string[0];
        string[] positions = new string[0];
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n=== Система управления досье ===");
            Console.WriteLine($"{AddDossier}) Добавить досье");
            Console.WriteLine($"{PrintAllDossiers}) Вывести все досье");
            Console.WriteLine($"{RemoveDossier}) Удалить досье");
            Console.WriteLine($"{SearchByLastname}) Поиск по фамилии");
            Console.WriteLine($"{Exit}) Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case AddDossier:
                    AddDossier(ref fullNames, ref positions);
                    break;

                case PrintAllDossiers:
                    PrintAllDossiers(fullNames, positions);
                    break;

                case RemoveDossier:
                    RemoveDossier(ref fullNames, ref positions);
                    break;

                case SearchByLastname:
                    SearchByLastName(fullNames, positions);
                    break;

                case Exit:
                    isRunning = false;
                    Console.WriteLine("Выход из программы.");
                    break;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    static void AddDossier(ref string[] fullNames, ref string[] positions)
    {
        Console.Write("Введите ФИО: ");
        string name = Console.ReadLine();

        Console.Write("Введите должность: ");
        string position = Console.ReadLine();

        fullNames = AddDataToArray(fullNames, name);
        positions = AddDataToArray(positions, position);

        Console.WriteLine("Досье добавлено!");
    }

    static string[] AddDataToArray(string[] array, string newValue)
    {
        string[] newArray = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }

        newArray[array.Length] = newValue;

        return newArray;
    }

    static void PrintAllDossiers(string[] fullNames, string[] positions)
    {
        if (fullNames.Length == 0)
        {
            Console.WriteLine("Досье отсутствуют.");
            return;
        }

        for (int i = 0; i < fullNames.Length; i++)
        {
            Console.WriteLine($"{i + 1}) {fullNames[i]} - {positions[i]}");
        }
    }

    static void RemoveDossier(ref string[] fullNames, ref string[] positions)
    {
        if (fullNames.Length == 0)
        {
            Console.WriteLine("Нет досье для удаления.");
            return;
        }

        PrintAllDossiers(fullNames, positions);
        Console.Write("Введите номер досье для удаления: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= fullNames.Length)
        {
            int removeIndex = index - 1;

            fullNames = RemoveDataFromArray(fullNames, removeIndex);
            positions = RemoveDataFromArray(positions, removeIndex);

            Console.WriteLine("Досье удалено!");
        }
        else
        {
            Console.WriteLine("Неверный номер досье!");
        }
    }

    static string[] RemoveDataFromArray(string[] array, int removeIndex)
    {
        string[] newArray = new string[array.Length - 1];

        for (int i = 0; i < removeIndex; i++)
        {
            newArray[i] = array[i];
        }

        for (int i = removeIndex + 1; i < array.Length; i++)
        {
            newArray[i - 1] = array[i];
        }

        return newArray;
    }

    static void SearchByLastName(string[] fullNames, string[] positions)
    {
        if (fullNames.Length == 0)
        {
            Console.WriteLine("Досье отсутствуют.");
            return;
        }

        Console.Write("Введите фамилию для поиска: ");
        string lastName = Console.ReadLine().ToLower();

        bool isFound = false;

        for (int i = 0; i < fullNames.Length; i++)
        {
            string[] nameParts = fullNames[i].Split(' ');

            if (nameParts.Length > 0 && nameParts[0].ToLower() == lastName)
            {
                Console.WriteLine($"{fullNames[i]} - {positions[i]}");
                isFound = true;
            }
        }

        if (isFound == false)
        {
            Console.WriteLine("Досье с такой фамилией не найдены.");
        }
    }
}
