using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Lab2
{
    public partial class SwitchableForm : Form
    {
        public SwitchableForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.LoadForm(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.LoadForm(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.LoadForm(3);
        }
    }


}
