using System;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation
{
    public class AirConditioner : TemperatureDevice
    {
        public AcMode CurrentMode { get; private set; }
        public int FanSpeed { get; private set; }

        public AirConditioner(string brand, double power)
            : base(brand, power)
        {
            CurrentMode = AcMode.Cooling;
            FanSpeed = 3;
        }

        public void SetMode(AcMode mode)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot change mode while the device is off.");

            CurrentMode = mode;
        }

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