using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using DomainLamp = BlaisePascal.SmartHouse.Domain.Lighting.Lamp;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamp
{
    public class CsvLampRepository : ILampRepository
    {
        private readonly string _filePath = "lamps.csv";

        public CsvLampRepository()
        {
            var solutionFolder = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionFolder, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, _filePath);

            if (!File.Exists(_filePath))
            {
                Save(new List<DomainLamp>());
            }
        }

        public List<DomainLamp> GetAll()
        {
            return Load();
        }

        public DomainLamp GetById(Guid id)
        {
            return Load().First(l => l.id_lamp == id);
        }

        public void Add(DomainLamp lamp)
        {
            var lamps = Load();
            lamps.Add(lamp);
            Save(lamps);
        }
        public void Update(DomainLamp lamp)
        {
            var lamps = Load();

            var index = lamps.FindIndex(l => l.id_lamp == lamp.id_lamp);
            if (index == -1)
                throw new Exception("Lamp not found");

            lamps[index] = lamp;
            Save(lamps);
        }

        public void Remove(Guid id)
        {
            var lamps = Load();
            var lamp = lamps.First(l => l.id_lamp == id);
            lamps.Remove(lamp);
            Save(lamps);
        }

        private List<DomainLamp> Load()
        {
            // TODO: implement CSV loading logic
            return new List<DomainLamp>();
        }

        private void Save(List<DomainLamp> lamps)
        {
            var lines = new List<string>
            {
                "Id,Brand,Type,Power,MaxBrightness,IsDimmable,SocketType"
            };

            foreach (var lamp in lamps)
            {
                lines.Add(string.Join(",",
                    lamp.id_lamp,
                    lamp.brand.Name,
                    lamp.TypeOfLamp,
                    lamp.Power,
                    lamp.max_brightness,
                    lamp.IsDimmable,
                    lamp.TypeOfSocket
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }
    }
}
