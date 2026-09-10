using System;
using System.Globalization;

namespace задание_1
{
    public class Temperature
    {
        private readonly string _type;
        private DateOnly _date;
        private string _place;
        private double _value;
        private int _x;
        private int _y;

        public Temperature(DateOnly date, string place, double value, int x, int y) : this("temperature", date, place, value, x, y)
        {
        }

        protected Temperature(string type, DateOnly date, string place, double value, int x, int y)
        {
            _type = type;
            _date = date;
            _place = place;
            _value = value;
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return FormattableString.Invariant(
                $"{_type} {_date:yyyy.MM.dd} \"{_place}\" {_value} {_x} {_y}");
        }
    }
}