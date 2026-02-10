using BlaisePascal.SmartHouse.Domain.Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Fixutures.Repository
{
    internal interface IDoorRepository
    {
        void Add(Door door);
        void Update(Door door);
        void Delete(Door door);
        Door GetById(int id);
        List<Door> GetAll();
    }
}
