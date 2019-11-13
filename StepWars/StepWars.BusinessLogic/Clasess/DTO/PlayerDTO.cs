using StepWars.BusinessLogic.Clasess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.DTO
{
    [DataContract]
    public class PlayerDTO
    {
        [DataMember] public string NickName { get; set; }
        [DataMember] public StarShipDTO Ship { get; set; }
        [DataMember] public bool AdminRules { get; set; }
        [DataMember] public int Score { get; set; }
    }
}
