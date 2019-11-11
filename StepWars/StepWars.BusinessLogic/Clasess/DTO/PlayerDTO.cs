using StepWars.BusinessLogic.Clasess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.DTO
{
    public class PlayerDTO
    {
        public string NickName { get; set; }
        public StarShipDTO Ship { get; set; }
        public bool AdminRules { get; set; }
        public int Score { get; set; }
    }
}
