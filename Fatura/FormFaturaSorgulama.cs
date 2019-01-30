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
    public partial class FormFaturaSorgulama : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenId;
        public FormFaturaSorgulama()
        {
            InitializeComponent();
        }

        private void FormFaturaSorgulama_Load(object sender, EventArgs e)
        {
            MusteriSehriDoldur();
            Listele();
        }

        private void Listele()
        {
            dataGridView1.DataSource = (from f in db.faturamaster
                                       where f.FaturaID.ToString().Contains(txtFaturaNo.Text)
                                       orderby f.FaturaTarihi descending
                                       select new
                                       {
                                           f.FaturaID,
                                           f.MusteriID,
                                           f.musteri.MusteriUnvani,
                                           f.FaturaTarihi,
                                           f.OdemeTarihi,
                                           f.IrsaliyeNo,
                                           sehir = f.musteri.ilce.il.ILAdi,
                                           ilce = f.musteri.ilce.IlceAdi
                                       }).ToList();
        }

        private void MusteriSehriDoldur()
        {
            var list = db.iller.ToList();
            comboSehir.DisplayMember = "IlAdi";
            comboSehir.ValueMember = "IlId";
            comboSehir.DataSource = list;
        }

        private void comboSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            MusteriIlceDoldur();
        }

        private void MusteriIlceDoldur()
        {
            var list = db.ilceler.Where(x => x.ILId == (int)comboSehir.SelectedValue).ToList();
            comboIlce.DisplayMember = "IlceAdi";
            comboIlce.ValueMember = "IlceId";
            comboIlce.DataSource = list;

        }

        private void comboIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = db.musteriler.Where(x => x.IlceID == (int)comboIlce.SelectedValue).ToList();
            comboMusteri.DisplayMember = "MusteriUnvani";
            comboMusteri.ValueMember = "MusteriId";
            comboMusteri.DataSource = list;

        }

        private void comboMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from fm in db.faturamaster
                                        where fm.MusteriID == (int)comboMusteri.SelectedValue
                                        orderby fm.FaturaTarihi descending
                                        select new
                                        {
                                            fm.FaturaID,
                                            fm.MusteriID,
                                            fm.musteri.MusteriUnvani,
                                            sehir=fm.musteri.ilce.il.ILAdi,
                                            ilce=fm.musteri.ilce.IlceAdi,
                                            fm.FaturaTarihi,
                                            fm.IrsaliyeNo,
                                            fm.OdemeTarihi
                                        }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from fm in db.faturamaster
                                        orderby fm.FaturaTarihi descending
                                        select new
                                        {
                                            fm.FaturaID,
                                            fm.MusteriID,
                                            fm.musteri.MusteriUnvani,
                                            sehir = fm.musteri.ilce.il.ILAdi,
                                            ilce = fm.musteri.ilce.IlceAdi,
                                            fm.FaturaTarihi,
                                            fm.IrsaliyeNo,
                                            fm.OdemeTarihi
                                        }).ToList();
        }

        private void txtFaturaNo_TextChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenId =(int) dataGridView1.CurrentRow.Cells[0].Value;
            dataGridView2.DataSource = (from fd in db.faturadetay where fd.FaturaId == secilenId orderby fd.UrunId select fd).ToList();
        }
    }
}
