using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Queries
{
    public class GetAllCCTVsQuery
    {
        private readonly ICCTVRepository _cctvRepository;

        public GetAllCCTVsQuery(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public List<BlaisePascal.SmartHouse.Domain.CCTV.CCTV> Execute()
        {
            return _cctvRepository.GetAll();
        }
    }
}