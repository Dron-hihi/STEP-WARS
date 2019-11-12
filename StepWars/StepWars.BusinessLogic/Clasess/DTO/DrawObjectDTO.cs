using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.DTO
{
    [DataContract]
    public class DrawObjectDTO
    {
        [DataMember] public string Image { get; set; }
        [DataMember] public int X_Pos { get; set; }
        [DataMember] public int Y_Pos { get; set; }
    }
}
