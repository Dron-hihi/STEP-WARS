using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.Internals
{
    public class Player
    {
        public string NickName { get; set; }
        public StarShip Ship { get; set; }
        public bool AdminRules { get; set; }        
        public int Score { get; set; }
    }
}
