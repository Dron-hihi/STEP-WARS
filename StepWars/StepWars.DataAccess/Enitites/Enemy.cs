using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.DataAccess.Enitites
{
    public class Enemy : BaseEntity
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
        public string ImagePath { get; set; }
    }
}
