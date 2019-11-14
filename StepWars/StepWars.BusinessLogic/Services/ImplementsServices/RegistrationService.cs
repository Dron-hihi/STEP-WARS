using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using StepWars.BusinessLogic.Services.DAL_Services;
using StepWars.DataAccess.Context;
using StepWars.DataAccess.Enitites;
using StepWars.DataAccess.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class RegistrationService : IRegistrationContract
    {
        DAL_UserService service = new DAL_UserService(new EFRepository<User>(new GameDBContext()));

        public bool CheckToAdminPassword(string password)
        {
            var adminpass = service.GetAllUsers().FirstOrDefault(x => x.AdminPassword == password);
               
            if (password == null)
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckToAdminRules(string nickName)
        {
            var nickadmin = service.GetAllUsers().FirstOrDefault(x => x.NickName == nickName && x.AdminRules == true);
            if (nickName == null)
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckToUserExist(string nickName)
        {
            var user = service.GetAllUsers().FirstOrDefault(x => x.NickName == nickName);

            if (user == null)
                return true;

            return false;
        }

        public List<StarShipDTO> GetAllShips()
        {
            List<StarShipDTO> ships = new List<StarShipDTO>();
            DAL_ShipService shipService = new DAL_ShipService((new EFRepository<DataAccess.Enitites.StarShip>(new GameDBContext())));

            foreach (var ship in shipService.GetAllStarShips())
            {
                if(ship.Bonus != null)
                {
                    ships.Add(new StarShipDTO()
                    {
                        Bonus = new BonusDTO()
                        {
                            Duration = ship.Bonus.Duration,
                            Image = ship.Bonus.Image
                        },
                        Damage = ship.Damage,
                        Name = ship.Name,
                        Health = ship.Health,
                        Image = ship.Image,
                        Speed = ship.Speed

                    });
                }
                else
                {
                    ships.Add(new StarShipDTO()
                    {                       
                        Damage = ship.Damage,
                        Name = ship.Name,
                        Health = ship.Health,
                        Image = ship.Image,
                        Speed = ship.Speed

                    });
                }

                
            }

            return ships;
        }

        public PlayerDTO RegisterNewPlayer(string nickName, StarShipDTO startShip)
        {
            throw new NotImplementedException();
        }
    }
}
