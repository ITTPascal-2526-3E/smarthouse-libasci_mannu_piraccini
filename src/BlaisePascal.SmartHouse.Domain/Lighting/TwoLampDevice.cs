using BlaisePascal.SmartHouse.Console;
using BlaisePascal.SmartHouse.Domain.Lighting;

public sealed class TwoLampDevice   // ISwithcable
{
    public Guid DeviceId { get; } = Guid.NewGuid();


    public Lamp MainLamp { get; private set; }


    public EcoLamp EnergySaverLamp { get; private set; }

    public TwoLampDevice(Lamp standardLamp, EcoLamp ecoLamp)
    {
        MainLamp = standardLamp ?? throw new ArgumentNullException(nameof(standardLamp));
        EnergySaverLamp = ecoLamp ?? throw new ArgumentNullException(nameof(ecoLamp));
    }


    public void TurnOnOrOff()
    {
        if  (!MainLamp.IsOn && !EnergySaverLamp.IsOn) 
        {
            MainLamp.TurnOnOrOff();
            EnergySaverLamp.TurnOnOrOff();
        }

        else if (MainLamp.IsOn && EnergySaverLamp.IsOn)
        {
                MainLamp.TurnOnOrOff();
                EnergySaverLamp.TurnOnOrOff();
        }

        else if (!MainLamp.IsOn && EnergySaverLamp.IsOn)
        {
            EnergySaverLamp.TurnOnOrOff();
        }

        else 
        {
            MainLamp.TurnOnOrOff();
        }

    }


    public double GetEcoStats()
    {
        return EnergySaverLamp.ConsumedEnergyInWH();
    }
}
