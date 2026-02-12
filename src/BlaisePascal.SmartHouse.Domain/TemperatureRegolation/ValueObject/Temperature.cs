using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegolation.ValueObject
{
    public class Temperature
    {
        public double Value { get; set; }
        public Temperature(double value)
        {
            if (value < -10 || value > 50)
                throw new ArgumentOutOfRangeException("Resolution must be between (-10°C / +50°C).");
            Value = value;
        }

    }
}
