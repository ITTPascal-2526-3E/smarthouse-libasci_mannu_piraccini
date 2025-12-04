using System;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation
{
    public class TemperatureDevice
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Brand { get; private set; }
        public double PowerW { get; private set; }
        public bool IsOn { get; protected set; } = false;
        public double TargetTemperature { get; protected set; } = 20.0; 

        protected TemperatureDevice(string brand, double power)
        {
            Brand = brand;
            PowerW = power;
        }

        public virtual void TurnOnOrOff()
        {
            IsOn = !IsOn;
        }

        public virtual void SetTemperature(double temp)
        {
            if (IsOn == false) 
            {
                throw new InvalidOperationException($"Impossibile impostare la temperatura: il dispositivo {Brand} è spento.");
            }
            TargetTemperature = temp;
        }
    }
}