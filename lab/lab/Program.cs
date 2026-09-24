using lab;

TemperatureStorage temperatureStorage = new TemperatureStorage();

temperatureStorage.LoadListFromFile("C:\\all not basic\\Для учебы\\Проектирование информационных систем\\test.txt");

while (true)
{
    Console.Clear();
    Menu();
    string? input = Console.ReadLine();
    switch(input)
    {
        case "1":
            UserInput();
            break;
        case "2":
            Console.Clear();
            temperatureStorage.PrintTemperatures();
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            break;
        case "3":
            temperatureStorage.SaveListToFile("C:\\all not basic\\Для учебы\\Проектирование информационных систем\\test.txt");
            return;
    }
}

static void PrintHelp()
{
    Console.WriteLine("Введите запись о температуре:");
    Console.WriteLine("temperature дата \"место\" температура x y");
    Console.WriteLine("air дата \"место\" температура x y высота");
    Console.WriteLine("water дата \"место\" температура x y глубина");
    Console.WriteLine();
    Console.WriteLine("Примеры:");
    Console.WriteLine("temperature 2026.09.23 \"Красноярск\" 15.5 10 20");
    Console.WriteLine("air 2026.09.23 \"Центр города\" 18.5 10 20 2");
    Console.WriteLine("water 2026.09.23 \"Река Енисей\" 8.2 30 40 5");
    Console.WriteLine();
    Console.WriteLine("Вводите каждую запись с новой строки.");
    Console.WriteLine("Введите exit для сохранения данных и выхода.");
}

static void Menu()
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Ввести запись о температуре");
    Console.WriteLine("2. Показать все записи о температуре");
    Console.WriteLine("3. Сохранить данные и выйти");
}

void UserInput()
{
    while (true)
    {
        Console.Clear();
        PrintHelp();
        string? str = Console.ReadLine();
        if (str == "exit")
        {
            break;
        }
        else if (string.IsNullOrWhiteSpace(str))
        {
            Console.WriteLine("Пустая строка, попробуйте снова");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        else
        {
            temperatureStorage.StringToTemperature(str);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}