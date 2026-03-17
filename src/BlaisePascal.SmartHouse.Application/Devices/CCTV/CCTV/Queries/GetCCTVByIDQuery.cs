using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Queries
{
    public class GetCCTVByIDQuery
    {
        private readonly ICCTVRepository _cctvRepository;

        public GetCCTVByIDQuery(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public BlaisePascal.SmartHouse.Domain.CCTV.CCTV Execute(Guid cctvId)
        {
            var cctv = _cctvRepository.GetById(cctvId);

            if (cctv == null)
            {
                throw new InvalidOperationException($"Errore: Telecamera con ID {cctvId} non trovata.");
            }

            return cctv;
        }
    }
}