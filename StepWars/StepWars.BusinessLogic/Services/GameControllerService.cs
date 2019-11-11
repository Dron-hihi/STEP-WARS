using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services
{
    public class GameControllerService : IGameControllerContract
    {
        public void AddNewPlayer(PlayerDTO player)
        {
            //OperationContext.Current.GetCallbackChannel<>
            throw new NotImplementedException();
        }

        public void MovePlayer(PlayerDTO player, MoveDirection direction)
        {
            throw new NotImplementedException();
        }

        public void RemovePlayer(PlayerDTO player)
        {
            throw new NotImplementedException();
        }

        public void Shoot(PlayerDTO player)
        {
            throw new NotImplementedException();
        }
    }
}
