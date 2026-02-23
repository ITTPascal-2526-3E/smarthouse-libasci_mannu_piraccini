using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Queries
{
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetAllLampsQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<BlaisePascal.SmartHouse.Domain.Lighting.Lamp> Execute()
        {
            return _lampRepository.GetAll();
        }
    }
}