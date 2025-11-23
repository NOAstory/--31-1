using System;

class Program
{
    private const string addDossier = "1";
    private const string printAllDossiers = "2";
    private const string removeDossier = "3";
    private const string searchByLastname = "4";
    private const string exit = "5";
    static void Main()
    {
        string[] fullNames = new string[0];
        string[] positions = new string[0];
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n=== Система управления досье ===");
            Console.WriteLine($"{addDossier}) Добавить досье");
            Console.WriteLine($"{printAllDossiers}) Вывести все досье");
            Console.WriteLine($"{removeDossier}) Удалить досье");
            Console.WriteLine($"{searchByLastname}) Поиск по фамилии");
            Console.WriteLine($"{exit}) Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case addDossier:
                    AddDossier(ref fullNames, ref positions);
                    break;

                case printAllDossiers:
                    PrintAllDossiers(fullNames, positions);
                    break;

                case removeDossier:
                    RemoveDossier(ref fullNames, ref positions);
                    break;

                case searchByLastname:
                    SearchByLastName(fullNames, positions);
                    break;

                case exit:
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

        fullNames = ExpandArray(fullNames, name);
        positions = ExpandArray(positions, position);

        Console.WriteLine("Досье добавлено!");
    }
    static string[] ExpandArray(string[] array, string newValue)
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

            string[] newFullNames = new string[fullNames.Length - 1];
            string[] newPositions = new string[positions.Length - 1];

            for (int i = 0; i < removeIndex; i++)
            {
                newFullNames[i] = fullNames[i];
                newPositions[i] = positions[i];
            }

            for (int i = removeIndex + 1; i < fullNames.Length; i++)
            {
                newFullNames[i - 1] = fullNames[i];
                newPositions[i - 1] = positions[i];
            }

            fullNames = newFullNames;
            positions = newPositions;

            Console.WriteLine("Досье удалено!");
        }
        else
        {
            Console.WriteLine("Неверный номер досье!");
        }
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

        if (!isFound)
        {
            Console.WriteLine("Досье с такой фамилией не найдены.");
        }
    }
}