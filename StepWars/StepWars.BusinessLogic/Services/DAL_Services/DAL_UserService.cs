using StepWars.DataAccess.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services.DAL_Services
{
    /// <summary>
    /// Клас для роботи з базою данних користувачів
    /// </summary>
    public class DAL_UserService
    {
        private readonly IRepository<StepWars.DataAccess.Enitites.User> repository;

        public DAL_UserService(IRepository<StepWars.DataAccess.Enitites.User> repos)
        {
            repository = repos;
        }

        /// <summary>
        /// Отримати усіх користувачів
        /// </summary>
        /// <returns></returns>
        public List<StepWars.BusinessLogic.Clasess.Internals.Player> GetAllUsers()
        {
            List<StepWars.BusinessLogic.Clasess.Internals.Player> returnList = new List<Clasess.Internals.Player>();

            foreach (var user in repository.GetAll())
            {
                returnList.Add(new StepWars.BusinessLogic.Clasess.Internals.Player()
                {
                    NickName = user.NickName,
                    AdminRules = user.AdminRules
                });
            }

            return returnList;
        }

        /// <summary>
        /// Додати нового користувача
        /// </summary>
        /// <param name="Player"></param>
        public void AddNewUser(StepWars.BusinessLogic.Clasess.Internals.Player Player)
        {
            if (!CheckToExist(Player))
                return;

            repository.Add(new DataAccess.Enitites.User()
            {
                NickName = Player.NickName,
                AdminRules = Player.AdminRules,
                ShipName = Player.Ship.Name
            });
        }

        /// <summary>
        /// Видалити користувача
        /// </summary>
        /// <param name="Player"></param>
        public void RemoveUser(StepWars.BusinessLogic.Clasess.Internals.Player Player)
        {
            repository.Remove(repository.GetAll().FirstOrDefault(x => x.NickName == Player.NickName));
        }


        private bool CheckToExist(StepWars.BusinessLogic.Clasess.Internals.Player Player)
        {
            if (repository.GetAll().FirstOrDefault(x => x.NickName == Player.NickName) != null)
                return false;

            return true;
        }
    }
}
