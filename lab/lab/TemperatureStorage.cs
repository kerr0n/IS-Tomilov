using System.Globalization;

namespace lab
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

        public void StringToTemperature(string? input)
        {
            ParseTemperature parse = new ParseTemperature(input);
            if (parse.ReadyToUse)
            {
                _temperatures.Add(parse.Temperature);
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
