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
    public class DAL_Service
    {
        private readonly IRepository<StepWars.DataAccess.Enitites.StarShip> repository;

        public DAL_Service(IRepository<StepWars.DataAccess.Enitites.StarShip> repos)
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
            StepWars.DataAccess.Enitites.StarShip ship = new DataAccess.Enitites.StarShip();

            ship.Name = starShip.Name;
            ship.Damage = starShip.Damage;
            ship.Health = starShip.Health;
            ship.Speed = starShip.Speed;

            repository.Add(ship);
        }
    }
}
