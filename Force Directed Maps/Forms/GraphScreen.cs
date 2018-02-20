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
    public partial class GraphScreen : Form
    {
        public GraphScreen()
        {
            InitializeComponent();
        }

        private void GraphScreen_Load(object sender, EventArgs e)
        {
            //ContextMenu mnu = new ContextMenu();
            //MenuItem mnuAdd = new MenuItem("Add child");
            //MenuItem mnuDel = new MenuItem("Delete");
            //MenuItem mnuName = new MenuItem("Change name");
            //mnuAdd.Click += new EventHandler(mnuAdd_Click);
            //mnuDel.Click += new EventHandler(mnuDel_Click);
            //mnuName.Click += new EventHandler(mnuName_Click);
            //mnu.MenuItems.AddRange(new MenuItem[] { mnuAdd, mnuDel, mnuName });
            //panel1.ContextMenu = mnu;
        }

        private void mnuDel_Click(object sender, EventArgs e)
        {
            //delete
        }

        private void mnuName_Click(object sender, EventArgs e)
        {
            //change the name
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            //add a child
        }
    }
}
