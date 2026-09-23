using задание_1;

TemperatureStorage temperatureStorage = new TemperatureStorage();

temperatureStorage.LoadListFromFile("C:\\all not basic\\Для учебы\\Проектирование информационных систем\\test.txt");
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
while (true)
{
    string? str = Console.ReadLine();
    if (str == "exit")
    {
        break;    
    }
    else if (string.IsNullOrWhiteSpace(str))
    {
        Console.WriteLine("Пустая строка, попробуйте снова");
    }
    else
    {
        temperatureStorage.StringToTemperature(str);
    }
}

temperatureStorage.PrintTemperatures();
temperatureStorage.SaveListToFile("C:\\all not basic\\Для учебы\\Проектирование информационных систем\\test.txt");
