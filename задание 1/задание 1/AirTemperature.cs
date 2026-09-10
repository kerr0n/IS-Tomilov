using System;
using System.Globalization;

namespace задание_1
{
    public class AirTemperature : Temperature
    {
        private double _height;

        public AirTemperature(DateOnly date, string place, double value, int x, int y, double height) : base("air", date, place, value, x, y)
        {
            if (height < 0)
            {
                throw new ArgumentException("Высота должна быть неотрицательным числом");
            }

            _height = height;
        }

        public override string ToString()
        {
            return base.ToString() + " " + _height.ToString(CultureInfo.InvariantCulture);
        }
    }
}