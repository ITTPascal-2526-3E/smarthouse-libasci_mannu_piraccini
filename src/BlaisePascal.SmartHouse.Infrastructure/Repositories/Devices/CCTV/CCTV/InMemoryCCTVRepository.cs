using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using DomainCCTV = BlaisePascal.SmartHouse.Domain.CCTV.CCTV;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.CCTV.InMemory
{
    public class InMemoryCCTVRepository : ICCTVRepository
    {
        private List<DomainCCTV> _cctvs;
        private readonly string _filePath = "cctvs_database.json";
        private readonly JsonSerializerOptions _jsonOptions;

        public InMemoryCCTVRepository()
        {
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _cctvs = JsonSerializer.Deserialize<List<DomainCCTV>>(json, _jsonOptions) ?? new List<DomainCCTV>();
            }
            else
            {
                _cctvs = new List<DomainCCTV>
                {
                    new DomainCCTV("Ingresso Principale"),
                    new DomainCCTV("Giardino Sul Retro")
                };

                SalvaSuFile();
            }
        }

        private void SalvaSuFile()
        {
            string json = JsonSerializer.Serialize(_cctvs, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }

        public List<DomainCCTV> GetAll()
        {
            return _cctvs;
        }

        public DomainCCTV GetById(Guid id)
        {
            return _cctvs.FirstOrDefault(c => c.Id == id);
        }

        public void Add(DomainCCTV cctv)
        {
            if (cctv == null) throw new ArgumentNullException(nameof(cctv));

            _cctvs.Add(cctv);
            SalvaSuFile();
        }

        public void Delete(DomainCCTV cctv)
        {
            if (cctv != null)
            {
                _cctvs.Remove(cctv);
                SalvaSuFile();
            }
        }

        public void Update(DomainCCTV cctv)
        {            
            SalvaSuFile();
        }
    }
}
