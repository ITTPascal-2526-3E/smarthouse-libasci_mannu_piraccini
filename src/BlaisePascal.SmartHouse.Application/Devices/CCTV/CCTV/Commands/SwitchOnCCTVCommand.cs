using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Commands
{
    public class SwitchOnCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public SwitchOnCCTVCommand(ICCTVRepository cctvRepository)
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
            if (cctv.Status == DeviceStatus.Online)
            {
                throw new InvalidOperationException($"CCTV with ID {cctvId} is already online.");
            }

            cctv.TurnOnOrOff(); // Passa da Offline/Error a Online
            _cctvRepository.Update(cctv);
        }
    }
}