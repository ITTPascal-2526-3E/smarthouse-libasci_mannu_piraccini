using BlaisePascal.SmartHouse.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BlaisePascal.SmartHouse.Domain.Lighting
{
    public class Lamp : ILuminous
    {
        // Properties
        // Type of lamp (LED, Incandescent, Flourescent)
        public Guid id_lamp = Guid.NewGuid();
        public string brand { get; private set; }
        public string TypeOfLamp { get; private set; }

        // Technical characteristics
        public double Power { get; private set; } // in Watt
        public double max_brightness { get; private set; } // in Lumen

        // Other characteristics
        public bool IsDimmable { get; private set; } // true if the lamp is dimmable
        public string TypeOfSocket { get; private set; } // E27, E14, GU10
        public bool IsOn { get;  set; } 


        // State of lamp
        public double current_brightness_percentage { get; private set; } = 100.0;  
        public colors_of_lamp actualColor { get; private set; }


        public Lamp(string brand_v, string type_of_lamp_v, double power_v, double max_brightness_v, bool is_dimmable_v, string type_of_socket_v)
        {
            brand = brand_v;
            TypeOfLamp = type_of_lamp_v;
            Power = power_v;
            max_brightness = max_brightness_v;
            IsDimmable = is_dimmable_v;
            TypeOfSocket = type_of_socket_v;
            

        }


        public virtual void TurnOnOrOff()
        {
            IsOn = !IsOn;
        }
       
        public virtual void DimmableControl(double brightness_level)
        {
            if (!IsDimmable)
            {
                throw new InvalidOperationException($"Error - This lamp '{brand}' is not dimmable.");
            }
            if (brightness_level < 1.0 || brightness_level > 100.0)
            {
                throw new ArgumentOutOfRangeException(nameof(brightness_level), $"Error - The brightness level must be between 1 and 100.");
            }
            current_brightness_percentage = brightness_level;
        }

       

        public void ChangeColor(colors_of_lamp newColor)
        {
            if (TypeOfLamp != "LED")
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
