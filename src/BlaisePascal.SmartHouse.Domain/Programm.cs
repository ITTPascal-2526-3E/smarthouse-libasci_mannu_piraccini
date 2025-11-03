using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlaisePascal.SmartHouse.Domain
{
    internal class Programm
    {
        public enum colors_of_lamp { red, green, blue, purple, yellow, white } 
        static void Main(string[] args)
        {
           
            Lamp classicLamp = new Lamp("Tapo", "LED", 60.0, 806.0,true,"E27");
            Console.WriteLine(classicLamp.TurnOnOrOff());
            classicLamp.DimmableControl(36.0);
            //classicLamp.ChangeColor(red);

            EcoLamp ecoLamp = new EcoLamp("Tapo", 60.0, 806.0, true, "E27");
            Console.WriteLine(ecoLamp.TurnOnOrOff());
            ecoLamp.DimmableControl(36.0);
            //ecoLamp.ChangeColor();
            ecoLamp.LimitTimeLampOn();
            Console.WriteLine(ecoLamp.ConsumedEnergyInWH());  




        }
    }
}
