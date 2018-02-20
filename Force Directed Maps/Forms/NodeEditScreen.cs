using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Force_Directed_Maps
{
    public partial class NodeEditScreen : Form
    {
        Node node;
        Diagram diagram;
        public NodeEditScreen(Node n, Diagram d)
        {
            node = n;
            diagram = d;
            InitializeComponent();
        }

        //sort out a tree view thing
        private void NodeEditScreen_Load(object sender, EventArgs e)
        {
            NameBox.Text = node.Text;
            this.Location = new Point((int)node.X, (int)node.Y);
            //make the button a colour
            //button1.BackColor = new System.Drawing.Color(node.hColour.R, node.hColour.G, node.hColour.B, node.hColour.A);
            //Color s = new System.Drawing.Color();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                node.hColour = new SFML.Graphics.Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B, colorDialog1.Color.A);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            node.hColour = new SFML.Graphics.Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B, colorDialog1.Color.A);
            node.Text = NameBox.Text;
            this.Close();
        }
    }
}
