using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Commands
{
    public class SwitchLampOnCommand
    {
        private readonly ILampRepository _lampRepository;

        public SwitchLampOnCommand(ILampRepository lampRepository)
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
            if (lamp.IsOn)
            {
               throw new InvalidOperationException($"Lamp with ID {lampId} is already on.");
            }

       
            lamp.TurnOnOrOff();
            _lampRepository.Update(lamp);
        }
    }
}
