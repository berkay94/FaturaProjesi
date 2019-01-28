using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Fatura
{
   public class FaturaContext:DbContext
    {
        public FaturaContext():base("baglanti")
        {

        }

        public virtual DbSet<FaturaMaster> faturamaster { get; set; }
        public virtual DbSet<FaturaDetay> faturadetay { get; set; }
        public virtual DbSet<Musteri> musteriler { get; set; }
        public virtual DbSet<Urun> urunler { get; set; }
        public virtual DbSet<Birim> birimler { get; set; }
        public virtual DbSet<Ilce> ilceler { get; set; }
        public virtual DbSet<IL> iller { get; set; }

    }


    [Table("IL")]
    public class IL
    {
        public IL()
        {
            this.ilce = new HashSet<Ilce>();
        }

        [Key]
        public int ILId { get; set; }
        public string ILAdi { get; set; }
        public virtual ICollection<Ilce> ilce { get; set; }



    }

    [Table("Ilce")]
    public class Ilce
    {
        public Ilce()
        {
            this.musteri = new HashSet<Musteri>();
        }

        [Key]
        public int IlceID { get; set; }
        public string IlceAdi { get; set; }
        public int ILId { get; set; }

        public virtual IL il { get; set; }

        public virtual ICollection<Musteri> musteri { get; set; }

        
    }


    [Table("Urun")]
    public class Urun
    {
        public Urun()
        {
            this.faturadetay = new HashSet<FaturaDetay>();
        }

        [Key]
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunKodu { get; set; }
        public int BirimID { get; set; }
        public decimal BirimFiyat { get; set; }
        public virtual Birim birim { get; set; }
        public virtual ICollection<FaturaDetay> faturadetay { get; set; }



    }


    [Table("Birim")]
    public class Birim
    {
        public Birim()
        {
            this.urun = new HashSet<Urun>();
        }

        [Key]
        public int BirimId { get; set; }
        public string BirimAdi { get; set; }
        public virtual ICollection<Urun> urun { get; set; }


    }


    [Table("Musteri")]
    public class Musteri
    {
        public Musteri()
        {
            this.FaturaMaster = new HashSet<FaturaMaster>();
        }

        [Key]
        public int MusteriID { get; set; }
        public string MusteriUnvani { get; set; }
        public int IlceID { get; set; }
        public string MusteriAdresi { get; set; }
        public virtual Ilce ilce { get; set; }

        public virtual ICollection<FaturaMaster> FaturaMaster { get; set; }

       
    }


    [Table("FaturaMaster")]
    public class FaturaMaster
    {
        public FaturaMaster()
        {
            this.faturadetay = new HashSet<FaturaDetay>();
            this.FaturaTarihi = DateTime.Now;
        }

        [Key]
        public int FaturaID { get; set; }

        public int MusteriID { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public int IrsaliyeNo { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public virtual Musteri musteri { get; set; }
        public virtual ICollection<FaturaDetay> faturadetay { get; set; }
    }


    [Table("FaturaDetay")]
    public class FaturaDetay
    {
        public FaturaDetay()
        {
            this.Aciklama = "Vadesinden sonra odenen taksitlere %5 kanuni ceza faizi uygulanir";
        }


        [Key][Column(Order =0)]
        public int FaturaId { get; set; }

        [Key][Column(Order =1)]
        public int UrunId { get; set; }

        public decimal Miktar { get; set; }
        public decimal ToplamFiyat { get; set; }
        public decimal KDV { get; set; }
        public decimal KDVliFiyat { get; set; }
        public decimal FaturaToplami { get; set; }
        public string Aciklama { get; set; }

        public virtual FaturaMaster faturamaster { get; set; }
        public virtual Urun urun { get; set; }
    }
}
