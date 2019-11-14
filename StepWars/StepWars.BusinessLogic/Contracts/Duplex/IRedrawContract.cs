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
    // Контракт, який реалізовує гравець.
    // Використовується для перерисовки картинки
    public interface IRedrawContract
    {
        // DrawObjects - усі об'єкти на карті.PlayerInfo - інформація про гравця
        [OperationContract(IsOneWay = true)]
        void Redraw(List<DrawObjectDTO> DrawObjects,PlayerDTO playerInfo);
    }
}
