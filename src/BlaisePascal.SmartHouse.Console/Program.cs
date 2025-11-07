using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int y = 0;

            Lamp classicLamp = new Lamp("Tapo", "LED", 60.0, 806.0, true, "E27");
            EcoLamp ecoLamp = new EcoLamp("Tapo", 60.0, 806.0, true, "E27");

            do
            {              
                if (classicLamp.IsOn() == false)
                {
                    Console.WriteLine("Classic Lamp is off");

                }

                string lampSwich;
                do
                {
                    Console.WriteLine("To turn on or off the light, press 'A'");
                    lampSwich = (Console.ReadLine());
                    if (lampSwich != "A")
                    {
                        Console.WriteLine("'A' was not typed");
                    }

                } while (lampSwich != "A");

                Console.WriteLine("");

                if (classicLamp.IsOn() == true)
                {
                    classicLamp.TurnOnOrOff();
                    Console.WriteLine("- The classic lamp is off.");
                }
                else
                {
                    classicLamp.TurnOnOrOff();
                    Console.WriteLine("- The classic lamp is on.");
                }

                classicLamp.DimmableControl(36.0);
                //classicLamp.ChangeColor(red);

                
                ecoLamp.TurnOnOrOff();
                if (ecoLamp.IsOn() == true)
                {
                    Console.WriteLine("- The eco lamp is on.");
                }
                else
                {
                    Console.WriteLine("- The eco lamp is off.");
                }
                ecoLamp.DimmableControl(36.0);
                //ecoLamp.ChangeColor();
                ecoLamp.LimitTimeLampOn();
                Console.WriteLine("- The energy consumed in watts is: " + ecoLamp.ConsumedEnergyInWH());

                Console.WriteLine("");
                string exit;
                Console.WriteLine("If you wish to exit, press 'X', otherwise press any other key");
                exit = Console.ReadLine();
                if (exit == "X")
                {
                    y = 1;
                }
                else
                {
                    y = 0;
                }

            } while (y == 0);
        }
    }
}