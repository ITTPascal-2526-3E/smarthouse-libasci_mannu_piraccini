using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV.ValueObjects
{
    class Connectivity
    {
        public int Value { get; }

        public const int Min = 0;
        public const int Max = 100;

        public Connectivity(int value)
        {
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException($"Connectivity must be between {Min} and {Max}.");

            Value = value;
        }
    }
}
