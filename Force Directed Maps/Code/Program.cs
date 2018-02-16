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
        static Diagram backup;
        static bool playing = true;
        static RenderWindow renderwindow;
        static Vector2f mousePos;
        [STAThread]  
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GSForm = new GraphScreen();
            renderSurface = new DrawingSurface() { Dock = DockStyle.Fill };
            GSForm.panel1.Controls.Add(renderSurface);
            GSForm.Show();
            ProgramLoop();
        }
        static void ProgramLoop()
        {

            // initialize sfml
            var settings = new ContextSettings() { AntialiasingLevel = 10 };
            renderwindow = new RenderWindow(renderSurface.Handle, settings); // creates our SFML RenderWindow on our surface control
            renderwindow.SetFramerateLimit(200);
            diagram = new Diagram();
            // drawing loop
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
