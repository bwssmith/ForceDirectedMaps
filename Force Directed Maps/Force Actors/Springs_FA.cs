using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Directed_Maps
{
    public class Springs_FA : IForceActor
    {
        public string ForceName() { return "Hookes' Springs"; }
        public void ActOn(Diagram d)
        {
            //efficincy -it dosn't hvae to check every node to see if it has connectors
            //eg dont bother checking a free text box
            foreach(Node n in d.NodeList.Values) foreach(Node c in n.Children)
                {
                    Vector r = (Vector)(n.Location - c.Location);
                    double k = Globals.HOOKES * (r.Mag() - Globals.SPRING_LENGTH);
                    Vector resultant = r * k;
                    n.NetDisp -= resultant;
                    c.NetDisp += resultant;
                }
        }
    }
}
