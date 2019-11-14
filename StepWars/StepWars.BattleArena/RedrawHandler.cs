using StepWars.BusinessLogic.Clasess.DTO;
using StepWars.BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepWars.BattleArena
{
    public class RedrawHandler : IRedrawContract
    {
        List<DrawObjectDTO> Objects = new List<DrawObjectDTO>();
        PictureBox pictureBox = new PictureBox();

        public RedrawHandler(PictureBox pb)
        {
            pictureBox = pb;
        }

        public void Redraw(List<BusinessLogic.Clasess.DTO.DrawObjectDTO> DrawObjects, PlayerDTO playerInfo)
        {
            Objects = DrawObjects;
        }
    }
}
