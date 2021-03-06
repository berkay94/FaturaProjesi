﻿using System;
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
        int secilenId;
        public FormIl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IL il = new IL();
                il.ILAdi = txtilAdi.Text;
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
            var list = db.iller.Select(I => new { I.ILId, I.ILAdi  }).ToList();
            dataGridView1.DataSource = list;
            txtilAdi.Clear();
            txtilAdi.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            IL il = db.iller.Find(secilenId);
            txtilAdi.Text = il.ILAdi;
        }

        private void FormIl_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                IL il = db.iller.Find(secilenId);
                il.ILAdi = txtilAdi.Text;
                db.SaveChanges();
                Listele();
            }
            catch(Exception)
            {
                MessageBox.Show("Il secmeniz gerekiyor!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IL il = db.iller.Find(secilenId);
                db.iller.Remove(il);
                db.SaveChanges();
                Listele();
            }
            catch
            {
                MessageBox.Show("Il secmeniz gerekiyor!");
            }
        }
    }
}
