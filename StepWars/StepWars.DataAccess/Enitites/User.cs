using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.DataAccess.Enitites
{
    public class User : BaseEntity
    {
        public string NickName { get; set; }
        public string ShipName { get; set; }
        public bool AdminRules { get; set; }
        public string AdminPassword { get; set; }
    }
}
