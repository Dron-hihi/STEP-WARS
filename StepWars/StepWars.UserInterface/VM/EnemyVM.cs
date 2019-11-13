using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_User_Interface.VM
{
    public class EnemyVM : BaseEntityVM
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
        public string ImagePath { get; set; }
    }
}
