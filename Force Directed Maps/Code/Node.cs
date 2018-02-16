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
        protected Color hColour;
        protected Vector2f hLocation;
        protected int hSize;
        protected CircleShape shape;
        protected Diagram diagramm;
        public bool Moving;
        protected Random rng = new Random((int)DateTime.Now.Ticks);
        public Node(Color colour, int size, string t, Diagram d)
        {
            hLocation = new Vector2f(rng.Next(100,800),rng.Next(100,500));
            Debug.WriteLine("added a node to " + hLocation.X + ", " + hLocation.Y);
            Children = new List<Node>();
            hColour = colour;
            hSize = size;
            NetDisp = new Vector(0, 0);
            Velocity = new Vector(0, 0);
            shape = new CircleShape();
            CreateShape();
            Text = t;
            diagramm = d;
            //SetupCircle();
            //stationary = a;
        }

        #region Adding children
        public void AddChild()
        {
            int a = GetNextInt();
            if(a!=-1)
            {
                Children.Add(new Node(Color.Blue, 8, "henlo", diagramm));
            }
        }

        private int GetNextInt()
        {
            for (int i = 0; i < 8; i++) try { if (Children[i] == null) Debug.WriteLine("h"); } catch { return i; }
            return -1;
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
        #endregion

        #region Mechanics for movement
        //check this works
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

        #region Drawing stuff
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
        public Title()
        {

        }
    }
}
