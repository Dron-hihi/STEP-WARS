using StepWars.BusinessLogic.Clasess.Inline;
using StepWars.BusinessLogic.Clasess.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Contracts
{
    // Контракт, який відповідає за реєстрацію нового гравця
    public interface IRegistrationContract
    {
        // Функція, яка повертає всі кораблі для вибору
        List<StarShipDTO> GetAllShips();
        // Функція, яка перевіряє чи вже є гравець з таким самим ніком в грі
        bool CheckToUserExist(string nickName);
        // Функція, яка перевіряє чи є в гравця права адміна
        bool CheckToAdminRules(string nickName);
        // Функція, яка перевіряє чи правильний адмін пароль
        bool CheckToAdminPassword(string password);
        // Функція, яка реєструє нового гравця.Повертає нашого гравця.
        PlayerDTO RegisterNewPlayer(string nickName, StarShipDTO startShip);
    }
}
