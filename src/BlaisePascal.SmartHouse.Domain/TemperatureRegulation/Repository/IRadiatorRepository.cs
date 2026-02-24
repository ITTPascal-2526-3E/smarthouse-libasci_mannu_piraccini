using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository
{
    public interface IRadiatorRepository
    {
            void Add(Radiator radiator);
            void Update(Radiator radiator);
            void Delete(Radiator radiator);
            Radiator GetById(int id);
            List<Radiator> GetAll();
        }
}

