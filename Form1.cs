using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRS4R3N_Ag_Analiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sayac.Start();
        }
        private void sayac_Tick(object sender, EventArgs e)
        {
            Zamanlayici();
        }
        sbyte zaman = 0;
        protected void Zamanlayici()
        {
            zaman++;
            program_sayac.Value = zaman;
            label1.Text = "Yükleniyor %"+zaman;
            if(zaman==100)
            {
                zaman = 100;
                sayac.Stop();
                Islem_Ekrani i1 = new Islem_Ekrani();
                i1.Show();
                Hide();
            }
        }
    }
}
