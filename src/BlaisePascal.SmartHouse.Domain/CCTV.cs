using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class CCTV
    {
       
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public CCTVStatus CCTVState { get; set; }
        public int ImageResolution { get; set; }
        public bool NightVision { get; set; }
        public string Lens { get; set; }
        public bool WideDynamicRange { get; set; }
        public bool WeatherResistance { get; set; }      
        public int Connectivity { get; set; }
        public string Storage { get; set; }
        public bool DataCompression { get; set; }

        public CCTV(string name)
        {
            Id = Guid.NewGuid();        // genera ID unico
            Name = name;                // nome della camera

            Status = DeviceStatus.Offline;  // stato iniziale
            CCTVState = CCTVStatus.Idle;    // stato iniziale
        }

        public void TurnOn()
        {
            Status = DeviceStatus.Online;
        }

        public void TurnOff()
        {
            Status = DeviceStatus.Offline;
            CCTVState = CCTVStatus.Idle;
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
}

