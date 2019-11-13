using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_User_Interface.VM
{
    public class KillVM : BaseEntityVM
    {
        public int UserId { get; set; }
        public int EnemyId { get; set; }
        public int Count { get; set; }
    }
}
