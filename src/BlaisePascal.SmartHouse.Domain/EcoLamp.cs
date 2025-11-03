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
        string type_of_lamp { get; set; }

        // Technical characteristics
        double power { get; set; } // in Watt
        double max_brightness { get; set; } // in Lumen
        double color_temperature { get; set; } // in Kelvin

        // Other characteristics
        bool is_dimmable { get; set; } // true if the lamp is dimmable
        string type_of_socket { get; set; } // E27, E14, GU10

        // State of lamp (on/off)
        bool is_on { get; set; }
        // Current color of the lamp

        public void TurnOnOrOff()
        {
            if (is_on == true) // if the lamp is on
            {
                is_on = false; // turn it off
            }
            else
            {
                is_on = true; // turn it on
                DateTime turnedOnTime = DateTime.Now;
            }

        }

        public void DimmableControl(double brightness_level)
        {
            double new_brightness;
            if (is_dimmable == true)
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


        public void TimePassedSinceLampOn()
        {
            DateTime currentTime = DateTime.Now;
        }


    }
}
