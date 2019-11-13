using StepWars.DataAccess.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services
{
    /// <summary>
    /// Сука, падла 3 часа ночі, як же я заїбався.
    /// </summary>
    public class DAL_ShipService
    {
        private readonly IRepository<StepWars.DataAccess.Enitites.StarShip> repository;

        public DAL_ShipService(IRepository<StepWars.DataAccess.Enitites.StarShip> repos)
        {
            repository = repos;
        }

        /// <summary>
        /// Отримує усі кораблі з баси данних
        /// </summary>
        /// <returns></returns>
        public List<StepWars.BusinessLogic.Clasess.Internals.StarShip> GetAllStarShips()
        {
            List<StepWars.BusinessLogic.Clasess.Internals.StarShip> returnList = new List<Clasess.Internals.StarShip>();
            foreach (var ship in repository.GetAll().ToList())
            {
                returnList.Add(new Clasess.Internals.StarShip()
                {
                    Name = ship.Name,
                    Damage = ship.Damage,
                    Health = ship.Health,
                    Speed = ship.Speed
                });
            }

            return returnList;
        }

        /// <summary>
        /// Додає корабель до бази данних
        /// </summary>
        /// <param name="starShip"></param>
        public void AddStarShip(StepWars.BusinessLogic.Clasess.Internals.StarShip starShip)
        {
            if (!CheckToExist(starShip))
                return;

            repository.Add(new DataAccess.Enitites.StarShip()
            {
                Name = starShip.Name,
                Damage = starShip.Damage,
                Health = starShip.Health,
                Speed = starShip.Speed
            });
        }

        /// <summary>
        /// Видаляє корабель з бази данних
        /// </summary>
        /// <param name="starShip"></param>
        public void RemoveShip(StepWars.BusinessLogic.Clasess.Internals.StarShip starShip)
        {
            repository.Remove(repository.GetAll().FirstOrDefault(x => x.Name == starShip.Name));
        }

        private bool CheckToExist(StepWars.BusinessLogic.Clasess.Internals.StarShip starShip)
        {
            if (repository.GetAll().FirstOrDefault(x => x.Name == starShip.Name) != null)
                return false;

            return true;
        }
    }
}
