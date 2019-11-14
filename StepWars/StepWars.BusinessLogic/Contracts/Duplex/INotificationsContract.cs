using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Contracts.Duplex
{
    // Контрак відповідає за зв'язов серверка з гравцем
    public interface INotificationsContract
    {
        // Викликається при запуску гри
        [OperationContract(IsOneWay = true)]
        void StartGameNotification();
        // Викликається на протязі гри
        [OperationContract(IsOneWay = true)]
        void GameNotification();
        // Викликається на кінці гри
        [OperationContract(IsOneWay = true)]
        void EndGameNotification();
    }
}
