using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : DavComponent.DavForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
       
        private void Button3_Click(object sender, EventArgs e)
        {
            new Form1().Show(this);
        }

        private void DavButton2_Click(object sender, EventArgs e)
        {
            davButton1.Enabled = !davButton1.Enabled;
        }

        private void DavButton2_Click_1(object sender, EventArgs e)
        {
            new Form1().Show(this);
        }
    }
}
