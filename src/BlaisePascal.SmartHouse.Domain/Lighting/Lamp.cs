using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BlaisePascal.SmartHouse.Domain.Lighting
{
    public class Lamp
    {
        // Properties
        // Type of lamp (LED, Incandescent, Flourescent)
        public string brand { get; set; }
        string type_of_lamp { get; set; }

        // Technical characteristics
        double power { get; set; } // in Watt
        public double max_brightness { get; set; } // in Lumen

        // Other characteristics
        bool is_dimmable { get; set; } // true if the lamp is dimmable
        string type_of_socket { get; set; } // E27, E14, GU10

        // State of lamp
        bool is_on = false;
        private double current_brightness_percentage = 100;
        public colors_of_lamp actualColor { get; set; }


        private int id { get; set; }


        public Lamp(string brand_v, string type_of_lamp_v, double power_v, double max_brightness_v, bool is_dimmable_v, string type_of_socket_v)
        {
            brand = brand_v;
            type_of_lamp = type_of_lamp_v;
            power = power_v;
            max_brightness = max_brightness_v;
            is_dimmable = is_dimmable_v;
            type_of_socket = type_of_socket_v;

        }

        /*
         public void TurnOnOrOff()
        {
         if (is_on == false) // if the lamp is off
            {
                is_on = true; // turn it on
            }
            else
            {
                is_on = false; // turn it off
            } 
        }
        */

        public void TurnOnOrOff()
        {
            is_on = !is_on;
        }

        public bool IsOn()
        {
            return is_on;
        }

        /*
         public void DimmableControl(double brightness_level)
        {
            if (!is_dimmable)
            {
                Console.WriteLine($"Errore - This lamp is not dimmable.");
                return;
            }
            if (brightness_level < 1.0 || brightness_level > 100.0)
            {
                Console.WriteLine($"Error - The brightness level must be between 1 and 100.");
                return;
            }

            current_brightness_percentage = brightness_level;
            Console.WriteLine($"The brightness level has been set to {current_brightness_percentage}%.");
        }
         */
        public void DimmableControl(double brightness_level)
        {
            if (!is_dimmable)
            {
                throw new InvalidOperationException($"Error - This lamp '{brand}' is not dimmable.");
            }
            if (brightness_level < 1.0 || brightness_level > 100.0)
            {
                throw new ArgumentOutOfRangeException(nameof(brightness_level), $"Error - The brightness level must be between 1 and 100.");
            }
            current_brightness_percentage = brightness_level;
        }

        /*
         public void ChangeColor(colors_of_lamp newColor)
        {
            colors_of_lamp actualColor;
            if (type_of_lamp == "LED")
            {
                actualColor = newColor;
            }
            else
            {
                Console.WriteLine("Error - The selected lamp type is not led RGB");
            }
        }
        */

        public void ChangeColor(colors_of_lamp newColor)
        {
            if (type_of_lamp != "LED")
            {
                throw new InvalidOperationException("Error - The selected lamp type is not led RGB");
            }
            else
            {
                actualColor = newColor;
            }
        }
    }
}
