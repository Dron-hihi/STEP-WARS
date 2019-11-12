using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using StepWars.BusinessLogic.Managers.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Managers
{

    /// <summary>
    /// Менеджер відповідає за серверну частину гри
    /// </summary>
    public class GameManager : IManager
    {
        // Усі гравці
        private List<UserCallbacks> players = new List<UserCallbacks>();

        private int maxPlayers = 3;
        private int width, height;
        private int maxEnemies = 20;

        private int fps = 60;

        // Усі об'єкти на карті
        private List<DrawObject> drawObjects = new List<DrawObject>();

        private List<Bonus> bonuses;
        private List<Enemy> enemies;

        private Bonus currentBonus;

        private object locker;



        public GameManager(int _widht,int _height)
        {
            width = _widht;
            height = _height;

            Task.Run(() => { RedrawCycle(); } );
        }

        public bool ConnectPlayer(UserCallbacks user)
        {
            if (players.Count >= maxPlayers)
                return false;

            players.Add(user);
            players.ElementAt(players.Count - 1).NotificationsContract.StartGameNotification();

            // Spawn
            lock (locker)
            {
                int xPos, yPos;
                xPos = (width / 3) / 2;
                yPos = height / (maxPlayers - (players.Count - 1));


                do
                {
                } while (Spawn(user.Player.Ship, xPos, yPos));                               
            }


            return true;
        }

        public void Move(Player player, MoveDirection direction)
        {
            throw new NotImplementedException();
        }       

        public void Shoot(Player player)
        {
            throw new NotImplementedException();
        }

        public void RemovePlayer(UserCallbacks user)
        {
            lock (locker)
            {
                players.Remove(user);
                drawObjects.Remove(user.Player.Ship);
                user.NotificationsContract.EndGameNotification();
            }         
        }



        /// <summary>
        /// Спавнить о'бєкт на карті з вказаними координатами
        /// </summary>
        /// <param name="Object"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool Spawn(DrawObject Object,int x,int y)
        {
            Object.X_Pos = x;
            Object.Y_Pos = y;

            if (CheckToIntersect(Object) != null)
                return false;

            drawObjects.Add(Object);
            return true;
        }

        /// <summary>
        /// Повертає об'єкт з яким відбулася колізія
        /// </summary>
        /// <param name="Object"></param>
        /// <returns></returns>
        private DrawObject CheckToIntersect(DrawObject Object)
        {
            foreach (var obj in drawObjects)
            {
                if(Object.CollisionRectangle.IntersectsWith(obj.CollisionRectangle))
                {
                    return obj;
                }
            }


            return null;
        }

        /// <summary>
        /// Видаляє об'єкт з карти
        /// </summary>
        /// <param name="Object"></param>
        private void RemoveObject(DrawObject Object)
        {
            drawObjects.Remove(Object);
        }

        /// <summary>
        /// Цикл, який постійно відправляє картинку користувачу
        /// </summary>
        private void RedrawCycle()
        {
            while (true)
            {
                foreach (var player in players)
                {
                    lock (locker)
                    {
                        List<DrawObjectDTO> ships = drawObjects.Select(x => new DrawObjectDTO
                        {
                            Image = x.Image,
                            X_Pos = x.X_Pos,
                            Y_Pos = x.Y_Pos
                        }).ToList();


                        PlayerDTO _player = new PlayerDTO();
                        _player.NickName = player.Player.NickName;
                        _player.Ship = new StarShipDTO()
                        {
                            Damage = player.Player.Ship.Damage,
                            Health = player.Player.Ship.Health,
                            Speed = player.Player.Ship.Speed,
                            Name = player.Player.Ship.Name
                        };
                        _player.Score = player.Player.Score;
                        _player.AdminRules = player.Player.AdminRules;


                        player.RedrawContract.Redraw(ships, _player);
                    }                        
                }
                Thread.Sleep(1000 / fps);
            }
            
        }       
    }
}
