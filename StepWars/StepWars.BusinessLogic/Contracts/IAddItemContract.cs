using StepWars.BusinessLogic.Clasess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Contracts
{
    // Контракт відповідає за усі картинки
    [ServiceContract]
    public interface IAddItemContract
    {
        [OperationContract(IsOneWay = true)]
        void AddNewStarShip(StarShipDTO starShip);

        [OperationContract(IsOneWay = true)]
        void RemoveStarShip(StarShipDTO starShip);
    }
}
