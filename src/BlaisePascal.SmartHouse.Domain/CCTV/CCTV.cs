using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV
{
    public sealed class CCTV : ISwitchable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DeviceStatus Status { get; private set; } // Offline, Online, Error
        public CCTVStatus CCTVState { get; private set; } // Idle, Recording, MotionDetected
        public int ImageResolution { get; private set; }
        public bool NightVision { get; set; }
        public string Lens { get; private set; }
        public bool WideDynamicRange { get; private set; }
        public bool WeatherResistance { get; private set; }
        public int Connectivity { get; private set; }
        public string Storage { get; private set; } 
        public bool DataCompression { get; private set; }

       
        private int _storageCapacityMB;
        private int _storageUsedMB;

        public CCTV(string name, int storageMB)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Offline;
            CCTVState = CCTVStatus.Idle;

            ImageResolution = 1080;
            _storageCapacityMB = storageMB;
            _storageUsedMB = 0;
            Storage = "Internal";
        }

        public void TurnOnOrOff()
        {
            if (Status == DeviceStatus.Offline)
            {
                Status = DeviceStatus.Online;
                CCTVState = CCTVStatus.Idle;
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
                
                if (_storageUsedMB < _storageCapacityMB)
                {
                    CCTVState = CCTVStatus.Recording;
                    
                    _storageUsedMB += 100;
                }
                else
                {
                    SetError();
                }
            }
        }

        public void StopRecording()
        {
            if (Status == DeviceStatus.Online)
            {
                CCTVState = CCTVStatus.Idle;
            }
        }

        public void FormatMemory()
        {
            if (Status == DeviceStatus.Online && CCTVState != CCTVStatus.Recording)
            {
                _storageUsedMB = 0;
            }
        }

        public void SetError()
        {
            Status = DeviceStatus.Error;
            CCTVState = CCTVStatus.Idle;
        }
    }
}
