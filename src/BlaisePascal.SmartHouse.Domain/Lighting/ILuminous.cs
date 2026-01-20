using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console
{
    public interface ILuminous : ISwitchable
    {
        void DimmableControl(double brightness_level);
    }

}
