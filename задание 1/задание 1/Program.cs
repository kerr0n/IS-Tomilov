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
    else
    {
        try
        {
            DateOnly date = DateOnly.Parse(str[0..10]);
            string place = str.Split()[1][1..^1];
            double temp = double.Parse(str.Split()[2]);
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