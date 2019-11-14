using StepWars.BusinessLogic.Contracts;
using StepWars.BusinessLogic.Contracts.Duplex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.Internals
{
    public class UserCallbacks
    {
        public IRedrawContract RedrawContract { get; set; }
        public Player Player { get; set; }
    }
}
