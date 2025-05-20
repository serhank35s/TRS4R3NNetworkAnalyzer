using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace TRS4R3N_Ag_Analiz
{
    public partial class Islem_Ekrani : Form
    {
        public Islem_Ekrani()
        {
            InitializeComponent();
        }
        public static string kart_isim="";
        public static int mb = 134217728;
        public static NetworkInterface[] ag_karti = NetworkInterface.GetAllNetworkInterfaces();
        private void ag_kart_tara_Click(object sender, EventArgs e)
        {
                    for (int i = 0; i < ag_karti.Length; i++)
                    {
                        AgKartlari.Items.Add(ag_karti[i].Name);
                    }
            kart_isim = AgKartlari.SelectedText.ToString();
        }

        private void Kart_Istatistik_Click(object sender, EventArgs e)
        {
            try
            {
            if(AgKartlari.SelectedIndex>=0)
                {
                ag_paket_suresi.Start();
                }
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Lutfen listeden secim yapiniz..!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void ag_paket_suresi_Tick(object sender, EventArgs e)
        {
            NetworkInterface ag_aygiti = ag_karti[AgKartlari.SelectedIndex];
            IPv4InterfaceStatistics ag_karti_bilgileri = ag_aygiti.GetIPv4Statistics();
            double alinan = (double)ag_karti_bilgileri.BytesReceived/mb;
            double gonderilen = (double)ag_karti_bilgileri.BytesSent/mb;
            double baglanti_hizi = (int)ag_aygiti.Speed;
            if(alinan>= 128&& alinan< 131072 || gonderilen >= 128 && gonderilen < 131072|| baglanti_hizi >= 128 && baglanti_hizi < 131072)
            {
                label1.Text = "Alinan Veri :" + (int)alinan + " Kbps";
                label2.Text = "Gonderilen Veri :" + (int)gonderilen + " Kbps";
                label3.Text = "Baglanti Hizi :" + (int)baglanti_hizi + " B/s";
                label4.Text = "Upload Hizi :" + (int)gonderilen + " Kbps";
                label5.Text = "Download Hizi :" + (int)alinan + " Kbps";
            }
            if (alinan >= 131072 && alinan < 134217728 || gonderilen >= 131072 && gonderilen < 134217728 || baglanti_hizi >= 131072 && baglanti_hizi < 134217728)
            {
                label1.Text = "Alinan Veri :" + alinan + " Mbps";
                label2.Text = "Gonderilen Veri :" + gonderilen + " Mbps";
                label3.Text = "Baglanti Hizi :" + baglanti_hizi + " B/s";
                label4.Text = "Upload Hizi :" + gonderilen + " Mbps";
                label5.Text = "Download Hizi :" + alinan + " Mbps";
            }
            if (alinan >= 134217728 && alinan < 137438945027.75 || gonderilen >= 134217728 && gonderilen < 137438945027.75 || baglanti_hizi >= 134217728 && baglanti_hizi < 137438945027.75)
            {
                label1.Text = "Alinan Veri :" + (int)alinan + " Gbps";
                label2.Text = "Gonderilen Veri :" + (int)gonderilen + " Gbps";
                label3.Text = "Baglanti Hizi :" + (int)baglanti_hizi + " B/s";
                label4.Text = "Upload Hizi :" + (int)gonderilen + " Gbps";
                label5.Text = "Download Hizi :" + (int)alinan + " Gbps";
            }
            if (alinan >= 137438945027.75 && alinan < 140737480741434.78 || gonderilen >= 137438945027.75 && gonderilen < 140737480741434.78 || baglanti_hizi >= 137438945027.75 && baglanti_hizi < 140737480741434.78)
            {
                label1.Text = "Alinan Veri :" + (int)alinan + " Tbps";
                label2.Text = "Gonderilen Veri :" + (int)gonderilen + " Tbps";
                label3.Text = "Baglanti Hizi :" + (int)baglanti_hizi + " B/s";
                label4.Text = "Upload Hizi :" + (int)gonderilen + " Tbps";
                label5.Text = "Download Hizi :" + (int)alinan + " Tbps";
            }
            if (alinan >= 140737480741434.78 && alinan < 144115180433971730 || gonderilen >= 140737480741434.78 && gonderilen < 144115180433971730 || baglanti_hizi >= 140737480741434.78 && baglanti_hizi < 144115180433971730)
            {
                label1.Text = "Alinan Veri :" + (int)alinan + " Pbps";
                label2.Text = "Gonderilen Veri :" + (int)gonderilen + " Pbps";
                label3.Text = "Baglanti Hizi :" + (int)baglanti_hizi + " B/s";
                label4.Text = "Upload Hizi :" + (int)gonderilen + " Pbps";
                label5.Text = "Download Hizi :" + (int)alinan + " Pbps";
            }
            if (alinan == 144115180433971730 || gonderilen == 144115180433971730 || baglanti_hizi == 144115180433971730)
            {
                label1.Text = "Alinan Veri :" + (int)alinan + " Ebps";
                label2.Text = "Gonderilen Veri :" + (int)gonderilen + " Ebps";
                label3.Text = "Baglanti Hizi :" + (int)baglanti_hizi + " B/s";
                label4.Text = "Upload Hizi :" + (int)gonderilen + " Ebps";
                label5.Text = "Download Hizi :" + (int)alinan + " Ebps";
            }
            label6.Text = "Ag Karti Isimi :" + ag_aygiti.Name;
            label7.Text = "Ag Karti Turu :" + ag_aygiti.NetworkInterfaceType.ToString();
            if (AgKartlari.SelectedText!=kart_isim)
            {
                ag_paket_suresi.Stop();
                label1.Text = "Alinan Veri :";
                label2.Text = "Gonderilen Veri :";
                label3.Text = "Baglanti Hizi :";
                label4.Text = "Upload Hizi :";
                label5.Text = "Download Hizi :";
                label6.Text = "Ag Karti Isimi :";
                label7.Text = "Ag Karti Turu :";
            }
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
