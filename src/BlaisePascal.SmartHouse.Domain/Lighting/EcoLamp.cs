using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace BlaisePascal.SmartHouse.Domain.Lighting
{
    public class EcoLamp
    {
        // Properties
        // Type of lamp = LED
        Guid id_ecoLamp = Guid.NewGuid();
        public string brand { get; set; }

        private string typeOfLamp = "LED";

        // Technical characteristics
        private double power { get; set; } // in Watt
        public double max_brightness { get; set; } // in Lumen

        // Other characteristics
        private bool is_dimmable { get; set; } // true if the lamp is dimmable
        private string type_of_socket { get; set; } // E27, E14, GU10

        // State of lamp (on/off)
        private bool is_on = false;
        // Current color of the lamp
        private DateTime turnedOnTime;
        public TimeSpan AllTimeLampOn { get; set; } = TimeSpan.Zero;

        private double currentBrightnessPercentage = 70;
        public colors_of_lamp actualColor;
        public EcoLamp(string brand_v, double power_v, double max_brightness_v, bool is_dimmable_v, string type_of_socket_v)
        {
            brand = brand_v;
            power = power_v;
            max_brightness = max_brightness_v;
            is_dimmable = is_dimmable_v;
            type_of_socket = type_of_socket_v;

        }
        public void TurnOnOrOff()

        {
            if (!is_on)
            {
                is_on = true; // turn it on
                turnedOnTime = DateTime.Now; // record the time when the lamp is turned on
            }
            else
            {
                is_on = false; // turn it off
                TimeSpan passed = DateTime.Now - turnedOnTime;
                AllTimeLampOn = AllTimeLampOn.Add(passed); // accumulate total time the lamp has been on
            }
        }

            public bool IsOn()
            {
                return is_on;
            }



        public void DimmableControl(double brightness_level)
        {
            if (!is_dimmable)
                throw new InvalidOperationException("This lamp is not dimmable.");

            if (brightness_level < 1 || brightness_level > 70)
            throw new ArgumentOutOfRangeException("brightness_level", "The brightness level must be between 1 and 70.");

            currentBrightnessPercentage = brightness_level;

        }

        public void ChangeColor(colors_of_lamp newColor)
        {
            actualColor = newColor;
        }

        public void LimitTimeLampOn()
        {
            TimeSpan added = new TimeSpan(3, 0, 0);
            AllTimeLampOn = AllTimeLampOn.Add(added);

            if (AllTimeLampOn > TimeSpan.FromHours(2))
            {
                is_on = false;
            }
        }

        public double ConsumedEnergyInWH()
        {
            double consumedEnergy = power * AllTimeLampOn.TotalHours;
            return consumedEnergy;
        }

    }

}
