using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects
{
    class max_brightness
    {
        public double Value { get; }

        public const double Min = 1;
        public const double Max = 200000;

        public max_brightness(double value)
        {
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException($"Brightness must be between {Min} and {Max} lumen.");

            Value = value;
        }
    }
}
