using System;
using System.Globalization;

namespace задание_1
{
    public class WaterTemperature : Temperature
    {
        private double _depth;

        public WaterTemperature(DateOnly date, string place, double value, int x, int y, double depth) : base("water", date, place, value, x, y)
        {
            if (depth < 0)
            {
                throw new ArgumentException("Глубина должна быть неотрицательным числом.");
            }

            _depth = depth;
        }

        public override string ToString()
        {
            return base.ToString() + " " + _depth.ToString(CultureInfo.InvariantCulture);
        }
    }
}