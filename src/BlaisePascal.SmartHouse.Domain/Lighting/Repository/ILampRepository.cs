using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.Repository
{
    internal interface ILampRepository
    {
        void Add(Lamp lamp);
        void Update(Lamp lamp);
        void Delete(Lamp lamp);
        Lamp GetById(int id);
        List<Lamp> GetAll();
    }
}
