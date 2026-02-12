using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects
{
    class Power
    {
        public double Value { get; }

        public double Min = 0.1;
        public double Max = 5000;

        public Power(double value)
        {
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException($"Power must be between {Min} and {Max} Watt.");

            Value = value;
        }
    }
}
