using System;
using System.Collections.Generic;
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
        private List<string> temperaturesToSave = new List<string>();







        public void SaveListToFile()
        {
            File.WriteAllLines(path, temperaturesToSave);
        }

        public void LoadListFromFile()
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                Temperatures = new List<Temperature>();
                FromStringToTemperature(lines.ToList());
            }
        }

        public void FromStringToTemperature(List<string> temperatures)
        {
            foreach (string temp in temperatures)
            {
                StringToTemperature(temp);
            }
        }

        public void StringToTemperature(string temp)
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

        public void PrintTemperatures()
        {
            foreach (Temperature temperature in Temperatures)
            {
                Console.WriteLine(temperature.ToString());
                temperaturesToSave.Add(temperature.ToString());
            }
        }
    }
}
