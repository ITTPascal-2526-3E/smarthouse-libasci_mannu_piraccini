using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp
    {
        // Attributes
        // Type of lamp = LED
        string brand { get; set; }

        private string typeOfLamp = "LED";

        // Technical characteristics
        double power { get; set; } // in Watt
        double max_brightness { get; set; } // in Lumen

        // Other characteristics
        bool is_dimmable { get; set; } // true if the lamp is dimmable
        string type_of_socket { get; set; } // E27, E14, GU10

        // State of lamp (on/off)
        bool is_on { get; set; }
        // Current color of the lamp
        DateTime turnedOnTime;
        double new_brightness = 70;
        public EcoLamp(string brand_v, double power_v, double max_brightness_v, bool is_dimmable_v, string type_of_socket_v)
        {
            brand = brand_v;
            power = power_v;
            max_brightness = max_brightness_v;
            is_dimmable = is_dimmable_v;
            type_of_socket = type_of_socket_v;

        }
        public bool TurnOnOrOff()
        {
            if (is_on == true) // if the lamp is on
            {
                is_on = false; // turn it off
                return is_on;
            }
            else
            {
                is_on = true; // turn it on
                turnedOnTime = DateTime.Now;
                return is_on;
            }

        }

        public void DimmableControl(double brightness_level)
        {
            double new_brightness;
            if (is_dimmable == true && brightness_level >=1 && brightness_level <= 70)
            {
                new_brightness = max_brightness * brightness_level / 100; // adjust brightness level
            }
            else
            {
                Console.WriteLine("This lamp is not dimmable.");
            }
        }

        public enum colors_of_lamp { red, green, blue, purple, yellow, white }
        colors_of_lamp currentColorLamp { get; set; }

        public void ChangeColor(colors_of_lamp newColor)
        {
            currentColorLamp = newColor;
        }

        public DateTime AllTimeLampOn;
        public void LimitTimeLampOn()
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan TimePassed = currentTime - turnedOnTime;

            AllTimeLampOn = AllTimeLampOn.Add(TimePassed);

            if (TimePassed > TimeSpan.FromHours(2))
            {
                is_on = false;
            }
        }

        public double ConsumedEnergyInWH()
        {
            double consumedEnergy = 0;
            consumedEnergy = power * AllTimeLampOn.Hour;
            return consumedEnergy;
        }

    }

}

