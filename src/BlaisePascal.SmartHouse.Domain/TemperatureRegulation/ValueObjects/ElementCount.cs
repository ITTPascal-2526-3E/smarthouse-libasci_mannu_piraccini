using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation.ValueObjects
{
    public record ElementCount
    {
        public int Value { get; set; }
        public ElementCount(int value)
        {
            if (value <= 0) throw new ArgumentException("Radiator must have 1 or more element.");
            Value = value;
        }
    }
}
