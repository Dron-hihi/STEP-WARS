using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.DTO
{
    [DataContract]
    public class BonusDTO
    {
        [DataMember] public string Image { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public int Duration { get; set; }
    }
}
