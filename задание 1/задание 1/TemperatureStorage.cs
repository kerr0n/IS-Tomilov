using System.Globalization;

namespace задание_1
{
    public class TemperatureStorage
    {
        private List<Temperature> _temperatures = new List<Temperature>();

        public void SaveListToFile(string path)
        {
            File.WriteAllLines(path, _temperatures.Select(temperature => temperature.ToString()));
        }

        public void LoadListFromFile(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                _temperatures.Clear();
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
                    _ => throw new FormatException($"Неизвестный тип: {type}.")
                };

                _temperatures.Add(temperature);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                Console.WriteLine($"Ошибка обработки строки «{temp}», {ex.Message}");
            }
        }

        public void PrintTemperatures()
        {
            foreach (Temperature temperature in _temperatures)
            {
                Console.WriteLine(temperature.ToString());
            }
        }
    }
}
