using System;

namespace Force_Directed_Maps
{
    public class CornerRep_FA : IForceActor
    {
        public void ActOn(Diagram diagram)
        {
            foreach (Node n in diagram.NodeList.Values)
            {
                n.NetDisp += new Vector((float)(5 * Globals.REPULSION * ApplyEquation(n.X, Globals.X_Con)), (float)(50 * Globals.REPULSION * ApplyEquation(n.Y, Globals.Y_Con)));
            }
        }
        private double ApplyEquation(float a, int b)
        {
            return (2 * Math.Pow(b, 2) - (4 * a * b)) / Math.Pow((a * (b - a)), 2);
        }
    }
}
