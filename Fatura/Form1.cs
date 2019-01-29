using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fatura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ıLEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIl formIl = new FormIl();
            formIl.Show();
        }

        private void ılceEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIlce formIlce = new FormIlce();
            formIlce.Show();
        }

        private void birimEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBirim formBirim = new FormBirim();
            formBirim.Show();
        }

        private void urunEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUrun formUrun = new FormUrun();
            formUrun.Show();
        }
    }
}
