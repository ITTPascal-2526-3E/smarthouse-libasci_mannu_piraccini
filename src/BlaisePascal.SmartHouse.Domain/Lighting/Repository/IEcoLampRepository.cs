using BlaisePascal.SmartHouse.Domain.Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.Repository
{
    internal interface IEcoLampRepository
    {
        void Add(EcoLamp ecoLamp);
        void Update(EcoLamp ecoLamp);
        void Delete(EcoLamp ecoLamp);
        EcoLamp GetById(int id);
        List<EcoLamp> GetAll();
    }
}
