using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Infrastructure.Repositories; 
using DomainCCTV = BlaisePascal.SmartHouse.Domain.CCTV.CCTV;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.CCTV
{
    public class CsvCCTVRepository : ICCTVRepository
    {
        private readonly string _filePath = "cctvs.csv";

        public CsvCCTVRepository()
        {
            var solutionFolder = LocalPathHelper.GetSolutionRoot();
            var dataFolder = Path.Combine(solutionFolder, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, _filePath);

            if (!File.Exists(_filePath))
            {
                Save(new List<DomainCCTV>());
            }
        }

        public List<DomainCCTV> GetAll()
        {
            return Load();
        }

        public DomainCCTV GetById(Guid id)
        {
            return Load().First(c => c.Id == id);
        }

        public void Add(DomainCCTV cctv)
        {
            var cctvs = Load();
            cctvs.Add(cctv);
            Save(cctvs);
        }

        public void Update(DomainCCTV cctv)
        {
            var cctvs = Load();

            var index = cctvs.FindIndex(c => c.Id == cctv.Id);
            if (index == -1)
                throw new Exception("CCTV not found");

            cctvs[index] = cctv;
            Save(cctvs);
        }

        public void Delete(DomainCCTV cctv)
        {
            var cctvs = Load();
            var itemToRemove = cctvs.First(c => c.Id == cctv.Id);
            cctvs.Remove(itemToRemove);
            Save(cctvs);
        }

        private List<DomainCCTV> Load()
        {
            return new List<DomainCCTV>();
        }

        private void Save(List<DomainCCTV> cctvs)
        {
            var lines = new List<string>
            {
                "Id,Name,Status,CCTVState"
            };

            foreach (var cctv in cctvs)
            {
                lines.Add(string.Join(",",
                    cctv.Id,
                    cctv.Name,
                    cctv.Status,
                    cctv.CCTVState
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }
    }
}
