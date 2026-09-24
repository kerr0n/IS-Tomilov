using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace lab
{
    public class ParseTemperature
    {
        public Temperature? Temperature { get; private set; }
        public bool ReadyToUse { get; private set; } = false;
        public ParseTemperature(string? input)
        {
            try
            {
                string line = ValidateInput(input);
                var (header, place, measurements) = SplitInput(line);
                string[] headerParts = SplitHeader(header);
                string type = ParseType(headerParts[0]);
                DateOnly date = ParseDate(headerParts[1]);
                string[] numberParts = SplitMeasurements(type, measurements);
                double value = ParseDouble(numberParts[0], "Температура");
                int x = ParseCoordinate(numberParts[1], "x");
                int y = ParseCoordinate(numberParts[2], "y");
                double extraValue = ParseExtraValue(type, numberParts);
                Temperature = CreateTemperature(type, date, place, value, x, y, extraValue);
                ReadyToUse = true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка обработки строки «{input}»: {ex.Message}");
            }
        }

        private static string ValidateInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new FormatException("Строка пуста.");
            }
            return input;
        }

        private static (string Header, string Place, string Measurements) SplitInput(string input)
        {
            int firstQuote = input.IndexOf('"');
            int lastQuote = input.LastIndexOf('"');
            if (firstQuote < 0 || lastQuote <= firstQuote)
            {
                throw new FormatException(
                    "Название места должно быть заключено в двойные кавычки.");
            }
            string header = input[..firstQuote];
            string place = input[(firstQuote + 1)..lastQuote];
            string measurements = input[(lastQuote + 1)..];
            if (string.IsNullOrWhiteSpace(place) || place.Contains('"'))
            {
                throw new FormatException(
                    "Название места пустое или содержит лишние кавычки.");
            }
            return (header, place, measurements);
        }

        private static string[] SplitHeader(string header)
        {
            string[] parts = header.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new FormatException(
                    "Перед названием места должны быть только тип и дата.");
            }
            return parts;
        }

        private static string ParseType(string text)
        {
            string type = text.ToLowerInvariant();
            if (type != "temperature" &&
                type != "air" &&
                type != "water")
            {
                throw new FormatException($"Неизвестный тип «{text}».");
            }
            return type;
        }

        private static DateOnly ParseDate(string text)
        {
            if (!DateOnly.TryParseExact(text, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
            {
                throw new FormatException("Неверная дата. Нужен формат yyyy.MM.dd.");
            }
            return date;
        }

        private static string[] SplitMeasurements(string type, string measurements)
        {
            string[] parts = measurements.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            int expectedCount = type == "temperature" ? 3 : 4;
            if (parts.Length != expectedCount)
            {
                throw new FormatException($"Для типа «{type}» после места нужно {expectedCount} числа.");
            }
            return parts;
        }

        private static double ParseDouble(string text, string fieldName)
        {
            string normalized = text.Replace(',', '.');
            if (!double.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out double result) || !double.IsFinite(result))
            {
                throw new FormatException($"{fieldName} должна быть конечным числом.");
            }
            return result;
        }

        private static int ParseCoordinate(string text, string coordinateName)
        {
            if (!int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result))
            {
                throw new FormatException($"Координата {coordinateName} должна быть целым числом.");
            }
            return result;
        }

        private static double ParseExtraValue(string type, string[] numberParts)
        {
            if (type == "temperature")
            {
                return 0;
            }
            string fieldName = type == "air" ? "Высота" : "Глубина";
            double value = ParseDouble(numberParts[3], fieldName);
            if (value < 0)
            {
                throw new FormatException($"{fieldName} не может быть отрицательной.");
            }
            return value;
        }

        private static Temperature CreateTemperature(string type, DateOnly date, string place, double value, int x, int y, double extraValue)
        {
            return type switch
            {
                "temperature" => new Temperature(date, place, value, x, y),
                "air" => new AirTemperature(date, place, value, x, y, extraValue),
                "water" => new WaterTemperature(date, place, value, x, y, extraValue),
                _ => throw new FormatException($"Неизвестный тип «{type}».")
            };
        }
    }
}
