using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_User_Interface.VM
{
    public class UserVM : BaseEntityVM
    {
        public string NickName { get; set; }
        public string ShipName { get; set; }
        public bool AdminRules { get; set; }
    }
}
