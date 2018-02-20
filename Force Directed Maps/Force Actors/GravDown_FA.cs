using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Directed_Maps
{
    public class GravDown_FA :IForceActor
    {
        public string ForceName() { return "Gravity"; }
        public void ActOn(Diagram d)
        {
            foreach (Node n in d.NodeList.Values) n.NetDisp += new Vector(0,(float)Globals.NEWTONS_GRAVITATIONAL*-1);
        }
    }
}
