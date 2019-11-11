using StepWars.BusinessLogic.Clasess.Inline;
using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services
{
    public class RegistrationService : IRegistrationContract
    {
        public bool CheckToAdminPassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckToAdminRules(string nickName)
        {
            throw new NotImplementedException();
        }

        public bool CheckToUserExist(string nickName)
        {
            throw new NotImplementedException();
        }

        public List<StarShipDTO> GetAllShips()
        {
            throw new NotImplementedException();
        }

        public PlayerDTO RegisterNewPlayer(string nickName, StarShipDTO startShip)
        {
            throw new NotImplementedException();
        }
    }
}
