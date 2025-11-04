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
            classicLamp.TurnOnOrOff();
            if (classicLamp.IsOn() == true)
            {
                Console.WriteLine("The classic lamp is on.");
            }
            else
            {
                Console.WriteLine("The classic lamp is off.");
            }

            Console.WriteLine("Per accendere o spegnere la lampadina premere 'A'");
            string cici = (Console.ReadLine());
            if (cici== "A") {
                if(classicLamp.IsOn() == true)
                {
                    Console.WriteLine("The classic lamp is on.");
                }
               
            }
            classicLamp.TurnOnOrOff();
            if (classicLamp.IsOn() == true)
            {
                Console.WriteLine("The classic lamp is on.");
            }
            else
            {
                Console.WriteLine("The classic lamp is off.");
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