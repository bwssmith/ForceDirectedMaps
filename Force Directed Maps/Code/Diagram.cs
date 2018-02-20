using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Force_Directed_Maps
{
    public class Diagram :Drawable
    {
        public List<IForceActor> Forces;
        public IDictionary<UnID, Node> NodeList;

        public Diagram()
        {
            NodeList = new Dictionary<UnID, Node>();
            Forces = new List<IForceActor>();
            Title n = new Title("Title", this);
            NodeList.Add(n.ID, n);
            //for (int i = 0; i < 6; i++)
            //{ n.AddChild(); System.Threading.Thread.Sleep(20); }
            //Forces.Add(new Springs_FA());
            //Forces.Add(new CornerRep_FA());
            //Forces.Add(new ElectrRepulsio_FA());
        }
        public Diagram(List<IForceActor> forces)
        {
            NodeList = new Dictionary<UnID, Node>();
            Forces = forces;
            Title n = new Title("Title", this);
            NodeList.Add(n.ID, n);
            //for (int i = 0; i < 6; i++){ n.AddChild();}
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (Node n in NodeList.Values) n.Draw(target, states);
        }
        public void WorkForces()
        {
            foreach (IForceActor f in Forces)
            {
                f.ActOn(this);
            }
            foreach (Node n in NodeList.Values) n.Move();
        }
        public bool IsMoving()
        {
            foreach (Node n in NodeList.Values)
            { if (n.Moving) return true; }
            return false;
        }
        public Node Hover(Vector2f MousePos)
        {
            List<Node> templist = NodeList.Values.ToList<Node>();
            foreach (Node n in templist) if (n.IsHovering(MousePos)) return n;
            return null;
        }
    }
}
