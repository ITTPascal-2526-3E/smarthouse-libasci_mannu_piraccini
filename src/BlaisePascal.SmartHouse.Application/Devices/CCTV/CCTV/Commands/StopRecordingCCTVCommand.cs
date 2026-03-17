using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Commands
{
    public class StopRecordingCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public StopRecordingCCTVCommand(ICCTVRepository cctvRepository)
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
            if (cctv.CCTVState == CCTVStatus.Idle)
            {
                throw new InvalidOperationException($"CCTV with ID {cctvId} is not currently recording.");
            }

            cctv.StopRecording();
            _cctvRepository.Update(cctv);
        }
    }
}
