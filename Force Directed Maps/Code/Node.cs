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
    public class Node : Drawable
    {
        public UnID ID;
        public string Text;
        public List<Node> Children;
        public Vector NetDisp;
        public Vector Velocity;
        public Color hColour;
        protected Vector2f hLocation;
        protected int hSize;
        protected CircleShape shape;
        protected Diagram diagramm;
        public bool Moving;
        public Node latest;
        protected Random rand = new Random(Guid.NewGuid().GetHashCode());
        System.Windows.Forms.ToolTip Tip = new System.Windows.Forms.ToolTip();
        public Node(string t, Diagram d)
        {
            //hLocation = new Vector2f(rng.Next(100,800),rng.Next(100,500));
            //Debug.WriteLine("added a node to " + hLocation.X + ", " + hLocation.Y);
            Children = new List<Node>();
            NetDisp = new Vector();
            Velocity = new Vector();
            shape = new CircleShape();
            Text = t;
            latest = null;
            diagramm = d;
            //Tip.SetToolTip(this, t);
        }

        #region Adding children
        public virtual void AddChild()
        {

        }

        protected int GetNextInt()
        {
            for (int i = 0; i < 8; i++) try { if (Children[i] == null) Debug.WriteLine("h"); } catch { return i; }
            Debug.WriteLine("Oops too many nodes added already");
            return -1;
        }
        protected int Place()
        {
            int a = rand.Next(200, 300);
            if (a%2==1) a *= -1;
            return a;
        }
        #endregion

        #region Locators
        public Vector2f Location
        {
            get { return hLocation; }
            set { hLocation = value; }
        }
        public float X
        {
            get { return hLocation.X; }
            set { hLocation.X = value; }
        }
        public float Y
        {
            get { return hLocation.Y; }
            set { hLocation.Y = value; }
        }
        public int Size { get { return hSize; } }
        #endregion

        #region Mechanics for movement
        public void Move()
        {
            Moving = true;
            Velocity = (Velocity * Globals.RESISTANCE) + (NetDisp / Mass);
            Bounce();
            //if (Vector.IsNegligible(Velocity)) Moving = false;
            //else hLocation += (Vector2f)Velocity;
            hLocation += (Vector2f)Velocity;
            NetDisp = 0;
        }
        public void Bounce()
        {
            Vector r = new Vector(0, 0);
            if (X <= 0)
            {
                r.Xcomp = (float)Globals.BOUNCE * (Math.Abs(NetDisp.Xcomp) - X);
                Velocity.Xcomp *= (float)Globals.BOUNCE;
                X = 0;
            }
            else if (X >= Globals.WIDTH)
            {
                r.Xcomp = (float)Globals.BOUNCE * (X - Math.Abs(NetDisp.Xcomp));
                Velocity.Xcomp *= (float)Globals.BOUNCE;
                X = Globals.WIDTH;
            }
            if (Y <= 0)
            {
                r.Ycomp = (float)Globals.BOUNCE * (Math.Abs(NetDisp.Ycomp) - Y);
                Velocity.Ycomp *= (float)Globals.BOUNCE;
                Y = 0;
            }
            else if (Y >= Globals.HEIGHT)
            {
                r.Ycomp = (float)Globals.BOUNCE * (Y - Math.Abs(NetDisp.Ycomp));
                Velocity.Ycomp *= (float)Globals.BOUNCE;
                Y = Globals.HEIGHT;
            }
            if (r.Xcomp != 0 && r.Ycomp != 0)
            {
                NetDisp = r;
                foreach (Node n in Children) n.NetDisp += r * -1;
            }
        }
        public virtual int Mass { get { return (int)(Math.Pow(hSize, 2) / 8); } }
        #endregion

        #region Drawing n visuals
        public bool IsHovering(Vector2f MousePos)
        {
            if (MousePos.X < X + (hSize / 2) && MousePos.X > X - (hSize / 2) && MousePos.Y < Y + (hSize / 2) && MousePos.Y > Y - (hSize / 2)) return true;
            return false;
        }
        protected void CreateShape()
        {
            shape.FillColor = hColour;
            shape.Radius = hSize / 2;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (Node n in Children) DrawConnection(target, states, n);
            DrawNode(target, states);
        }
        protected void DrawNode(RenderTarget target, RenderStates states)
        {
            try
            {
                shape.Position = new Vector2f(X - (hSize / 2), Y - (hSize / 2));
                shape.FillColor = hColour;
                target.Draw(shape, states);
            }
            catch
            {
                Debug.WriteLine("Oopsie, looks like your node went off the page");
            }
        }
        ThickLine line = new ThickLine(new Vector2f(0, 0), new Vector2f(0, 0), Color.Black, 3f);
        private void DrawConnection(RenderTarget target, RenderStates states, Node other)
        {
            line.Update(
                new Vector2f(X, Y),
                new Vector2f(other.X, other.Y)
                );
            target.Draw(line, states);
        }
        #endregion
    }

    public class Title : Node
    {
        public Title(string t, Diagram d) : base(t, d)
        {
            hColour = Color.Black;
            hSize = 20;
            hLocation = new Vector2f(Globals.X_Con / 2, Globals.Y_Con / 2);
            ID = new UnID("0");
            CreateShape();
        }
        public override void AddChild()
        {
            int a = GetNextInt();
            if(a!=-1)
            { 
                Node temp = new Box("", diagramm, this, a);
                Children.Add(temp);
                diagramm.NodeList.Add(temp.ID, temp);
                latest = temp;
            }
        }
    }

    public class Box : Node
    {
        public Box(string t, Diagram d, Node p, int c):base(t,d)
        {
            hSize = 8;
            hColour = Color.Blue;
            ID = new UnID(c, p.ID);
            //hLocation = p.Location + new Vector2f(Rand.Num(150, 150, true), Rand.Num(150, 150, true));
            hLocation = p.Location + new Vector2f(Place(), Place());
            Debug.WriteLine("Placing node at " + X + ", " + Y);
            CreateShape();
        }
    }
}
