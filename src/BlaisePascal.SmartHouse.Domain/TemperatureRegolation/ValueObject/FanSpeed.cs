using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegolation.ValueObject
{
    public class FanSpeed
    {
        public int Level { get; set; }
        public FanSpeed(int level)
        {
            if (level < 1 || level > 5)
                throw new ArgumentOutOfRangeException("FanSpeed must be between 1 and 5.");
            Level = level;
        }
    }