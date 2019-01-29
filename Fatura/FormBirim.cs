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
    public partial class FormBirim : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenId;
        public FormBirim()
        {
            InitializeComponent();
        }

        private void FormBirim_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Birim birim = new Birim();
                birim.BirimAdi = txtBirimAd.Text;
                db.birimler.Add(birim);
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
            var list = db.birimler.Select(I => new {I.BirimId, I.BirimAdi }).ToList();
            dataGridView1.DataSource = list;
            txtBirimAd.Clear();
            txtBirimAd.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Birim birim = db.birimler.Find(secilenId);
            txtBirimAd.Text = birim.BirimAdi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Birim birim = db.birimler.Find(secilenId);
                db.birimler.Remove(birim);
                db.SaveChanges();
                Listele();
            }
            catch
            {
                MessageBox.Show("Birim secmeniz gerekiyor!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Birim birim = db.birimler.Find(secilenId);
                birim.BirimAdi = txtBirimAd.Text;
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Birim secmeniz gerekiyor!");
            }
        }
    }
}
