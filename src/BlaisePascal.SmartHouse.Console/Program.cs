using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class Program
    {
        public enum colors_of_lamp { red, green, blue, purple, yellow, white }
        static void Main(string[] args)
        {
            Lamp classicLamp = new Lamp("Tapo", "LED", 60.0, 806.0, true, "E27");
            classicLamp.TurnOnOrOff();
            classicLamp.DimmableControl(36.0);
            //classicLamp.ChangeColor(red);

            EcoLamp ecoLamp = new EcoLamp("Tapo", 60.0, 806.0, true, "E27");
            ecoLamp.TurnOnOrOff();
            ecoLamp.DimmableControl(36.0);
            //ecoLamp.ChangeColor();
            ecoLamp.LimitTimeLampOn();
            Console.WriteLine("The energy consumed in watts is: " + ecoLamp.ConsumedEnergyInWH());
        }
    }
}