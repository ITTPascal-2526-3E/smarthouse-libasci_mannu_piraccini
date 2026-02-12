using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.CCTV.ValueObjects
{
    class CCTVName
    {
        public string Name { get; set; }
        public CCTVName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name.ToLower();

        }
    }

}