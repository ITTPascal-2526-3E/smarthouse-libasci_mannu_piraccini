using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Commands
{
    public class StartRecordingCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public StartRecordingCCTVCommand(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid cctvId)
        {
            var cctv = _cctvRepository.GetById(cctvId);
            if (cctv == null)
            {
                throw new InvalidOperationException($"CCTV with ID {cctvId} not found.");
            }
            if (cctv.CCTVState == CCTVStatus.Recording)
            {
                throw new InvalidOperationException($"CCTV with ID {cctvId} is already recording.");
            }
            if (cctv.Status != DeviceStatus.Online)
            {
                throw new InvalidOperationException($"CCTV with ID {cctvId} cannot record because it is not Online.");
            }

            cctv.StartRecording();
            _cctvRepository.Update(cctv);
        }
    }
}
