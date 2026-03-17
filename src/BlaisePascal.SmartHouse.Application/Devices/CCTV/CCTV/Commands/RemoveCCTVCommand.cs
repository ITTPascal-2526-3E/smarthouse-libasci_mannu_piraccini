using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Commands
{
    public class RemoveCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public RemoveCCTVCommand(ICCTVRepository cctvRepository)
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

            // A differenza di Lamp, qui passiamo l'intera entità al metodo Delete del repository
            _cctvRepository.Delete(cctv);
        }
    }
}