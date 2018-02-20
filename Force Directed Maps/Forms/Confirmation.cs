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
    public partial class Confirmation : Form
    {
        int i = -1;
        public Confirmation(string text, string l, string r, ref bool ans)
        {
            //very generic form 'returns' a boolean
            //can be reused in many situations
            InitializeComponent();
            label1.Text = text;
            LeftBut.Text = l;
            RightBut.Text = r;
            this.Show();
            while (i < 0) { Application.DoEvents(); }
            if (i == 1) ans = true;
            else ans = false;
            this.Close();
        }
        private void LeftBut_Click(object sender, EventArgs e)
        {
            i = 1;
        }
        private void RightBut_Click(object sender, EventArgs e)
        {
            i = 0;
        }
    }
}
