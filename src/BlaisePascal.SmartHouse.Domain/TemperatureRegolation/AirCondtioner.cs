using System;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation
{
    public sealed class AirConditioner : TemperatureDevice
    {
        //additional attributes compared to the mother class
        public AcMode CurrentMode { get; private set; }
        public int FanSpeed { get; private set; }

        //constructor in which attributes of the mother class are also passed
        public AirConditioner(string brand, double power)
            : base(brand, power)
        {
            CurrentMode = AcMode.Cooling;
            FanSpeed = 3;
        }

        //Changes the mode
        public void SetMode(AcMode mode)
        {
            if (IsOn == false)
                throw new InvalidOperationException("Cannot change mode while the device is off.");

            CurrentMode = mode;
        }

        //changes fan speed
        public void SetFanSpeed(int speed)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot change fan speed while the device is off.");

            if (speed < 1 || speed > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(speed), "Fan speed must be between 1 and 5.");
            }

            FanSpeed = speed;
        }
    }
}