using System;
using System.Runtime.CompilerServices;
using BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Lighting
{
    public sealed class EcoLamp : Lamp
    {
        private DateTime turnedOnTime;
        public TimeSpan AllTimeLampOn { get; set; } = TimeSpan.Zero;

        private double currentBrightnessPercentage = 70;

        public EcoLamp(Brand  brand_v, double power_v, double max_brightness_v, bool is_dimmable_v, string type_of_socket_v) : base(brand_v, "EcoLamp", power_v, max_brightness_v, is_dimmable_v, type_of_socket_v)
        //CHIEDERE AL PROF SE BISOGNA IMPLEMENTARE TUTTI I VALUE OBJECT COME FATTO CON BRAN SOPRA
        {
        }

        public override void TurnOnOrOff()
        {
            if (!IsOn)
            {
                base.TurnOnOrOff();
                if (IsOn)
                {
                    turnedOnTime = DateTime.Now;
                }
            }
            else
            {
                TimeSpan passed = DateTime.Now - turnedOnTime;
                AllTimeLampOn = AllTimeLampOn.Add(passed);
                base.TurnOnOrOff();
            }
        }

        public override void DimmableControl(double brightness_level)
        {
            if (!IsDimmable)
                throw new InvalidOperationException($"This lamp '{brand}' is not dimmable.");

           
            if (brightness_level < 1 || brightness_level > 70)
                throw new ArgumentOutOfRangeException(nameof(brightness_level), "The brightness level must be between 1 and 70.");

            currentBrightnessPercentage = brightness_level;

        }

        public void LimitTimeLampOn()
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan TimePassed = currentTime - turnedOnTime;

            AllTimeLampOn = AllTimeLampOn.Add(TimePassed);

            if (TimePassed > TimeSpan.FromHours(2))
            {
                IsOn = false;
            }
        }

        public double ConsumedEnergyInWH()
        {
            double consumedEnergy = Power * AllTimeLampOn.TotalHours;
            return consumedEnergy;
        }
    }
}