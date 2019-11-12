using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class AddItemService : IAddItemContract
    {
        public void AddNewStarShip(StarShipDTO starShip)
        {
            
        }
    }
}
