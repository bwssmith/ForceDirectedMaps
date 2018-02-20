using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Force_Directed_Maps
{
    public partial class NodeInspector : UserControl
    {
        Node node;
        Diagram diagram;
        bool change = false;
        public NodeInspector(Node n, Diagram d, Point p)
        {
            node = n;
            diagram = d;
            this.Location = p;
            InitializeComponent();
        }
        
        private void NodeInspector_Load(object sender, EventArgs e)
        {
            NameBox.Text = node.Text;
            //Color c = new System.Drawing.Color();
        }

        private void ColourButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                node.hColour = new SFML.Graphics.Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B, colorDialog1.Color.A);
            }
            change = true;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            if(change)node.hColour = new SFML.Graphics.Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B, colorDialog1.Color.A);
            node.Text = NameBox.Text;
            this.Parent.Controls.Remove(this);
        }
    }
}
