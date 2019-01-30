using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Fatura
{
    public partial class FormYeniFatura : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenId;
        List<SecilenUrun> urunListesi = new List<SecilenUrun>();
        

        public FormYeniFatura()
        {
            InitializeComponent();
        }

        private void FormYeniFatura_Load(object sender, EventArgs e)
        {
            MusteriSehirDoldur();
            UrunDoldur();
        }

        private void MusteriSehirDoldur()
        {
            var list = db.iller.ToList();
            comboSehir.ValueMember = "ILId";
            comboSehir.DisplayMember = "ILAdi";
            comboSehir.DataSource = list;
        }
        
        private void UrunDoldur()
        {
            var list = from u in db.urunler
                       orderby u.UrunAdi
                       select new
                       {
                           u.UrunId,
                           u.UrunAdi,
                          
                       };

            comboUrunAd.DisplayMember = "UrunAdi";
            comboUrunAd.ValueMember = "UrunId";
            comboUrunAd.DataSource = list.ToList();
        }

        private void IlceDoldur()
        {
            var list = from ilceler in db.ilceler
                       where ilceler.ILId == (int)comboSehir.SelectedValue
                       select new { ilceler.IlceID, ilceler.IlceAdi };

            comboIlce.DisplayMember = "IlceAdi";
            comboIlce.ValueMember = "IlceID";
            comboIlce.DataSource = list.ToList();
        }

        private void comboSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            IlceDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            urunListesi.Add(
                new SecilenUrun
                {
                    UrunId = (int)comboUrunAd.SelectedValue,
                    UrunAdi = comboUrunAd.Text,
                    KDV=Convert.ToDecimal(txtUrunKdv.Text),
                    UrunFiyat= Convert.ToDecimal(txtUrunFiyat.Text),
                    Miktar= Convert.ToDecimal(numericMiktar.Value),
                    ToplamTutar=Convert.ToDecimal(txtUrunFiyat.Text)*Convert.ToDecimal(numericMiktar.Value)
                });
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var urun = urunListesi.Where(x => x.UrunId == secilenId).FirstOrDefault();
                    if (secilenId==(int)comboUrunAd.SelectedValue)
                    {
                         urun.Miktar = Convert.ToDecimal(numericMiktar.Value);
                         urun.ToplamTutar = Convert.ToDecimal(txtUrunFiyat.Text) * Convert.ToDecimal(numericMiktar.Value);
                    }
                    else
                    {
                         urun.UrunId = (int)comboUrunAd.SelectedValue;
                         urun.UrunAdi = comboUrunAd.Text;
                         urun.UrunFiyat = Convert.ToDecimal(txtUrunFiyat.Text);
                         urun.Miktar = Convert.ToDecimal(numericMiktar.Value);
                         urun.ToplamTutar = Convert.ToDecimal(txtUrunFiyat.Text) * Convert.ToDecimal(numericMiktar.Value);

                    }

                Listele();
                   
            }
            catch (Exception)
            {

                MessageBox.Show("Lutfen Urun Secin!");
            }
        }

        private void Listele()
        {
            dataGridView1.DataSource = urunListesi.Select(x => new
            {
                x.UrunId,
                x.UrunAdi,
                x.UrunFiyat,
                x.Miktar,
                x.KDV,
                x.ToplamTutar,
                GenelToplam = x.ToplamTutar + (x.ToplamTutar * x.KDV)/100

            }).ToList();

            dataGridView1.Columns[0].Visible = false;
            Temizle();
            FaturaToplam();
        }

        private void FaturaToplam()
        {
            decimal toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam += Convert.ToDecimal(dataGridView1[6, i].Value);
            }
            lblFaturaToplam.Text = toplam.ToString("0.00")+" TL";
        }

        private void Temizle()
        {
            numericMiktar.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var urun = urunListesi.Where(x => x.UrunId == secilenId).FirstOrDefault();
            urunListesi.Remove(urun);
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DbContextTransaction trans = db.Database.BeginTransaction();
            try
            {
                FaturaMasterKaydet();
                FaturaDetayKaydet();
                trans.Commit();
            }
            catch (Exception)
            {

                trans.Rollback();
                MessageBox.Show("Beklenmeyen bir hata olustu!");
            }
        }

        private void FaturaDetayKaydet()
        {
            foreach (SecilenUrun item in urunListesi)
            {
                FaturaDetay fd = new FaturaDetay();
                fd.FaturaId = Convert.ToInt32(lblFaturaNo.Text);
                fd.UrunId = item.UrunId;
                fd.Miktar = item.Miktar;
                fd.KDV = item.KDV;
                fd.ToplamFiyat = item.Miktar * item.UrunFiyat;
                fd.KDVliFiyat = fd.ToplamFiyat+(fd.ToplamFiyat * item.KDV/100);

                decimal toplam = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    toplam += Convert.ToDecimal(dataGridView1[6, i].Value);
                }
                fd.FaturaToplami = toplam;
                db.faturadetay.Add(fd);
                db.SaveChanges();

            }

            MessageBox.Show("Hele sükür bitti");


        }

        private void FaturaMasterKaydet()
        {
            FaturaMaster fm = new FaturaMaster();
            fm.IrsaliyeNo = Convert.ToInt32(txtIrsaliye.Text);
            fm.OdemeTarihi = Convert.ToDateTime(dateTimePicker1.Value);
            fm.MusteriID = (int)comboMusteri.SelectedValue;
            db.faturamaster.Add(fm);
            db.SaveChanges();
            lblFaturaNo.Text = fm.FaturaID.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            urunListesi.Clear();
        }

        private void comboUrunAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            var u = db.urunler.Find((int)comboUrunAd.SelectedValue);
           // decimal fiyat = db.urunler.Find((int)comboUrunAd.SelectedValue).BirimFiyat;
            txtUrunFiyat.Text = u.BirimFiyat.ToString();
            txtUrunBirim.Text = u.birim.BirimAdi;
            txtUrunKdv.Text = "8";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var urun = urunListesi.Where(x => x.UrunId == secilenId).FirstOrDefault();
            comboUrunAd.SelectedValue = secilenId;
            numericMiktar.Value = urun.Miktar;
        }

        private void comboIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            MusteriDoldur();
        }

        private void MusteriDoldur()
        {
            var mlist = (from m in db.musteriler
                         where m.IlceID == (int)comboIlce.SelectedValue
                         orderby m.MusteriUnvani
                         select new
                         {
                             m.IlceID,
                             m.MusteriID,
                             m.MusteriUnvani

                         }).ToList();

            if (mlist.Count!=0)
            {
                comboMusteri.DisplayMember = "MusteriUnvani";
                comboMusteri.ValueMember = "MusteriId";
                comboMusteri.DataSource = mlist;
            }
            else
            {
                comboMusteri.DataSource = null;
            }
        }
    }
}
