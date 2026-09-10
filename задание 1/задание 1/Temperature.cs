using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace задание_1
{
    public class Temperature
    {
        private DateOnly _date;
        private string _place;
        private double _value;
        private int X;
        private int Y;
        public Temperature(DateOnly date, string place, double value, int x, int y)
        {
            _date = date;
            _place = place;
            _value = value;
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"{_date.ToString("yyyy.MM.dd")} \"{_place}\" {_value} {X} {Y}";
        }
    }
}