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
    public partial class CreateNewPage : Form
    {
        public Diagram diagram;
        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
        public CreateNewPage()
        {
            InitializeComponent();
            //diagram = new Diagram();
            //dank idea, the skins for the buttons could be graphs rendered in real time
            //ToolTip1.SetToolTip(this.spider, "Forces acting:\n • Electrostatic repulsion\n • Springs\n • Corner repulsion");
            ToolTip1.SetToolTip(this.CustomChartButton, "Create a new type of chart with any forces you want");
        }
        private void CustomChartButton_Click(object sender, EventArgs e)
        {
            CustomChart cc = new CustomChart();
            cc.ShowDialog();
            diagram = cc.diagram;
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateNewPage_Load(object sender, EventArgs e)
        {
            #region Scrollbars for the panels
            PresetPanel.AutoScroll = false;
            PresetPanel.HorizontalScroll.Enabled = false;
            PresetPanel.HorizontalScroll.Visible = false;
            PresetPanel.HorizontalScroll.Maximum = 0;
            PresetPanel.AutoScroll = true;
            PresetPanel.VerticalScroll.SmallChange = 100;
            PresetPanel.VerticalScroll.LargeChange = 100;
            UserPanel.AutoScroll = false;
            UserPanel.HorizontalScroll.Enabled = false;
            UserPanel.HorizontalScroll.Visible = false;
            UserPanel.HorizontalScroll.Maximum = 0;
            UserPanel.AutoScroll = true;
            UserPanel.VerticalScroll.SmallChange = 100;
            UserPanel.VerticalScroll.LargeChange = 100;
            Label empty = new Label();
            empty.AutoSize = true;
            empty.Text = "Sorry, looks like there aren't any custom chart types.\nPlease make some!";
            UserPanel.Controls.Add(empty);
            #endregion
            #region Adding content to the buttons
            int y = 0;
            AddButton(PresetPanel, "Spider chart",ref y, new List<IForceActor>(new IForceActor[] { new ElectroRepulsion_FA(), new Springs_FA(), new CornerRep_FA() }));
            StreamReader sr = new StreamReader("UserChartsPanel.txt");
            string[] splut;
            List<IForceActor> present;
            y = 0;
            while (!sr.EndOfStream)
            {
                UserPanel.Controls.Remove(empty);   
                present = new List<IForceActor>();
                splut = sr.ReadLine().Split(',');
                for (int i = 1; i < splut.Length; i++) present.Add(Globals.Forces[System.Convert.ToInt32(splut[i])]);
                AddButton(UserPanel, splut[0], ref y, present);
            }
            sr.Close();
            #endregion
        }
        private void AddButton(Panel p, string t, ref int y, List<IForceActor> present)
        {
            var but = new Button();
            but.Size = new System.Drawing.Size(500, 100);
            but.Text = t;
            but.BackColor = Color.LightGray;
            but.Location = new Point(0, y);
            p.Controls.Add(but);
            t = "";
            foreach (IForceActor f in present) t += "\n • " + f.ForceName();
            ToolTip1.SetToolTip(but, "Forces acting:" + t);
            but.MouseClick += (sender, e) => But_MouseClick(sender, e, (List<IForceActor>)present);
            y += 100;
        }

        private void But_MouseClick(object sender, MouseEventArgs e, List<IForceActor> present)
        {
            diagram = new Diagram(present);
            this.Close();
        }
    }
}
