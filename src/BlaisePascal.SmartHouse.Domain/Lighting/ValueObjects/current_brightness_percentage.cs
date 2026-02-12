using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects
{
    class current_brightness_percentage
    {
        public double Value { get; }

        public const double Min = 1.0;
        public const double Max = 100.0;

        public current_brightness_percentage(double value)
        {
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException("Brightness level must be between 1 and 100.");

            Value = value;
        }
    }
}
