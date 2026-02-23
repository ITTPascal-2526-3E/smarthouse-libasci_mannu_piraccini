using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Commands
{
    public class ChangeIntensityCommand
    {
        private readonly ILampRepository _lampRepository;

        public ChangeIntensityCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(int lampId, double brightnessLevel)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp == null)
            {
                throw new InvalidOperationException($"Lamp with ID {lampId} not found.");
            }

            lamp.DimmableControl(brightnessLevel);

            _lampRepository.Update(lamp);
        }
    }
}
