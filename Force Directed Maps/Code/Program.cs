using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Force_Directed_Maps
{
    static class Program
    {
        #region static variables
        static GraphScreen GSForm;
        static DrawingSurface renderSurface;
        static Diagram diagram;
        static bool playing = true;
        static RenderWindow renderwindow;
        static Vector2f mousePos;
        static Node selected;
        static ContextMenu mnu;
        static Node held;
        #endregion

        [STAThread]  
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //this has a list of all the avaliable forces, which can be accessed globally
            Globals.Forces = new List<IForceActor>();
            foreach (Type mytype in System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(mytype => mytype.GetInterfaces().Contains(typeof(IForceActor))))
            {
                Globals.Forces.Add((IForceActor)Activator.CreateInstance(mytype));
            }
            GSForm = new GraphScreen();
            renderSurface = new DrawingSurface() { Dock = DockStyle.Fill };
            GSForm.panel1.Controls.Add(renderSurface);
            renderSurface.MouseClick += mouseClick;
            SetUpContextMenu();
            CreateNewPage tp = new CreateNewPage();
            tp.ShowDialog();
            diagram = tp.diagram;
            GSForm.Show();
            ProgramLoop();
        }

        #region Context menu 
        private static void SetUpContextMenu()
        {
            mnu = new ContextMenu();
            MenuItem mnuAdd = new MenuItem("Add child");
            MenuItem mnuDel = new MenuItem("Delete");
            MenuItem mnuProperties = new MenuItem("Change properties");
            mnuAdd.Click += new EventHandler(mnuAdd_Click);
            mnuDel.Click += new EventHandler(mnuDel_Click);
            //display the user control when this event occurs
            mnuProperties.Select += MnuProperties_Select;
            mnuProperties.Click += new EventHandler(mnuProperties_Click);
            mnu.MenuItems.AddRange(new MenuItem[] { mnuAdd, mnuDel, mnuProperties });
        }
        private static void MnuProperties_Select(object sender, EventArgs e)
        {
            //create new instance of User Control (NodeInspector)
            //add NodeInspector to context menu
        }

        private static void MnuName_Select(object sender, EventArgs e)
        {
            NodeInspector ni = new NodeInspector(selected, diagram, new Point((int)selected.X + 20, (int)selected.Y));
            renderSurface.Controls.Add(ni);
        }

        private static void mnuProperties_Click(object sender, EventArgs e)
        {
            NodeInspector ni = new NodeInspector(selected, diagram, new Point((int)selected.X + 20, (int)selected.Y));
            renderSurface.Controls.Add(ni);
        }

        private static void mnuDel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void mnuAdd_Click(object sender, EventArgs e)
        {
            //rethink this part - the child node can appear in all sorts of kooky places
            selected.AddChild();
            NodeInspector ni = new NodeInspector(selected.latest, diagram, new Point((int)selected.X + 20, (int)selected.Y));
            renderSurface.Controls.Add(ni);
        }
        #endregion

        private static void mouseClick(object sender, EventArgs e)
        {
            if (selected != null)
            {
                if (((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    mnu.Show(renderSurface, new System.Drawing.Point((int)mousePos.X, (int)mousePos.Y));
                    //System.Threading.Thread.Sleep(2);
                }
                else if (((MouseEventArgs)e).Button == MouseButtons.Left)
                {
                    if (held == null)
                    {
                        held = selected;
                    }
                    else
                    {
                        held = null;
                    }
                }
            }
            else { }
        }
        static void ProgramLoop()
        {
            // initialize sfml
            var settings = new ContextSettings() { AntialiasingLevel = 10 };
            renderwindow = new RenderWindow(renderSurface.Handle, settings); // creates our SFML RenderWindow on our surface control
            renderwindow.SetFramerateLimit(200);
            //diagram = new Diagram();
            // drawing loop
            ToolTip t = new ToolTip();
            while (GSForm.Visible) // loop while the window is open
            {
                while (playing)
                {
                    Application.DoEvents(); // handle form events
                    renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
                    renderwindow.Clear(SFML.Graphics.Color.White); // clear our SFML RenderWindow
                    if (held != null)
                    {
                        MoveToLocation();
                    }
                    Vector2i temp = Mouse.GetPosition(renderwindow);
                    mousePos = renderwindow.MapPixelToCoords(temp);
                    #region Updates
                    selected = diagram.Hover(mousePos);
                    if(selected != null)t.Show(selected.Text, GSForm, (int)selected.X, (int)selected.Y, 500);
                    diagram.WorkForces();
                    renderwindow.Draw(diagram);
                    //form.label1.Text = System.Convert.ToString(Constants.NEWTONS_GRAVITATIONAL);
                    #endregion
                    renderwindow.Display(); // display what SFML has drawn to the screen
                }
                Application.DoEvents();
            }
        }
        static void MoveToLocation()
        {
            //this isn't quite perfect - something to do with the Y location
            //the node will bounce off the lower and upper constraints
            Vector2f a = mousePos;
            int s = (held.Size / 2);
            if (mousePos.X <= s) a.X = s;
            else if (mousePos.X >= Globals.X_Con- s) a.X = Globals.X_Con- s;
            if (mousePos.Y <= (s+1)) a.Y = (s+1);
            else if (mousePos.Y >= Globals.Y_Con- (s+1)) a.Y = Globals.Y_Con- (s+1);
            held.Location = a;
        }
    }
}
