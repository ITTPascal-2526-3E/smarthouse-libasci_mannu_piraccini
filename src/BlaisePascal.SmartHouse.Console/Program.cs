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
            EcoLamp ecoLamp = new EcoLamp("Philips", 10.0, 800.0, true, "E27");

            string inputUtente = " ";

            Console.WriteLine("\n--- Actual Status ---");
            Console.WriteLine($"The Classic Lamp ({classicLamp.brand}) is off.");

            do
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("[A] Accendi / Spegni la lampada");
                Console.WriteLine("[D] Imposta luminosità al 75%");
                Console.WriteLine("[C] Cambia colore in Verde");
                Console.WriteLine("[X] Esci dal programma");
                Console.Write("La tua scelta: ");

                inputUtente = Console.ReadLine();
                try
                {
                    if (inputUtente == null)
                    {
                        throw new ArgumentNullException("Input cannot be null.");
                    }
                    else
                    {
                        if (inputUtente == "A")
                        {
                            classicLamp.TurnOnOrOff();
                        }
                        else if (inputUtente == "D")
                        {
                            classicLamp.DimmableControl(75.0);
                        }
                        else if (inputUtente == "C")
                        {
                            classicLamp.ChangeColor(colors_of_lamp.green);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }

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