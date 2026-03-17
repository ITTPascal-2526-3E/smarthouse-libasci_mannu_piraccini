using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Queries
{
    public class GetRecordingCCTVsQuery
    {
        private readonly ICCTVRepository _cctvRepository;

        public GetRecordingCCTVsQuery(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public List<BlaisePascal.SmartHouse.Domain.CCTV.CCTV> Execute()
        {
            // Filtro tutte le telecamere per restituire solo quelle in registrazione
            var allCctvs = _cctvRepository.GetAll();
            return allCctvs.Where(c => c.CCTVState == CCTVStatus.Recording).ToList();
        }
    }
}