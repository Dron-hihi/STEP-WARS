using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.Internals
{
    public abstract class DrawObject
    {
        public string Image { get; set; }
        public int X_Pos { get; set; }
        public int Y_Pos { get; set; }
        public Rectangle MyProperty { get; set; }
    }
}
