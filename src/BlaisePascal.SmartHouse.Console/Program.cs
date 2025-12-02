using BlaisePascal.SmartHouse.Domain.Lighting;
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
            int exitFlag = 0;
            Lamp classicLamp = new Lamp("Tapo", "LED", 60.0, 806.0, true, "E27");
            EcoLamp ecoLamp = new EcoLamp("Philips", 10.0, 800.0, true, "E27");

            string inputUtente = " ";

            Console.WriteLine("\n--- Actual Status ---");
            Console.WriteLine($"The Classic Lamp ({classicLamp.brand}) is off.");

            do
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("[A] Turn On / Off the Classic Lamp");
                Console.WriteLine("[D] Set Classic Lamp brightness to 75%");               
                Console.WriteLine("[C] Change Classic Lamp color");             
                Console.WriteLine("[E] Turn On / Off the EcoLamp");
                Console.WriteLine("[F] Limit EcoLamp operating hours");
                Console.WriteLine("[H] Change EcoLamp color");
                Console.WriteLine("[X] Exit the program");
                Console.Write("Your choice: ");

                inputUtente = Console.ReadLine();
                try
                {
                    if (inputUtente == null)
                    {
                        throw new ArgumentNullException("Input cannot be null.");
                    }
                    else
                    {
                        // Classic Lamp
                        if (inputUtente == "A")
                        {
                            classicLamp.TurnOnOrOff();
                            Console.WriteLine($"The Classic Lamp is now {(classicLamp.IsOn() ? "On" : "Off")}.");
                        }
                        else if (inputUtente == "D")
                        {
                            classicLamp.DimmableControl(75.0);
                            Console.WriteLine("The brightness of the Classic Lamp has been set to 75%.");
                        }
                        else if (inputUtente == "C")
                        {
                            Console.WriteLine("Now choose the color you want to apply to the lamp");
                            string newColor = "";
                            do {
                                Console.WriteLine("Choose from these colors: red, green, blue, purple, yellow, white");
                                newColor = Console.ReadLine();

                            } while (newColor != "red" && newColor != "green" && newColor != "blue" && newColor != "purple" && newColor != "yellow" && newColor != "white");

                            colors_of_lamp chosenColor = Enum.Parse<colors_of_lamp>(newColor);
                            classicLamp.ChangeColor(chosenColor);
                            Console.WriteLine($"The color of the Classic Lamp has been changed to {chosenColor}.");                         

                        }

                        // EcoLamp
                        else if (inputUtente == "E")
                        {
                            ecoLamp.TurnOnOrOff();
                            Console.WriteLine($"The EcoLamp is now {(ecoLamp.IsOn() ? "On" : "Off")}.");
                        }
                        else if (inputUtente == "F")
                        {
                            ecoLamp.LimitTimeLampOn();
                            Console.WriteLine("Limit time control executed for EcoLamp.");
                        }
                        else if (inputUtente == "G")
                        {
                            double consumo = ecoLamp.ConsumedEnergyInWH();
                            Console.WriteLine($"The EcoLamp consumed energy: {consumo} Wh");
                        }
                        else if (inputUtente == "H")
                        {
                            Console.WriteLine("Now choose the color you want to apply to the Ecolamp");
                            string newColor = "";
                            do
                            {
                                Console.WriteLine("Choose from these colors: red, green, blue, purple, yellow, white");
                                newColor = Console.ReadLine();

                            } while (newColor != "red" && newColor != "green" && newColor != "blue" && newColor != "purple" && newColor != "yellow" && newColor != "white");

                            colors_of_lamp chosenColor = Enum.Parse<colors_of_lamp>(newColor);
                            ecoLamp.ChangeColor(chosenColor);
                            Console.WriteLine($"The color of the EcoLamp has been changed to {chosenColor}.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }

                Console.WriteLine("If you wish to exit, press 'X', otherwise press any other key");
                string exit = Console.ReadLine();
                if (exit == "X")
                {
                    exitFlag = 1;
                }
                else
                {
                    exitFlag = 0;
                }

            } while (exitFlag == 0);
        }
    }
}