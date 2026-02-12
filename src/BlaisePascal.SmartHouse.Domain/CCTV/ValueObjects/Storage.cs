using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV.ValueObjects
{
    class Storage
    {
        public int Value { get; set; }

        public int Min = 0;
        public int Max = 4096; // fino a 4TB espresso in GB

        public Storage(int value)
        {
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException($"Storage capacity must be between {Min} and {Max}.");

            Value = value;
        }
    }
}
