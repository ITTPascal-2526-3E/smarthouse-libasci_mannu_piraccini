using BlaisePascal.SmartHouse.Domain.Lighting;

namespace BlaisePascal.SmartHouse.Domain.Lighting
{
    public class TwoLampDevice
    {
        public EcoLamp eco;
        public Lamp normal;

        public TwoLampDevice(EcoLamp ecoLamp, Lamp normalLamp)
        {
            eco = ecoLamp;
            normal = normalLamp;
        }

        public void EcoOnOff()
        {
            eco.TurnOnOrOff();
        }

        public void NormalOnOff()
        {
            normal.TurnOnOrOff();
        }

        public void BothOn()
        {
            if (!eco.IsOn()) eco.TurnOnOrOff();
            if (!normal.IsOn()) normal.TurnOnOrOff();
        }

        public void BothOff()
        {
            if (eco.IsOn()) eco.TurnOnOrOff();
            if (normal.IsOn()) normal.TurnOnOrOff();
        }

        public void EcoBrightness(double level)
        {
            eco.DimmableControl(level);
        }

        public void NormalBrightness(double level)
        {
            normal.DimmableControl(level);
        }

        public void BothBrightness(double level)
        {
            eco.DimmableControl(level);
            normal.DimmableControl(level);
        }

        public void EcoColor(colors_of_lamp color)
        {
            eco.ChangeColor(color);
        }

        public void NormalColor(colors_of_lamp color)
        {
            normal.ChangeColor(color);
        }

        public void BothColor(colors_of_lamp color)
        {
            eco.ChangeColor(color);
            normal.ChangeColor(color);
        }

        public string GetStatus()
        {
            return $"Eco: {(eco.IsOn() ? "ON" : "OFF")} | Normal: {(normal.IsOn() ? "ON" : "OFF")}";
        }

        public double EcoEnergy()
        {
            return eco.ConsumedEnergyInWH();
        } 

    }
}
