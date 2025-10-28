namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        // Attributes
        // Type of lamp (LED, Incandescent, Flourescent)
        string brand { get; set; }
        string type_of_lamp { get; set; }

        // Technical characteristics
        double power { get; set; } // in Watt
        double max_brightness { get; set; } // in Lumen
        double color_temperature { get; set; } // in Kelvin

        // Other characteristics
        double duration { get; set; } // in hours
        bool is_dimmable { get; set; } // true if the lamp is dimmable
        string type_of_socket { get; set; } // E27, E14, GU10

        // State of lamp (on/off)
        bool is_on { get; set; }

        public void TurnOnOrOff()
        {
            if (is_on == true) // if the lamp is on 
            {
                is_on = false; // turn it off
            }
            else
            {
                is_on = true; // turn it on
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
    }
}
