using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Lamp classicLamp = new Lamp("Tapo", "LED", 60.0, 806.0, true, "E27");
            if (classicLamp.IsOn() == false) 
            {
                Console.WriteLine("Classic Lamp is off");
            
            }

            string lampSwich;
            do
            {
                Console.WriteLine("Per accendere la lampadina premere 'A'");
                lampSwich = (Console.ReadLine());

            } while (lampSwich != "A");

            if (classicLamp.IsOn() == true)
            {
                classicLamp.TurnOnOrOff();
                Console.WriteLine("The classic lamp is off.");
            }
            else
            {
                classicLamp.TurnOnOrOff();
                Console.WriteLine("The classic lamp is on.");
            }
                
             classicLamp.DimmableControl(36.0);
            //classicLamp.ChangeColor(red);

            EcoLamp ecoLamp = new EcoLamp("Tapo", 60.0, 806.0, true, "E27");
            ecoLamp.TurnOnOrOff();
            if(ecoLamp.IsOn() == true)
            {
                Console.WriteLine("The eco lamp is on.");
            }
            else
            {
                Console.WriteLine("The eco lamp is off.");
            }
                ecoLamp.DimmableControl(36.0);
            //ecoLamp.ChangeColor();
            ecoLamp.LimitTimeLampOn();
            Console.WriteLine("The energy consumed in watts is: " + ecoLamp.ConsumedEnergyInWH());
        }
    }
}