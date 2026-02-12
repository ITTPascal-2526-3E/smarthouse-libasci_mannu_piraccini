using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Appliances.Value_Objects
{
    class WaterLevel 
    {
        public int Value { get; set;}

        public const int Min = 0;
        public const int Max = 100;

        public WaterLevel(int value)
        {
            
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException($"The amount of water level must be between {Min} and {Max}.");


            Value = value;
        }

    }
}
