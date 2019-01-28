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
    public partial class FormIl : Form
    {
        FaturaContext db = new FaturaContext();
        public FormIl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IL il = new IL();
                il.ILAdi = textIl.Text;
                db.iller.Add(il);
                db.SaveChanges();
                Listele();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                
            }
        }

        public void Listele()
        {
            var list = db.iller.Select(I => new { I.ILAdi, I.ILId }).ToList();
            dataGridView1.DataSource = list;
            textIl.Clear();
            textIl.Focus();
        }
    }
}
