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
            NodeList.Add(new UnID("0"), new Node(Color.Black, 20, "Starter", this));
            System.Threading.Thread.Sleep(20);
            NodeList.Add(new UnID("0.0"), new Node(Color.Blue, 8, "baby1", this));
            NodeList[new UnID("0")].Children.Add(NodeList[new UnID("0.0")]);
            System.Threading.Thread.Sleep(20);
            NodeList.Add(new UnID("0.1"), new Node(Color.Red, 8, "baby2", this));
            NodeList[new UnID("0")].Children.Add(NodeList[new UnID("0.1")]);
            System.Threading.Thread.Sleep(20);
            NodeList.Add(new UnID("0.2"), new Node(Color.Green, 8, "baby3", this));
            NodeList[new UnID("0")].Children.Add(NodeList[new UnID("0.2")]);
            NodeList[new UnID("0")].AddChild();
            //Forces.Add(new GravDown_FA());
            Forces.Add(new Springs_FA());
            Forces.Add(new CornerRep_FA());
            Forces.Add(new ElectrRepulsio_FA());
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
    }
}
