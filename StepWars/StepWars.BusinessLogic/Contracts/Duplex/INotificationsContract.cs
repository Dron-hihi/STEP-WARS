using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Contracts.Duplex
{
    // Контрак відповідає за зв'язов серверка з гравцем
    [ServiceContract]
    public interface INotificationsContract
    {
        // Викликається при запуску гри
        void StartGameNotification();
        // Викликається на протязі гри
        void GameNotification();
        // Викликається на кінці гри
        void EndGameNotification();
    }
}
