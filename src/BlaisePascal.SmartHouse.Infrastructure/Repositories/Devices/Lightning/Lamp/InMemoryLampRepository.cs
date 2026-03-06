using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects;
using DomainLamp = BlaisePascal.SmartHouse.Domain.Lighting.Lamp;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamp.InMemory
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<DomainLamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<DomainLamp>
            {
                new DomainLamp(new Brand("Philips"), "LED", 8.5, 806, true, "E27"),
                new DomainLamp(new Brand("Samsung"), "Incandescent", 60, 800, false, "E27"),
                new DomainLamp(new Brand("Dyson"), "Halogen", 50, 700, true, "E14")
            };

        }
        public List<DomainLamp> GetAll()
        {
            return _lamps;
        }

        public DomainLamp GetById(Guid id)
        {
            return _lamps.FirstOrDefault(l => l.id_lamp == id);
        }

        public void Add(DomainLamp lamp)
        {
            if (lamp == null)
                throw new ArgumentNullException(nameof(lamp));

            _lamps.Add(lamp);
        }

        public void Remove(Guid id)
        {
            var lamp = GetById(id);
            if (lamp != null)
            {
                _lamps.Remove(lamp);
            }
        }

        public void Update(DomainLamp lamp)
        {
            //Actually not to do 
        }


    }

}

