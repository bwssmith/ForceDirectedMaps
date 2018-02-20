using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Force_Directed_Maps
{
    public partial class CustomChart : Form
    {
        List<CheckBox> ForceChecks;
        public Diagram diagram;
        public CustomChart()
        {
            InitializeComponent();
        }

        private void CustomChart_Load(object sender, EventArgs e)
        {
            ForceChecks = new List<CheckBox>();
            CreateCheckBoxes();
        }
        private void CreateCheckBoxes()
        {
            const int seperation = 20;
            Font myfont = new Font("Microsoft Sans Serif", 8);
            int y = 0;
            foreach (IForceActor mytype in Globals.Forces)
            {
                var check = new CheckBox();
                check.Location = new Point(0, y);
                check.Text = mytype.ForceName();
                check.Font = myfont;
                check.AutoSize = true;
                panel1.Controls.Add(check);
                y += seperation;
                ForceChecks.Add(check);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != "")
            {
                //asks the user if they want to save their new chart template
                bool a = false;
                Confirmation d = new Confirmation("Do you want to save this new \nchart template?", "Yes", "No", ref a);
                //if yes, will open a file dialogue
                List<IForceActor> ChosenForces = new List<IForceActor>();
                int i = 0;
                List<int> ChoseArray = new List<int>();
                foreach (CheckBox c in ForceChecks)
                {
                    if (c.Checked)
                    {
                        ChosenForces.Add(Globals.Forces[i]);
                        ChoseArray.Add(i);
                    }
                    i++;
                }
                if (ChosenForces.Count == 0) MessageBox.Show("Please select some forces to apply to the diagram.");
                else
                {
                    if (a)
                    {
                        //StreamWriter sw = new StreamWriter("UserChartsPanel.txt");
                        string t = "";
                        foreach (int x in ChoseArray) t += "," + x;
                        using (StreamWriter sw = File.AppendText("UserChartsPanel.txt"))
                        {
                            sw.WriteLine(NameBox.Text + t);
                        }
                    }
                    diagram = new Diagram(ChosenForces);
                    this.Close();
                }
            }
            else MessageBox.Show("Please choose a name for your chart type");
        }
    }
}
