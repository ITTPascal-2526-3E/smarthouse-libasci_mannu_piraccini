using BlaisePascal.SmartHouse.Domain.Lighting;

public class TwoLampDevice
{
    public Guid DeviceId { get; } = Guid.NewGuid();


    public Lamp MainLamp { get; private set; }


    public EcoLamp EnergySaverLamp { get; private set; }

    public TwoLampDevice(Lamp standardLamp, EcoLamp ecoLamp)
    {
        MainLamp = standardLamp ?? throw new ArgumentNullException(nameof(standardLamp));
        EnergySaverLamp = ecoLamp ?? throw new ArgumentNullException(nameof(ecoLamp));
    }


    public void TurnOnAll()
    {
        if (!MainLamp.IsLampOn()) MainLamp.TurnOnOrOff();
        if (!EnergySaverLamp.IsLampOn()) EnergySaverLamp.TurnOnOrOff();
    }


    public void TurnOffAll()
    {
        if (MainLamp.IsLampOn()) MainLamp.TurnOnOrOff();
        if (EnergySaverLamp.IsLampOn()) EnergySaverLamp.TurnOnOrOff();
    }


    public double GetEcoStats()
    {
        return EnergySaverLamp.ConsumedEnergyInWH();
    }
}
