using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTV.Commands
{
    public class AddCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public AddCCTVCommand(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(string name)
        {
            // Il costruttore attuale di CCTV richiede solo il nome
            var cctv = new BlaisePascal.SmartHouse.Domain.CCTV.CCTV(name);
            _cctvRepository.Add(cctv);
        }
    }
}