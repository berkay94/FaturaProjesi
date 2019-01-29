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
    public partial class FormMusteri : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenId;
        public FormMusteri()
        {
            InitializeComponent();
        }

        private void FormMusteri_Load(object sender, EventArgs e)
        {
            ilDoldur();
            Listele();
        }

        private void Listele()
        {
            var musteriler = from m in db.musteriler
                             select new
                             {
                                 m.MusteriID,
                                 m.MusteriUnvani,
                                 m.MusteriAdresi,
                                 m.ilce.IlceAdi,
                                 SehirAdi=m.ilce.il.ILAdi
                             };

            dataGridView1.DataSource = musteriler.ToList();
            txtAdres.Clear();
            txtUnvan.Clear();
            txtUnvan.Focus();
            
           
        }
        private void ilDoldur()
        {
            var iller = from il in db.iller select new { il.ILId, il.ILAdi };
            comboSehir.DisplayMember = "ILAdi";
            comboSehir.ValueMember = "ILId";
            comboSehir.DataSource = iller.ToList();
                
        }

        private void comboSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilceDoldur();

        }

        private void ilceDoldur()
        {
            var list = from ilce in db.ilceler
                       where ilce.ILId == (int)comboSehir.SelectedValue
                       orderby ilce.IlceAdi
                       select new
                       {
                           ilce.IlceID,
                           ilce.IlceAdi,
                           ilce.ILId

                       };
            comboIlce.DisplayMember = "IlceAdi";
            comboIlce.ValueMember = "IlceId";
            comboIlce.DataSource = list.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriUnvani = txtUnvan.Text;
            m.MusteriAdresi = txtAdres.Text;
            m.IlceID = (int)comboIlce.SelectedValue;
            db.musteriler.Add(m);
            db.SaveChanges();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musteri m = db.musteriler.Find(secilenId);
            m.MusteriAdresi = txtAdres.Text;
            m.MusteriUnvani = txtUnvan.Text;
            m.IlceID = (int)comboIlce.SelectedValue;
            db.SaveChanges();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Musteri m = db.musteriler.Find(secilenId);
            db.musteriler.Remove(m);
            db.SaveChanges();
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var musteri = db.musteriler.Find(secilenId);
            txtAdres.Text = musteri.MusteriAdresi;
            txtUnvan.Text = musteri.MusteriUnvani;
        }
    }
}
