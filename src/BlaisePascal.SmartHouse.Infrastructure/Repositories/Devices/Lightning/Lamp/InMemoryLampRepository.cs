using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using BlaisePascal.SmartHouse.Domain.Lighting;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamp.InMemory
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>
            {
                new Lamp(new Brand("Philips"), "LED", 8.5, 806, true, "E27"),
                new Lamp(new Brand("Samsung"), "Incandescent", 60, 800, false, "E27"),
                new Lamp(new Brand("Dyson"), "Halogen", 50, 700, true, "E14")
            };

        }
        public List<Lamp> GetAll()
        {
            return _lamps;
        }

        public Lamp GetById(Guid id)
        {
            return _lamps.FirstOrDefault(l => l.Id == id);
        }

        public void Add(Lamp lamp)
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

        public void Update(Lamp lamp)
        {
            //Actually not to do 
        }


    }

}

