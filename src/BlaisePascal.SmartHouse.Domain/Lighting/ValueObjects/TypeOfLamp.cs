using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects
{
    class TypeOfLamp
    {
        public string Name { get; set; }

        public TypeOfLamp(string name)
        {
            if (name != "led" && name != "incandescent" && name != "fluorescent")
            {
                throw new ArgumentException($"Error - Invalid type of lamp: '{name}'. Valid types are: 'LED', 'Incandescent', 'Fluorescent'.");
            }
            if (!string.IsNullOrWhiteSpace(name))
                Name = name.ToLower();

        }
    }
}
