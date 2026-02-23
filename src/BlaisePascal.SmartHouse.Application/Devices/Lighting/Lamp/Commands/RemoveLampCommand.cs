using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Commands
{
    public class RemoveLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public RemoveLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(int lampId)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp == null)
            {
                throw new InvalidOperationException($"Lamp with ID {lampId} not found.");
            }

            _lampRepository.Delete(lamp);
        }
    }
}
