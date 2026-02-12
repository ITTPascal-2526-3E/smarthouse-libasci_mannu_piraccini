using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects
{
    class TypeOfSocket
    {
        public string Name { get; set; }

        public TypeOfSocket(string name)
        {
            if (name != "E27" && name != "E14" && name != "GU10")
            {
                throw new ArgumentException($"Error - Invalid type of socket: '{name}'. Valid types are: 'E27', 'E14', 'GU10'.");
            }
            if (!string.IsNullOrWhiteSpace(name))
                Name = name.ToLower();

        }
    }
}
