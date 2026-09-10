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
        public Temperature(DateOnly date, string place, double value)
        {
            _date = date;
            _place = place;
            _value = value;
        }
        public override string ToString()
        {
            return $"{_date.ToString("yyyy.MM.dd")} \"{_place}\" {_value}";
        }
    }
}