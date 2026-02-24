using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.CCTV;
using System;

public sealed class CCTV : ISwitchable
{

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DeviceStatus Status { get; private set; }
    public CCTVStatus CCTVState { get; private set; }
    public int ImageResolution { get; private set; }
    public bool NightVision { get; set; }
    public string Lens { get; private set; }
    public bool WideDynamicRange { get; private set; }
    public bool WeatherResistance { get; private set; }
    public int Connectivity { get; private set; }
    public string Storage { get; private set; }
    public bool DataCompression { get; private set; }

    public CCTV(string name)
    {
        Id = Guid.NewGuid();        // genera ID unico
        Name = name;                // nome della camera

        Status = DeviceStatus.Offline;  // stato iniziale
        CCTVState = CCTVStatus.Idle;    // stato iniziale
    }

    public void TurnOnOrOff()
    {
        if (Status == DeviceStatus.Offline)
        {
            Status = DeviceStatus.Online;
        }
        else
        {
            Status = DeviceStatus.Offline;
            CCTVState = CCTVStatus.Idle;
        }


    }

    public void StartRecording()
    {
        if (Status == DeviceStatus.Online)
        {
            CCTVState = CCTVStatus.Recording;
        }
    }

    public void StopRecording()
    {
        CCTVState = CCTVStatus.Idle;
    }

    public void SetError()
    {
        Status = DeviceStatus.Error;
        CCTVState = CCTVStatus.Idle;
    }
}
