using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Clasess.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Contracts
{
    public enum MoveDirection { Up,Down,Left,Right }

    // Контракт де буде відбуватися уся ігрова логіка(пересування,стрільба,смерть,бонуси і т.д)
    [ServiceContract(CallbackContract = typeof(IRedrawContract))]
    public interface IGameControllerContract
    {
        // Додає нового гравця в гру
        [OperationContract(IsOneWay = true)]
        void AddNewPlayer(PlayerDTO player);
        // Рухає персонажа
        [OperationContract]
        void MovePlayer(PlayerDTO player, MoveDirection direction);
        // Стрільба
        [OperationContract]
        void Shoot(PlayerDTO player);
        // Видаляє гравця з гри
        [OperationContract(IsOneWay = true)]
        void RemovePlayer(PlayerDTO player);
    }
}
