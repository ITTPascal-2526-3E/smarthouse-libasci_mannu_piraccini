using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository; 

namespace BlaisePascal.SmartHouse.Application.Devices.TemperatureRegolationDevice.Radiator.Queries
{
    public class GetAllRadiatorsQuery
    {
        private readonly IRadiatorRepository _radiatorRepository;

        public GetAllRadiatorsQuery(IRadiatorRepository radiatorRepository)
        {
            _radiatorRepository = radiatorRepository;
        }

        public List<BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Radiator> Execute()
        {
            return _radiatorRepository.GetAll();
        }
    }
}
