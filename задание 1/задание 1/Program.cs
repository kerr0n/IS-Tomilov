using Задание_1;

List<Temperature> temperatures = new List<Temperature>
{
    new Temperature(new DateOnly(2026, 1, 1), "Место 1", -5.0),
    new Temperature(new DateOnly(2026, 1, 2), "Место 2", -3.5),
    new Temperature(new DateOnly(2026, 1, 3), "Место 3", -2.0),
    new Temperature(new DateOnly(2026, 1, 4), "Место 4", -4.5),
    new Temperature(new DateOnly(2026, 1, 5), "Место 5", -6.0)
};
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
            temperatures.Add(new Temperature(date, place, temp));
        }
        catch
        {
            Console.WriteLine("Ошибка ввода");
        }
    }
}


foreach (Temperature temperature in temperatures)
{
    Console.WriteLine(temperature.ToString());
}