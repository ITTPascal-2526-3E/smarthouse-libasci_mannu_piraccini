using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamp
{
    public class CsvLampRepository : ILampRepository
    {
        private readonly string _filePath = "lamps.csv";

        public CsvLampRepository()
        {
            var solutionFolder = LocalPathHelper.GetSolutionInRoot();

            var dataFolder = Path.Combine(solutionFolder, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, _filePath);

            if (!File.Exists(_filePath))
            {
                Save(new List<Lamp>());
            }
        }

        public List<Lamp> GetAll()
        {
            return Load();
        }

        public Lamp GetById(Guid id)
        {
            return Load().First(l => l.Id == id);
        }

        public void Add(Lamp lamp)
        {
            var lamps = Load();
            lamps.Add(lamp);
            Save(lamps);
        }
        public void Update(Lamp lamp)
        {
            var lamps = Load();

            var index = lamps.FindIndex(l => l.Id == lamp.Id);
            if (index == -1)
                throw new Exception("Lamp not found");

            lamps[index] = lamp;
            Save(lamps);
        }

        public void Remove(Guid id)
        {
            var lamps = Load();
            var lamp = lamps.First(l => l.Id == id);
            lamps.Remove(lamp);
            Save(lamps);
        }



        private void Save(List<Lamp> lamps)
        {
            var dtos = lamps;

            var lines = new List<string>
            {
                "Id,Name,ImageUrl,Brand,Type,Wattage,Lumens,IsDimmable,SocketType"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.Name.Value,
                    dto.ImageUrl,
                    dto.Brand.Name,
                    dto.Type,
                    dto.Wattage,
                    dto.Lumens,
                    dto.IsDimmable,
                    dto.SocketType
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }
    }
}
