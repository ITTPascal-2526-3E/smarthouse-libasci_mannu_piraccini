using BlaisePascal.SmartHouse.Domain.Lighting;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository
{

        internal interface IAirConditionerRepository
        {
            void Add(AirConditioner airConditioner);
            void Update(AirConditioner airConditioner);
            void Delete(AirConditioner airConditioner);
            AirConditioner GetById(int id);
            List<AirConditioner> GetAll();
        }
}
