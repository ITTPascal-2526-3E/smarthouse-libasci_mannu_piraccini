using BlaisePascal.SmartHouse.Console;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlaisePascal.SmartHouse.Application.Devices.TemperatureRegolationDevice.Radiator.Commands
{
    public class RemoveRadiatorCommand
    {
        private readonly IRadiatorRepository _radiatorRepository;

        public RemoveRadiatorCommand(IRadiatorRepository radiatorRepository)
        {
            _radiatorRepository = radiatorRepository;
        }

        public void Execute(int radiatorId)
        {
            var radiator = _radiatorRepository.GetById(radiatorId);
            if (radiator == null)
            {
                throw new InvalidOperationException($"Radiator with ID {radiatorId} not found.");
            }

            _radiatorRepository.Delete(radiator);
        }
    }
}
