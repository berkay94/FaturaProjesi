namespace Fatura
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tanımlamalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musteriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birimEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ıLEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ılceEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faturaİslemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görüntüleSorgulaDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniFaturaOlusturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tanımlamalarToolStripMenuItem,
            this.faturaİslemleriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tanımlamalarToolStripMenuItem
            // 
            this.tanımlamalarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musteriEkleToolStripMenuItem,
            this.birimEkleToolStripMenuItem,
            this.urunEkleToolStripMenuItem,
            this.ıLEkleToolStripMenuItem,
            this.ılceEkleToolStripMenuItem});
            this.tanımlamalarToolStripMenuItem.Name = "tanımlamalarToolStripMenuItem";
            this.tanımlamalarToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.tanımlamalarToolStripMenuItem.Text = "Tanımlamalar";
            // 
            // musteriEkleToolStripMenuItem
            // 
            this.musteriEkleToolStripMenuItem.Name = "musteriEkleToolStripMenuItem";
            this.musteriEkleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.musteriEkleToolStripMenuItem.Text = "Musteri Ekle";
            this.musteriEkleToolStripMenuItem.Click += new System.EventHandler(this.musteriEkleToolStripMenuItem_Click);
            // 
            // birimEkleToolStripMenuItem
            // 
            this.birimEkleToolStripMenuItem.Name = "birimEkleToolStripMenuItem";
            this.birimEkleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.birimEkleToolStripMenuItem.Text = "Birim Ekle";
            this.birimEkleToolStripMenuItem.Click += new System.EventHandler(this.birimEkleToolStripMenuItem_Click);
            // 
            // urunEkleToolStripMenuItem
            // 
            this.urunEkleToolStripMenuItem.Name = "urunEkleToolStripMenuItem";
            this.urunEkleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.urunEkleToolStripMenuItem.Text = "Urun Ekle";
            this.urunEkleToolStripMenuItem.Click += new System.EventHandler(this.urunEkleToolStripMenuItem_Click);
            // 
            // ıLEkleToolStripMenuItem
            // 
            this.ıLEkleToolStripMenuItem.Name = "ıLEkleToolStripMenuItem";
            this.ıLEkleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ıLEkleToolStripMenuItem.Text = "IL Ekle";
            this.ıLEkleToolStripMenuItem.Click += new System.EventHandler(this.ıLEkleToolStripMenuItem_Click);
            // 
            // ılceEkleToolStripMenuItem
            // 
            this.ılceEkleToolStripMenuItem.Name = "ılceEkleToolStripMenuItem";
            this.ılceEkleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ılceEkleToolStripMenuItem.Text = "Ilce Ekle";
            this.ılceEkleToolStripMenuItem.Click += new System.EventHandler(this.ılceEkleToolStripMenuItem_Click);
            // 
            // faturaİslemleriToolStripMenuItem
            // 
            this.faturaİslemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.görüntüleSorgulaDüzenleToolStripMenuItem,
            this.yeniFaturaOlusturToolStripMenuItem});
            this.faturaİslemleriToolStripMenuItem.Name = "faturaİslemleriToolStripMenuItem";
            this.faturaİslemleriToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.faturaİslemleriToolStripMenuItem.Text = "Fatura İslemleri";
            // 
            // görüntüleSorgulaDüzenleToolStripMenuItem
            // 
            this.görüntüleSorgulaDüzenleToolStripMenuItem.Name = "görüntüleSorgulaDüzenleToolStripMenuItem";
            this.görüntüleSorgulaDüzenleToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.görüntüleSorgulaDüzenleToolStripMenuItem.Text = "Goruntule/Sorgula/Duzenle";
            this.görüntüleSorgulaDüzenleToolStripMenuItem.Click += new System.EventHandler(this.görüntüleDorgulaDüzenleToolStripMenuItem_Click);
            // 
            // yeniFaturaOlusturToolStripMenuItem
            // 
            this.yeniFaturaOlusturToolStripMenuItem.Name = "yeniFaturaOlusturToolStripMenuItem";
            this.yeniFaturaOlusturToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.yeniFaturaOlusturToolStripMenuItem.Text = "Yeni Fatura Olustur";
            this.yeniFaturaOlusturToolStripMenuItem.Click += new System.EventHandler(this.yeniFaturaOlusturToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tanımlamalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem birimEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ıLEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ılceEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faturaİslemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görüntüleSorgulaDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniFaturaOlusturToolStripMenuItem;
    }
}

