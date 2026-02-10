using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Appliances.Repository
{
    internal interface ICoffeeMachineRepository
    {
        void Add(CoffeeMachine coffeeMachine);
        void Update(CoffeeMachine coffeeMachine);
        void Delete(CoffeeMachine coffeeMachine);
        CoffeeMachine GetById(int id);
        List<CoffeeMachine> GetAll();
    }
}
