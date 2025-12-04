using BlaisePascal.SmartHouse.Domain.Lighting;

public class TwoLampDevice
{
    public Guid DeviceId { get; } = Guid.NewGuid();

    // Contiene una Lampada standard
    public Lamp MainLamp { get; set; }

    // Contiene una EcoLamp
    public EcoLamp EnergySaverLamp { get; set; }

    public TwoLampDevice(Lamp standardLamp, EcoLamp ecoLamp)
    {
        MainLamp = standardLamp ?? throw new ArgumentNullException(nameof(standardLamp));
        EnergySaverLamp = ecoLamp ?? throw new ArgumentNullException(nameof(ecoLamp));
    }

    // Esempio di metodo per accendere tutto il dispositivo
    public void TurnOnAll()
    {
        if (!MainLamp.IsLampOn()) MainLamp.TurnOnOrOff();
        if (!EnergySaverLamp.IsLampOn()) EnergySaverLamp.TurnOnOrOff();
    }

    // Esempio di metodo per spegnere tutto
    public void TurnOffAll()
    {
        if (MainLamp.IsLampOn()) MainLamp.TurnOnOrOff();
        if (EnergySaverLamp.IsLampOn()) EnergySaverLamp.TurnOnOrOff();
    }

    // Metodo per ottenere il consumo totale combinato (considerando che solo EcoLamp traccia il tempo nel nostro esempio)
    public double GetEcoStats()
    {
        return EnergySaverLamp.ConsumedEnergyInWH();
    }
}
