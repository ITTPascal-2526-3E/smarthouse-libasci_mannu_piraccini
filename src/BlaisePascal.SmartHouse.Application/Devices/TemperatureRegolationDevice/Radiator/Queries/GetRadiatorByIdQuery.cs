using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TemperatureRegolationDevice.Radiator.Queries
{
    public class GetRadiatortByIdQuery
    {
        private readonly ILampRepository _radiatorRepository;

        public GetRadiatortByIdQuery(ILampRepository radiatorRepository)
        {
            _radiatorRepository = radiatorRepository;
        }

        // Specifico il percorso completo per la restituzione
        public BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Radiator Execute(Guid radiatorId)
        {
            var radiator = _radiatorRepository.GetById(radiatorId);

            if (radiator == null)
            {
                throw new InvalidOperationException($"Errore: Termosifone con ID {radiatorId} non trovata.");
            }

            return radiator;
        }
    }
}
