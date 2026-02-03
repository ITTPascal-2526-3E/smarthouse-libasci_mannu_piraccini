using System;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation
{
    public sealed class Radiator : TemperatureDevice
    {
        //additional attributes compared to the mother class
        public int NumberOfElements { get; set; }

        //constructor in which attributes of the mother class are also passed
        public Radiator(string brand, double power, int elements)
            : base(brand, power)
        {
            NumberOfElements = elements;
        }

        //override of the mother class SetTemperature because it should only be able to increase the temperature
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
