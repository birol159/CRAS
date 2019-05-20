using System;
using System.Windows.Forms;

namespace CRAS
{
    public partial class frmOdeme : Form
    {
        public frmOdeme()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public string odeme_turu = null;
        public string masaadi = frmMenu.masa_adi;
        private cGenel genel = new cGenel();
        private cUrunler urunler = new cUrunler();
        private cSiparisler siparis = new cSiparisler();

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            frmMenu anamenu = new frmMenu();
            this.Hide();
            anamenu.Show();
        }

        private void frmOdeme_Load(object sender, EventArgs e)
        {
            decimal toplam = 0;
            siparis.odeme_hesap_getir(lvSiparis, frmMenu.masa_id);
            toplam = siparis.toplamBul(lvSiparis, 2);
            lblToplam.Text = toplam.ToString() + " TL";
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (rdKredi.Checked)
            {
                odeme_turu = "1";
                btnOdeme.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
                frmMenu menu = new frmMenu();
                this.Hide();
                menu.Show();
            }
            else if (rdNakit.Checked)
            {
                odeme_turu = "2";
                btnOdeme.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
                frmMenu menu = new frmMenu();
                this.Hide();
                menu.Show();
            }
            else if (rdTicket.Checked)
            {
                odeme_turu = "3";
                btnOdeme.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
                frmMenu menu = new frmMenu();
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Lutfen Ödeme Türü Seçiniz !!!");
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            siparis.hesapOdeme(lvSiparis, frmMenu.masa_id, odeme_turu);
            siparis.aylikRaporEkle(lvSiparis);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Masa Başarıyla Kapatılmıştır.");
        }
    }
}