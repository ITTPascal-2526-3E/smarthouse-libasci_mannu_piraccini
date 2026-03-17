using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Commands
{
    public class SetErrorCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public SetErrorCCTVCommand(ICCTVRepository cctvRepository)
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

            cctv.SetError();
            _cctvRepository.Update(cctv);
        }
    }
}
