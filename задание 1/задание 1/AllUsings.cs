using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using задание_1;

namespace задание_1
{
    public class AllUsings
    {
        private List<Temperature> Temperatures = new List<Temperature>
        {
            //new Temperature(new DateOnly(2026, 1, 1), "Место 1", -5.0),
            //new Temperature(new DateOnly(2026, 1, 2), "Место 2", -3.5),
            //new Temperature(new DateOnly(2026, 1, 3), "Место 3", -2.0),
            //new Temperature(new DateOnly(2026, 1, 4), "Место 4", -4.5),
            //new Temperature(new DateOnly(2026, 1, 5), "Место 5", -6.0)
        };
        private string path = "C:\\all not basic\\Для учебы\\Проектирование информационных систем\\test.txt";






        public void SaveListToFile()
        {
            File.WriteAllLines(path, Temperatures.Select(temperature => temperature.ToString()));
        }

        public void LoadListFromFile()
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                Temperatures.Clear();
                FromStringToTemperature(lines.ToList());
            }
        }

        public void FromStringToTemperature(List<string> temperatures)
        {
            foreach (string temp in temperatures)
            {
                if (!string.IsNullOrWhiteSpace(temp))
                {
                    StringToTemperature(temp);
                }
            }
        }

        public void StringToTemperature(string temp)
        {
            try
            {
                int firstQuote = temp.IndexOf('"');
                int lastQuote = temp.LastIndexOf('"');
                string[] beginning = temp[..firstQuote].Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
                string type = beginning[0].ToLowerInvariant();
                DateOnly date = DateOnly.ParseExact(beginning[1], "yyyy.MM.dd");
                string place = temp.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
                string[] numbers = temp[(lastQuote + 1)..].Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
                double value = double.Parse(numbers[0], CultureInfo.InvariantCulture);
                int x = int.Parse(numbers[1], CultureInfo.InvariantCulture);
                int y = int.Parse(numbers[2], CultureInfo.InvariantCulture);

                Temperature temperature = type switch
                {
                    "air" => new AirTemperature(date, place, value, x, y, double.Parse(numbers[3], CultureInfo.InvariantCulture)),
                    "water" => new WaterTemperature(date, place, value, x, y, double.Parse(numbers[3], CultureInfo.InvariantCulture)),
                    _ => new Temperature(date, place, value, x, y)
                };

                Temperatures.Add(temperature);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обработки строки «{temp}»: {ex.Message}");
            }
        }

        public void PrintTemperatures()
        {
            foreach (Temperature temperature in Temperatures)
            {
                Console.WriteLine(temperature.ToString());
            }
        }
    }
}
