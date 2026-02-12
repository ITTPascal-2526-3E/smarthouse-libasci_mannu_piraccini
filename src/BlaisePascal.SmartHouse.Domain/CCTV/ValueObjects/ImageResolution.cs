using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV.ValueObjects
{
    class ImageResolution
    {
        public int Value { get; set;  }

        public int Min = 240;
        public int Max = 8000;

        public ImageResolution(int value)
        {
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException($"Resolution must be between {Min} and {Max}.");

            Value = value;
        }
    }
}
