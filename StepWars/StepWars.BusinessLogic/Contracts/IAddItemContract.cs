using StepWars.BusinessLogic.Clasess.Inline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Contracts
{
    // Контракт відповідає за усі картинки
    public interface IAddItemContract
    {
        void AddNewStarShip(StarShipDTO starShip);
    }
}
