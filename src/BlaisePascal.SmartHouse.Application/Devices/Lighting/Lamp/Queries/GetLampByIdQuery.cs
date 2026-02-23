using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Queries
{
    public class GetLampByIdQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampByIdQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        // Specifico il percorso completo per la restituzione
        public BlaisePascal.SmartHouse.Domain.Lighting.Lamp Execute(int lampId)
        {
            var lamp = _lampRepository.GetById(lampId);

            if (lamp == null)
            {
                throw new InvalidOperationException($"Errore: Lampada con ID {lampId} non trovata.");
            }

            return lamp;
        }
    }
}