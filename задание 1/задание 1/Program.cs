using задание_1;

TemperatureStorage temperatureStorage = new TemperatureStorage();

temperatureStorage.LoadListFromFile("C:\\all not basic\\Для учебы\\Проектирование информационных систем\\test.txt");

Console.WriteLine("exit для выхода");
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
