using задание_1;

TemperatureStorage temperatureStorage = new TemperatureStorage();

temperatureStorage.LoadListFromFile();

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
temperatureStorage.SaveListToFile();
