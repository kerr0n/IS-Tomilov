using System.Globalization;

namespace lab
{
    /// <summary>
    /// Класс для хранения списка температур и их сохранения/загрузки из файла.
    /// </summary>
    public class TemperatureStorage
    {
        private List<Temperature> _temperatures = new List<Temperature>();

        /// <summary>
        /// Сохраняет список температур в файл
        /// </summary>
        /// <param name="path"></param>
        public void SaveListToFile(string path)
        {
            File.WriteAllLines(path, _temperatures.Select(temperature => temperature.ToString()));
        }

        /// <summary>
        /// Загружает список температур из файла
        /// </summary>
        /// <param name="path"></param>
        public void LoadListFromFile(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                _temperatures.Clear();
                FromStringToTemperature(lines.ToList());
            }
        }

        /// <summary>
        /// Преобразует список строк в список объектов Temperature и его наследников
        /// </summary>
        /// <param name="temperatures"></param>
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

        /// <summary>
        /// Преобразует строку в объект Temperature и его наследников
        /// </summary>
        /// <param name="input"></param>
        public void StringToTemperature(string? input)
        {
            ParseTemperature parse = new ParseTemperature(input);
            if (parse.ReadyToUse)
            {
                _temperatures.Add(parse.Temperature);
            }
        }

        /// <summary>
        /// Выводит список температур в консоль
        /// </summary>
        public void PrintTemperatures()
        {
            foreach (Temperature temperature in _temperatures)
            {
                Console.WriteLine(temperature.ToString());
            }
        }
    }
}
