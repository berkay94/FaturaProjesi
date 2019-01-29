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
    public partial class FormUrun : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenId;
        public FormUrun()
        {
            InitializeComponent();
        }

        private void FormUrun_Load(object sender, EventArgs e)
        {
            BirimListele();
            Listele();
        }


        public void Listele()
        {
            try
            {
                var liste = from u in db.urunler
                            orderby u.UrunAdi
                            select new
                            {
                                u.UrunId
                               ,u.UrunAdi       
                               ,u.UrunKodu       
                               ,u.birim.BirimAdi     
                               ,u.BirimFiyat
                            };


                dataGridView1.DataSource = liste.ToList();

                txtUrunAdi.Clear();
                txtUrunKodu.Clear();
                txtBirimFiyat.Clear();

                txtUrunAdi.Focus();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

            public void BirimListele()
        {
            var list = db.birimler.Select(x => new { x.BirimId, x.BirimAdi }).OrderBy(x => x.BirimAdi).ToList();
            comboBox1.DisplayMember = "BirimAdi";
            comboBox1.ValueMember = "BirimId";
            comboBox1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Urun u = new Urun();
                u.UrunAdi = txtUrunAdi.Text;
                u.UrunKodu = txtUrunKodu.Text;
                u.BirimFiyat = Convert.ToDecimal(txtBirimFiyat.Text);
                u.BirimID = (int)comboBox1.SelectedValue;
                db.urunler.Add(u);
                db.SaveChanges();
                Listele();

               

            }
            catch (Exception)
            {

                MessageBox.Show("Tum alanlari doldurun");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Urun urun = db.urunler.Find(secilenId);
                urun.UrunAdi = txtUrunAdi.Text;
                urun.UrunKodu = txtUrunKodu.Text;
                urun.BirimFiyat = Convert.ToDecimal(txtBirimFiyat.Text);
                urun.BirimID = int.Parse(comboBox1.SelectedValue.ToString());
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Urun secmeniz gerekiyor!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                secilenId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                Urun u = db.urunler.Find(secilenId);
                txtUrunAdi.Text = u.UrunAdi;
                txtUrunKodu.Text = u.UrunKodu;
                txtBirimFiyat.Text = u.BirimFiyat.ToString();
                comboBox1.SelectedValue = u.birim.BirimId;
            }
            catch (Exception)
            {

                return;
            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urun urun = db.urunler.Find(secilenId);
            db.urunler.Remove(urun);
            db.SaveChanges();
            Listele();
        }
    }
}
