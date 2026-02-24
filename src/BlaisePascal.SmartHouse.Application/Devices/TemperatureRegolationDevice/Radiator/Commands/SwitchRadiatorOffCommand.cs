using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.TemperatureRegulationDevice.Radiator.Commands
{
    internal class SwitchRadiatorOffCommand
    {
        private readonly IRadiatorRepository _radiatorRepository;
        public SwitchRadiatorOffCommand(IRadiatorRepository lampRepository)
        {
            _radiatorRepository = lampRepository;
        }

        public void Execute(int radiatorId)
        {
            var radiator = _radiatorRepository.GetById(radiatorId);
            if (radiator == null)
            {
                throw new InvalidOperationException($"Radiator with ID {radiatorId} not found.");
            }
            if (!radiator.IsOn)
            {
                throw new InvalidOperationException($"Radiator with ID {radiatorId} is already off.");
            }
            radiator.TurnOnOrOff();
            _radiatorRepository.Update(radiator);
        }
    }
}
