using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Commands
{
    public class AddLampCommand
    {
        public readonly ILampRepository _lampRepository;

        public AddLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand brand, string type, double power, double maxBrightness, bool isDimmable, string socket)
        {

            var lamp = new BlaisePascal.SmartHouse.Domain.Lighting.Lamp(brand, type, power, maxBrightness, isDimmable, socket);

            _lampRepository.Add(lamp);
        }
    }
}

