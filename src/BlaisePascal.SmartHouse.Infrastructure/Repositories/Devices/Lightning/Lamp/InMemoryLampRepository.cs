using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects;
using DomainLamp = BlaisePascal.SmartHouse.Domain.Lighting.Lamp;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamp.InMemory
{
    public class InMemoryLampRepository : ILampRepository
    {
        private List<DomainLamp> _lamps;

        // Il file in cui salveremo i dati 
        private readonly string _filePath = "lamps_database.json";
        private readonly JsonSerializerOptions _jsonOptions;

        public InMemoryLampRepository()
        {
           
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

           
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _lamps = JsonSerializer.Deserialize<List<DomainLamp>>(json, _jsonOptions) ?? new List<DomainLamp>();
            }
            else
            {
                
                _lamps = new List<DomainLamp>
                {
                    new DomainLamp(new Brand("Philips"), "LED", 8.5, 806, true, "E27"),
                    new DomainLamp(new Brand("Samsung"), "Incandescent", 60, 800, false, "E27"),
                    new DomainLamp(new Brand("Dyson"), "Halogen", 50, 700, true, "E14")
                };
               
                SalvaSuFile();
            }
        }

    
        private void SalvaSuFile()
        {
            string json = JsonSerializer.Serialize(_lamps, _jsonOptions);
            File.WriteAllText(_filePath, json);
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
            if (lamp == null) throw new ArgumentNullException(nameof(lamp));

            _lamps.Add(lamp);
            SalvaSuFile(); // <-- SALVA sul file ogni volta che aggiungi
        }

        public void Remove(Guid id)
        {
            var lamp = GetById(id);
            if (lamp != null)
            {
                _lamps.Remove(lamp);
                SalvaSuFile(); // <-- SALVA sul file ogni volta che rimuovi
            }
        }

        public void Update(DomainLamp lamp)
        {
            SalvaSuFile();
        }
    }
}