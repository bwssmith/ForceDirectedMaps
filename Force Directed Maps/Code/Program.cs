using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Force_Directed_Maps
{
    static class Program
    {
        static GraphScreen GSForm;
        static DrawingSurface renderSurface;
        static Diagram diagram;
        //static Diagram backup;
        static bool playing = true;
        static RenderWindow renderwindow;
        static Vector2f mousePos;
        static Node selected;
        static ContextMenu mnu;
        [STAThread]  
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //this has a list of all the avaliable forces
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
            MenuItem mnuName = new MenuItem("Change properties");
            mnuAdd.Click += new EventHandler(mnuAdd_Click);
            mnuDel.Click += new EventHandler(mnuDel_Click);
            mnuName.Click += new EventHandler(mnuName_Click);
            //mnuName.Select += MnuName_Select;
            mnu.MenuItems.AddRange(new MenuItem[] { mnuAdd, mnuDel, mnuName });
        }

        private static void MnuName_Select(object sender, EventArgs e)
        {
            NodeInspector ni = new NodeInspector(selected, diagram);
            renderSurface.Controls.Add(ni);
        }

        private static void mnuName_Click(object sender, EventArgs e)
        {
            NodeInspector ni = new NodeInspector(selected, diagram);
            renderSurface.Controls.Add(ni);
        }

        private static void mnuDel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void mnuAdd_Click(object sender, EventArgs e)
        {
            selected.AddChild();
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
            }
            else { }
            //else if (((MouseEventArgs)e).Button == MouseButtons.Right) diagram.AddNode(new Point(mousePos.X, mousePos.Y));
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
                    renderwindow.Clear(Color.White); // clear our SFML RenderWindow

                    //in here get the last frames mouse position, should be basically the same as the next frame
                    //mousePos = Mouse.GetPosition();
                    Vector2i temp = Mouse.GetPosition(renderwindow);
                    mousePos = renderwindow.MapPixelToCoords(temp);
                    #region Updates
                    //also do the left clicky thing
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
    }
}
