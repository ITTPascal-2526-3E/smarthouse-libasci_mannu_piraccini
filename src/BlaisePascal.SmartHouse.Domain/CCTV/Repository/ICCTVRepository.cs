using BlaisePascal.SmartHouse.Domain.Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV.Repository
{
    internal interface ICCTVRepository
    {
            void Add(CCTV cctv);
            void Update(CCTV cctv);
            void Delete(CCTV cctv);
            CCTV GetById(int id);
            List<CCTV> GetAll();
        }
    }

}
}
