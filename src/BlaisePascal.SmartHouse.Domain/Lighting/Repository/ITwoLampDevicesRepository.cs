using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lighting.Repository
{
    internal interface ITwoLampDevicesRepository
    {
        void Add(TwoLampDevice twolampdevice);
        void Update(TwoLampDevice twolampdevice);
        void Delete(TwoLampDevice twolampdevice);
        TwoLampDevice GetById(int id);
        List<TwoLampDevice> GetAll();
    }
}
