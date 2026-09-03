using Задание_1;

List<Temperature> temperatures = new List<Temperature>
{
    new Temperature(new DateOnly(2026, 1, 1), "Место 1", -5.0),
    new Temperature(new DateOnly(2026, 1, 2), "Место 2", -3.5),
    new Temperature(new DateOnly(2026, 1, 3), "Место 3", -2.0),
    new Temperature(new DateOnly(2026, 1, 4), "Место 4", -4.5),
    new Temperature(new DateOnly(2026, 1, 5), "Место 5", -6.0)
};
foreach (Temperature temperature in temperatures)
{
    Console.WriteLine(temperature.GetAll());
}