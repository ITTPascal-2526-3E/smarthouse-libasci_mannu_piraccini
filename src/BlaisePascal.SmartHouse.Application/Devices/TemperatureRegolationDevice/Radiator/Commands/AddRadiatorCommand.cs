using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Console;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.TemperatureRegolationDevice.Radiator.Commands
{
    public class AddRadiatorCommand
    {
        public readonly IRadiatorRepository _radiatorRepository;

        public AddRadiatorCommand(IRadiatorRepository radiatorRepository)
        {
            _radiatorRepository = radiatorRepository;
        }

        public void Execute(Brand brand, double power, int elements)
        {
            var radiator = new BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Radiator(brand.ToString(), power, elements);

            _radiatorRepository.Add(radiator);
        }
    }
}

