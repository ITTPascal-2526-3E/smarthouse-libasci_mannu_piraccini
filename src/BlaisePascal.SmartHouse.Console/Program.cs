using BlaisePascal.SmartHouse.Domain.Lighting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exitFlag = 0;
            // Istanziazione con i nuovi nomi delle classi e costruttori
            Lamp classicLamp = new Lamp("Tapo", "LED", 60.0, 806.0, true, "E27");
            EcoLamp ecoLamp = new EcoLamp("Philips", 10.0, 800.0, true, "E27");

            // Variabile per il dispositivo a doppia lampada (inizialmente null)
            TwoLampDevice? doubleDevice = null;

            string inputUtente = " ";

            Console.WriteLine("\n--- Actual Status ---");
            Console.WriteLine($"The Classic Lamp ({classicLamp.brand}) is off.");

            do
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("[A] Turn On / Off the Classic Lamp");
                Console.WriteLine("[B] Set Classic Lamp brightness (0-100)");
                Console.WriteLine("[C] Change Classic Lamp color");
                Console.WriteLine("[D] Turn On / Off the EcoLamp");
                Console.WriteLine("[E] Limit EcoLamp operating hours (Simulate Check)");
                Console.WriteLine("[F] Check EcoLamp consumed energy");
                Console.WriteLine("[G] Change EcoLamp color");
                Console.WriteLine("[H] Visualize Classic Lamp state");
                Console.WriteLine("[I] Visualize Eco Lamp state");
                Console.WriteLine("[J] Create new EcoLamp");
                Console.WriteLine("[K] Create new Classic Lamp");
                Console.WriteLine("[L] Create TwoLampDevice (combines current lamps)");
                Console.WriteLine("[M] Turn On All Lamps in TwoLampDevice");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("[X] Exit");
                Console.Write("Your choice: ");

                inputUtente = Console.ReadLine()?.ToUpper(); // Gestisce null e converte in maiuscolo
                Console.WriteLine();

                try
                {
                    if (string.IsNullOrEmpty(inputUtente))
                    {
                        Console.WriteLine("Input cannot be empty.");
                    }
                    else
                    {
                        switch (inputUtente)
                        {
                            // --- CLASSIC LAMP ---
                            case "A":
                                classicLamp.TurnOnOrOff();
                                Console.WriteLine($"The Classic Lamp is now {(classicLamp.IsLampOn() ? "On" : "Off")}.");
                                break;

                            case "B":
                                Console.Write("Enter brightness level (1-100): ");
                                if (double.TryParse(Console.ReadLine(), out double bLevel))
                                {
                                    classicLamp.DimmableControl(bLevel);
                                    Console.WriteLine($"The brightness of the Classic Lamp has been set to {bLevel}%.");
                                }
                                else Console.WriteLine("Invalid number.");
                                break;

                            case "C":
                                ChangeLampColor(classicLamp);
                                break;

                            // --- ECOLAMP ---
                            case "D":
                                ecoLamp.TurnOnOrOff();
                                Console.WriteLine($"The EcoLamp is now {(ecoLamp.IsLampOn() ? "On" : "Off")}.");
                                break;

                            case "E":
                                ecoLamp.LimitTimeLampOn();
                                Console.WriteLine("Limit time control executed for EcoLamp (simulated time added).");
                                break;

                            case "F":
                                double consumo = ecoLamp.ConsumedEnergyInWH();
                                Console.WriteLine($"The EcoLamp consumed energy: {consumo:F2} Wh");
                                break;

                            case "G":
                                ChangeLampColor(ecoLamp);
                                break;

                            // --- VISUALIZATION ---
                            case "H":
                                PrintLampInfo(classicLamp);
                                break;

                            case "I":
                                PrintLampInfo(ecoLamp);
                                break;

                            // --- CREATION ---
                            case "J": // Create EcoLamp
                                Console.WriteLine("Creating new EcoLamp...");
                                ecoLamp =;
                                Console.WriteLine("New EcoLamp created and selected!");
                                break;

                            case "K": // Create Classic Lamp
                                Console.WriteLine("Creating new Classic Lamp...");
                                classicLamp = ;
                                Console.WriteLine("New Classic Lamp created and selected!");
                                break;

                            // --- TWO LAMP DEVICE ---
                            case "L":
                                doubleDevice = new TwoLampDevice(classicLamp, ecoLamp);
                                Console.WriteLine($"TwoLampDevice created with ID: {doubleDevice.DeviceId}");
                                Console.WriteLine("This device now controls both the current Classic and Eco lamps.");
                                break;

                            case "M":
                                if (doubleDevice != null)
                                {
                                    doubleDevice.TurnOnAll();
                                    Console.WriteLine("Both lamps have been turned ON via the TwoLampDevice.");
                                }
                                else
                                {
                                    Console.WriteLine("Error: Create the TwoLampDevice [L] first.");
                                }
                                break;

                            case "X":
                                exitFlag = 1;
                                break;

                            default:
                                Console.WriteLine("Command not recognized.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                if (exitFlag == 0)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (exitFlag == 0);
        }

        // --- Helper Methods ---

        static void ChangeLampColor(Lamp lamp)
        {
            Console.WriteLine("Choose color: Red, Green, Blue, WarmWhite, White");
            string inputColor = Console.ReadLine();

            // Il parametro 'true' rende il parsing case-insensitive
            if (Enum.TryParse(inputColor, true, out colors_of_lamp chosenColor))
            {
                lamp.ChangeColor(chosenColor);
                Console.WriteLine($"The color has been changed to {lamp.actualColor}.");
            }
            else
            {
                Console.WriteLine("Invalid color.");
            }
        }

        static void PrintLampInfo(Lamp lamp)
        {
            Console.WriteLine("\n--- Lamp Info ---");
            Console.WriteLine($"ID: {lamp.id_lamp}");
            Console.WriteLine($"Brand: {lamp.brand}");
            Console.WriteLine($"Type: {lamp.TypeOfLamp}"); // Proprietà ereditata corretta
            Console.WriteLine($"Power: {lamp.Power} W");
            Console.WriteLine($"Max Brightness: {lamp.max_brightness} Lumen");
            Console.WriteLine($"Dimmable: {lamp.IsDimmable}");
            Console.WriteLine($"Socket: {lamp.TypeOfSocket}");
            Console.WriteLine($"State: {(lamp.IsLampOn() ? "ON" : "OFF")}");
            Console.WriteLine($"Color: {lamp.actualColor}");

            // Polimorfismo: se è una EcoLamp, mostra info extra
            if (lamp is EcoLamp eco)
            {
                Console.WriteLine($"[Eco] Total Time On: {eco.AllTimeLampOn}");
                Console.WriteLine($"[Eco] Consumed Energy: {eco.ConsumedEnergyInWH():F2} Wh");
            }
            Console.WriteLine("---------------------\n");
        }
    }
}

