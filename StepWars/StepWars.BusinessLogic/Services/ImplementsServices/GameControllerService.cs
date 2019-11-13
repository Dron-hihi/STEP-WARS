using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using StepWars.BusinessLogic.Contracts.Duplex;
using StepWars.BusinessLogic.Managers;
using StepWars.BusinessLogic.Managers.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,InstanceContextMode = InstanceContextMode.Single)]
    public class GameControllerService : IGameControllerContract
    {
        IManager gameManager = new GameManager(1024,768);

        public void AddNewPlayer(PlayerDTO player)
        {
            gameManager.ConnectPlayer(new UserCallbacks() {
                NotificationsContract = OperationContext.Current.GetCallbackChannel<INotificationsContract>(),
                RedrawContract = OperationContext.Current.GetCallbackChannel<IRedrawContract>(),
                Player = new Player() {
                    NickName = player.NickName,
                    AdminRules = player.AdminRules,
                    Score = player.Score,
                    Ship = new StarShip() {
                        Name = player.Ship.Name,
                        Damage = player.Ship.Damage,
                        Health = player.Ship.Health,
                        Speed = player.Ship.Speed,
                        Image = player.Ship.Image,
                        Bonus = new Bonus() {
                            Duration = player.Ship.Bonus.Duration,
                            Image = player.Ship.Bonus.Image
                        } 
                    } 
                }
            });
        }

        public void MovePlayer(PlayerDTO player, MoveDirection direction)
        {
            gameManager.Move(new Player()
            {
                NickName = player.NickName,
                AdminRules = player.AdminRules,
                Score = player.Score,
                Ship = new StarShip()
                {
                    Name = player.Ship.Name,
                    Damage = player.Ship.Damage,
                    Health = player.Ship.Health,
                    Speed = player.Ship.Speed,
                    Image = player.Ship.Image,
                    Bonus = new Bonus()
                    {
                        Duration = player.Ship.Bonus.Duration,
                        Image = player.Ship.Bonus.Image
                    }
                }            
            }, direction);
        }

        public void RemovePlayer(PlayerDTO player)
        {
            gameManager.RemovePlayer(new UserCallbacks()
            {
                NotificationsContract = OperationContext.Current.GetCallbackChannel<INotificationsContract>(),
                RedrawContract = OperationContext.Current.GetCallbackChannel<IRedrawContract>(),
                Player = new Player()
                {
                    NickName = player.NickName,
                    AdminRules = player.AdminRules,
                    Score = player.Score,
                    Ship = new StarShip()
                    {
                        Name = player.Ship.Name,
                        Damage = player.Ship.Damage,
                        Health = player.Ship.Health,
                        Speed = player.Ship.Speed,
                        Image = player.Ship.Image,
                        Bonus = new Bonus()
                        {
                            Duration = player.Ship.Bonus.Duration,
                            Image = player.Ship.Bonus.Image
                        }
                    }
                }
            });
        }

        public void Shoot(PlayerDTO player)
        {
            gameManager.Shoot(new Player()
            {
                NickName = player.NickName,
                AdminRules = player.AdminRules,
                Score = player.Score,
                Ship = new StarShip()
                {
                    Name = player.Ship.Name,
                    Damage = player.Ship.Damage,
                    Health = player.Ship.Health,
                    Speed = player.Ship.Speed,
                    Image = player.Ship.Image,
                    Bonus = new Bonus()
                    {
                        Duration = player.Ship.Bonus.Duration,
                        Image = player.Ship.Bonus.Image
                    }
                }
            });
        }
    }
}
