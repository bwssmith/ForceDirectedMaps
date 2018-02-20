using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Directed_Maps
{
    public class ElectroRepulsion_FA : IForceActor
    {
        public string ForceName() { return "Electrostatic repulsion"; }
        public void ActOn(Diagram d)
        {
            //this works - is there a tidier way to do this tho?
            List < Node > templist = d.NodeList.Values.ToList<Node>();
            for (int i = 0; i < d.NodeList.Count; i++)
            {
                for (int j = i + 1; j < d.NodeList.Count; j++)
                {
                    Vector r = (Vector)(templist[i].Location -templist[j].Location);
                    double k = Globals.REPULSION / Math.Pow(r.Mag(), 2);
                    Vector resultant = r * k;
                    templist[i].NetDisp += resultant;
                    templist[j].NetDisp += (resultant * -1);
                }
            }

        }
    }
}
