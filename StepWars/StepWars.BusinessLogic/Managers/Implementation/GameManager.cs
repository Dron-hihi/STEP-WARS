using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using StepWars.BusinessLogic.Managers.Abstraction;
using StepWars.BusinessLogic.Services.DAL_Services;
using StepWars.DataAccess.Repository.Implementation;
using StepWars.Helpers.Extentions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        DAL_UserService userService = new DAL_UserService(new EFRepository<StepWars.DataAccess.Enitites.User>(new StepWars.DataAccess.Context.GameDBContext()));




        public GameManager(int _widht, int _height)
        {
            width = _widht;
            height = _height;

            Task.Run(() => { RedrawCycle(); });
        }

        public bool ConnectPlayer(UserCallbacks user)
        {
            MessageBox.Show("Connect");
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

                userService.AddNewUser(user.Player);

                do
                {
                } while (Spawn(user.Player.Ship, xPos, yPos));
            }


            return true;
        }

        public void Move(Player player, MoveDirection direction)
        {
            DrawObject playerShip;
            playerShip = players.FirstOrDefault(x => x.Player.NickName == player.NickName).Player.Ship;

            var collisionObject = CheckToIntersect(playerShip);
            if (collisionObject != null)
            {
                switch (collisionObject.Tag)
                {
                    case DrawObjectTags.PLAYER:
                        {
                            return;
                        }
                    case DrawObjectTags.ENEMY:
                        {
                            var userCallback = players.FirstOrDefault(x => x.Player.Ship.Name == (playerShip as StarShip).Name);
                            RemovePlayer(userCallback);
                            break;
                        }                    
                }
            }

            if (direction == MoveDirection.Down)
            {
                if (playerShip.Y_Pos <= height)
                    return;                

                playerShip.Y_Pos -= (playerShip as StarShip).Speed;
            }
            else if (direction == MoveDirection.Up)
            {
                if (playerShip.Y_Pos >= height)
                    return;

                playerShip.Y_Pos += (playerShip as StarShip).Speed;
            }
            else if (direction == MoveDirection.Left)
            {
                if (playerShip.X_Pos <= width)
                    return;

                playerShip.X_Pos -= (playerShip as StarShip).Speed;
            }
            else if (direction == MoveDirection.Right)
            {
                if (playerShip.X_Pos >= width)
                    return;

                playerShip.X_Pos += (playerShip as StarShip).Speed;
            }

            var playerDrawObject = drawObjects.FirstOrDefault(x => x.X_Pos == player.Ship.X_Pos && x.Y_Pos == player.Ship.Y_Pos);

            playerDrawObject.CollisionRectangle = new Rectangle()
            {
                Width = playerShip.CollisionRectangle.Width,
                Height = playerShip.CollisionRectangle.Height,
                X = playerShip.X_Pos,
                Y = playerShip.Y_Pos
            };
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
                userService.RemoveUser(user.Player);
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
        private bool Spawn(DrawObject Object, int x, int y)
        {
            Object.X_Pos = x;
            Object.Y_Pos = y;


            if (CheckToIntersect(Object) != null)
                return false;


            if(Object is Player)
            {
                Object.Tag = DrawObjectTags.PLAYER;
            }
            else if (Object is Enemy)
            {
                Object.Tag = DrawObjectTags.ENEMY;
            }
            else if(Object is Bullet)
            {
                Object.Tag = DrawObjectTags.BULLET;
            }

            Object.CollisionRectangle = new Rectangle()
            {
                Width = Object.Image.StringToImage().Width,
                Height = Object.Image.StringToImage().Height,
                X = x,
                Y = y
            };
            

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
                if (Object.CollisionRectangle.IntersectsWith(obj.CollisionRectangle))
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
