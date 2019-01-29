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
    }
}
