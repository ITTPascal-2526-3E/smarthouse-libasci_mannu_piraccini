using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects
{
    public class Brand
    {
        public string Name { get; set; }

        public Brand(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name.ToLower();
        }
    }
}
