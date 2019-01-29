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
    public partial class FormIlce : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenId;
        public FormIlce()
        {
            InitializeComponent();
        }

        private void Ilce_Load(object sender, EventArgs e)
        {
            ComboBoxListele();
            Listele();
          
        }

        public void Listele()
        {
            try
            {
                var list = db.ilceler.Select(x =>
                  new
                  {
                       x.ILId
                      ,x.IlceID
                      ,x.IlceAdi
                      ,SehirAdi = x.il.ILAdi
                  }).Where(x=>x.ILId==(int)comboBox1.SelectedValue).OrderBy(x=>x.SehirAdi).ToList();


                var liste2 = from i in db.ilceler where i.ILId == (int)comboBox1.SelectedValue
                             select new { i.ILId, i.IlceID, i.il.ILAdi, i.IlceAdi };


                dataGridView1.DataSource = list;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;

                txtilceAdi.Clear();
                txtilceAdi.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void ComboBoxListele()
        {
            var list = db.iller.Select(x => new { x.ILId, x.ILAdi }).OrderBy(x => x.ILAdi).ToList();
            comboBox1.DisplayMember = "ILAdi";
            comboBox1.ValueMember = "ILID";
            comboBox1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = new Ilce();
                ilce.IlceAdi = txtilceAdi.Text;
                ilce.ILId = int.Parse(comboBox1.SelectedValue.ToString());
                db.ilceler.Add(ilce);
                db.SaveChanges();
                Listele();
                
            
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = db.ilceler.Find(secilenId);
                ilce.IlceAdi = txtilceAdi.Text;
                ilce.ILId = int.Parse(comboBox1.SelectedValue.ToString());
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Ilce secmeniz gerekiyor!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                secilenId = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                txtilceAdi.Text  = dataGridView1.CurrentRow.Cells[2].Value.ToString();
               
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = db.ilceler.Find(secilenId);
                db.ilceler.Remove(ilce);
                db.SaveChanges();
                Listele();
            }
            catch
            {
                MessageBox.Show("Ilce secin");
            }
        }
    }
}
