using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Console;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.ValueObjects;
using BlaisePascal.SmartHouse.Console;

namespace BlaisePascal.SmartHouse.Application.Devices.TemperatureRegolationDevice.Radiator.Commands
{
    public class AddRadiatorCommand
    {
        public readonly IRadiatorRepository _radiatorRepository;

        public AddRadiatorCommand(IRadiatorRepository radiatorRepository)
        {
            _radiatorRepository = radiatorRepository;
        }

        public void Execute(BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Radiator. (Brand brand, string type, double power, double maxTemperature, bool hasThermostat)
        {

            var radiator = new BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Radiator(brand, type, power, maxTemperature, hasThermostat);

            _radiatorRepository.Add(radiator);
        }
    }
}

