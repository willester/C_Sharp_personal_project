using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARIVAN_WILLIAM_1065_Project
{
    class grahic
    {
        public string brow { get; set; }

        public  int nr  { get; set; }

        public Color Color { get; set; }

        public grahic(string description, int percent, Color color)
        {
            brow = description;
            nr = percent;
            Color = color;
        }



    }
}
