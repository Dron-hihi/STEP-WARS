using StepWars.BusinessLogic.Clasess.Internals;
using StepWars.BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Managers.Abstraction
{
    public interface IManager
    {
        bool ConnectPlayer(UserCallbacks user);
        void Move(Player player, MoveDirection direction);
        void Shoot(Player player);
        void RemovePlayer(UserCallbacks user);
    }
}
