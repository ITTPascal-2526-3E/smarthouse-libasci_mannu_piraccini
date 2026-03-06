using BlaisePascal.SmartHouse.Domain.Lighting;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Commands
{
    public class AddLampCommand
    {
        public readonly ILampRepository _lampRepository;

        public AddLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(string brand, string typeOfLamp, double power, double maxBrightness, bool isDimmable, string typeOfSocket)
        {
            var lamp = new BlaisePascal.SmartHouse.Domain.Lighting.Lamp(new Brand(brand), typeOfLamp, power, maxBrightness, isDimmable, typeOfSocket);

            _lampRepository.Add(lamp);
        }
    }
}
