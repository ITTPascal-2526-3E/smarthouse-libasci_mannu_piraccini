using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation.ValueObjects
{
    public class Power
    {
        public double Watt { get; set; }
        public Power(double watt)
        {
            if (watt < 0) throw new ArgumentException("Power mustn't be negative.");
            Watt = watt;
        }
    }
}
