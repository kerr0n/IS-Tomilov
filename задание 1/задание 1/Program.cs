using Задание_1;

List<Temperature> Temperatures = new List<Temperature>
{
    //new Temperature(new DateOnly(2026, 1, 1), "Место 1", -5.0),
    //new Temperature(new DateOnly(2026, 1, 2), "Место 2", -3.5),
    //new Temperature(new DateOnly(2026, 1, 3), "Место 3", -2.0),
    //new Temperature(new DateOnly(2026, 1, 4), "Место 4", -4.5),
    //new Temperature(new DateOnly(2026, 1, 5), "Место 5", -6.0)
};
string path = "C:\\all not basic\\Для учебы\\Проектирование информационных систем\\test.txt";
LoadListFromFile(path);

bool marker = true;
Console.WriteLine("exit для выхода");
while (marker)
{
    string str = Console.ReadLine();
    if (str == "exit")
    {
        marker = false;
    }
    else // для примера 2008.04.30 "Место 6" 1,2
    {
        try
        {
            DateOnly date = DateOnly.Parse(str[0..10]);
            int firstQuote = str.IndexOf('"');
            int lastQuote = str.LastIndexOf('"');
            string place = str.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
            double temp = double.Parse(str.Split()[^1]);
            Temperatures.Add(new Temperature(date, place, temp));
        }
        catch
        {
            Console.WriteLine("Ошибка ввода");
        }
    }
}

List<string> temperaturesToSave = new List<string>();
foreach (Temperature temperature in Temperatures)
{
    Console.WriteLine(temperature.ToString());
    temperaturesToSave.Add(temperature.ToString());
}
SaveListToFile(path, temperaturesToSave);





void SaveListToFile(string path, List<string> temperatures)
{
    File.WriteAllLines(path, temperatures);
}

void LoadListFromFile(string path)
{
    if (File.Exists(path))
    {
        string[] lines = File.ReadAllLines(path);
        Temperatures = new List<Temperature>();
        FromStringToTemperature(lines.ToList());
    }
}

void FromStringToTemperature(List<string> temperatures)
{
    foreach (string temp in temperatures)
    {
        try
        {
            DateOnly date = DateOnly.Parse(temp[0..10]);
            int firstQuote = temp.IndexOf('"');
            int lastQuote = temp.LastIndexOf('"');
            string place = temp.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
            double value = double.Parse(temp.Split()[^1]);
            Temperatures.Add(new Temperature(date, place, value));
        }
        catch
        {
            Console.WriteLine("Ошибка обработки строки");
        }
    }
}