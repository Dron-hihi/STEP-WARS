using StepWars.BattleArena.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepWars.BattleArena 
{
    public class RedrawHandler : GameService.IGameControllerContractCallback
    {
        List<DrawObjectDTO> Objects = new List<DrawObjectDTO>();
        PictureBox pictureBox;

        public RedrawHandler(PictureBox pb)
        {
            pictureBox = pb;
        }
        
        public void Redraw(DrawObjectDTO[] DrawObjects, PlayerDTO playerInfo)
        {
            MessageBox.Show("Redraw");
            Objects = DrawObjects.ToList();
        }
    }
}
