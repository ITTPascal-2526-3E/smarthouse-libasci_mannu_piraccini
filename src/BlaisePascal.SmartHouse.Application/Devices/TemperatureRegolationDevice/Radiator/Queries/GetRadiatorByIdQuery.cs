using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Repository; 

namespace BlaisePascal.SmartHouse.Application.Devices.TemperatureRegolationDevice.Radiator.Queries
{
    public class GetRadiatortByIdQuery
    {
        private readonly IRadiatorRepository _radiatorRepository;

        public GetRadiatortByIdQuery(IRadiatorRepository radiatorRepository)
        {
            _radiatorRepository = radiatorRepository;
        }

        // Specifico il percorso completo per la restituzione
        public BlaisePascal.SmartHouse.Domain.TemperatureRegulation.Radiator Execute(Guid radiatorId, Domain.TemperatureRegulation.Radiator radiator)
        {
            var radiator1 = _radiatorRepository.GetById(radiatorId);

            if (radiator1 == null)
            {
                throw new InvalidOperationException($"Errore: Termosifone con ID {radiatorId} non trovata.");
            }

            return radiator1;
        }
    }
}
