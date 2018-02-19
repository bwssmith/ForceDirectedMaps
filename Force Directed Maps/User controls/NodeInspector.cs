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
        public NodeInspector(Node n, Diagram d)
        {
            node = n;
            diagram = d;
            InitializeComponent();
        }
        
        private void NodeInspector_Load(object sender, EventArgs e)
        {
            NameBox.Text = node.Text;
            this.Location = new Point((int)node.X+20, (int)node.Y);
        }

        private void ColourButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                node.hColour = new SFML.Graphics.Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B, colorDialog1.Color.A);
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            node.hColour = new SFML.Graphics.Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B, colorDialog1.Color.A);
            node.Text = NameBox.Text;
            this.Parent.Controls.Remove(this);
        }
    }
}
