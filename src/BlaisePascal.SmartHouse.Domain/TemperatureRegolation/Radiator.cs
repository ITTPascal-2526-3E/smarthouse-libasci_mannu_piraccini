using System;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation
{
    public class Radiator : TemperatureDevice
    {
        public int NumberOfElements { get; set; }

        public Radiator(string brand, double power, int elements)
            : base(brand, power)
        {
            NumberOfElements = elements;
        }

        public override void SetTemperature(double temp)
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("The radiator is off. Please turn it on before adjusting the thermostat.");
            }
            else if (temp < TargetTemperature)
            {
                throw new InvalidOperationException("you can only increase the temperature");
            }

            TargetTemperature = temp;
        }
    }
}