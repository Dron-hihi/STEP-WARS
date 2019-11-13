using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.DTO
{
    [DataContract]
    public class StarShipDTO
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public string Image { get; set; }
        [DataMember] public int Damage { get; set; }
        [DataMember] public int Health { get; set; }
        [DataMember] public int Speed { get; set; }
        [DataMember] public BonusDTO Bonus { get; set; }        
    }
}
