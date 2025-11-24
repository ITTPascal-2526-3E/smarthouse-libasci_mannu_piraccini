using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        // Properties
        // Type of lamp (LED, Incandescent, Flourescent)
        string brand { get; set; }
        string type_of_lamp { get; set; }

        // Technical characteristics
        double power { get; set; } // in Watt
        double max_brightness { get; set; } // in Lumen

        // Other characteristics
        bool is_dimmable { get; set; } // true if the lamp is dimmable
        string type_of_socket { get; set; } // E27, E14, GU10

        // State of lamp
        bool is_on = false;
        double new_brightness = 100;
        private readonly object get;

        private int id { get; set; }
        
        
        public Lamp(string brand_v, string type_of_lamp_v, double power_v, double max_brightness_v, bool is_dimmable_v, string type_of_socket_v) 
        {
            brand= brand_v;
            type_of_lamp= type_of_lamp_v;
            power= power_v;
            max_brightness= max_brightness_v;
            is_dimmable= is_dimmable_v;
            type_of_socket= type_of_socket_v;
            
        }


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
            
            public bool IsOn()
            {
                return is_on;  
            }


        public void DimmableControl(double brightness_level)
        {
            double new_brightness;
            if (is_dimmable == true && brightness_level >= 1 && brightness_level <= 100)
            {
                new_brightness = max_brightness * brightness_level / 100; // adjust brightness level
            }
            else
            {
                Console.WriteLine("This lamp is not dimmable.");
            }
        }
        

       
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
    }
}
