using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using StepWars.DataAccess.Context;
using StepWars.DataAccess.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services
{
    /// <summary>
    /// Сервіс, який додає або видаляє кораблі
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class AddItemService : IAddItemContract
    {
        private DAL_ShipService service = new DAL_ShipService(new EFRepository<StepWars.DataAccess.Enitites.StarShip>(new GameDBContext()));

        public void AddNewStarShip(StarShipDTO starShip)
        {
            if (!CheckToStarShipExist(new StarShip()
            {
                Name = starShip.Name,                
            }))
                return;

            service.AddStarShip(new StarShip()
            {
                Name = starShip.Name,
                Damage = starShip.Damage,
                Health = starShip.Health,
                Speed = starShip.Speed
            });
        }

        public void RemoveStarShip(StarShipDTO starShip)
        {
            if(CheckToStarShipExist(new StarShip()
            {
                Name = starShip.Name,
            }))
                return;

            service.AddStarShip(new StarShip()
            {
                Name = starShip.Name,
                Damage = starShip.Damage,
                Health = starShip.Health,
                Speed = starShip.Speed
            });
        }


        private bool CheckToStarShipExist(StarShip ship)
        {
            foreach (var s in service.GetAllStarShips())
            {
                if (s.Name == ship.Name)
                    return false;
            }

            return true;
        }
    }
}
