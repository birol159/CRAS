using System;
using System.Windows.Forms;

namespace CRAS
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        #region Properties

        public static string masa_adi = "";
        public static string masa_id = "";
        public string adisyon_id = "";
        private cGenel genel = new cGenel();
        private cSiparisler siparis = new cSiparisler();
        private cAyarlar ayarlar = new cAyarlar();

        #endregion Properties

        #region Masalar

        private void btnSalon_Click(object sender, EventArgs e)
        {
            // lvlMasalar salon ekleme
            genel.masaGetir(lvMasalar, "1");
        }

        private void btnBahce_Click(object sender, EventArgs e)
        {
            // lvlMasalar bahce ekleme
            genel.masaGetir(lvMasalar, "2");
        }

        private void btnLoca_Click(object sender, EventArgs e)
        {
            // lvlMasalar loca ekleme
            genel.masaGetir(lvMasalar, "3");
        }

        #endregion Masalar

        #region Cikis Yap

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmAyarlar ayarlar = new frmAyarlar();
            this.Hide();
            ayarlar.Show();
        }

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            frmGiris anamenu = new frmGiris();
            this.Hide();
            anamenu.Show();
        }

        private void btnKilitle_Click(object sender, EventArgs e)
        {
            frmGiris giris = new frmGiris();
            this.Hide();
            giris.Show();
        }

        #endregion Cikis Yap

        #region frmLoad

        private void frmMenu_Load(object sender, EventArgs e)
        {
            genel.masaGetir(lvMasalar, "1");
            btnOdeme.Enabled = false;
            btnSiparis.Enabled = false;
            btnMasaAktar.Enabled = false;
            btnIade.Enabled = false;
            genel.yetkilendirme(frmGiris.kullanici_adi, btnIade, btnMasaAktar, btnAyarlar,btnOdeme);
        }

        #endregion frmLoad

        #region Odeme / siparis

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            frmOdeme odeme = new frmOdeme();
            this.Hide();
            odeme.Show();
            masa_id = lvMasalar.SelectedItems[0].SubItems[1].Text;
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            frmSiparis siparis = new frmSiparis();
            this.Hide();
            siparis.Show();
        }

        #endregion Odeme / siparis

        #region Cift Tiklama

        private void lvlMasalar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            masa_adi = lvMasalar.SelectedItems[0].SubItems[0].Text;
            masa_id = lvMasalar.SelectedItems[0].SubItems[1].Text;
            frmSiparis frmSiparis = new frmSiparis();
            this.Hide();
            frmSiparis.Show();
        }

        #endregion Cift Tiklama

        #region Masa Aktar

        private void btnMasaAktar_Click(object sender, EventArgs e)
        {
            frmMasa masa = new frmMasa();
            this.Hide();
            masa.Show();
        }

        #endregion Masa Aktar

        #region Urun Iade

        private void btnIade_Click(object sender, EventArgs e)
        {
            try
            {
                siparis.urun_iade(lvHesap, masa_id, frmGiris.kullanici_adi, btnIade);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir hata meydana geldi lütfen yöneticinize başvurunuz.");
                genel.logEkle(ex.Message.ToString(),"Button iade kısmı frmMenu btnIade_click ");
            }
            
        }

        #endregion Urun Iade

        #region Hesap Getir

        private void lvlMasalar_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                decimal toplam = 0;
                btnSiparis.Enabled = true;
                btnIade.Enabled = false;
                masa_id = lvMasalar.SelectedItems[0].SubItems[1].Text;
                siparis.hesapGetir(lvHesap, masa_id, btnOdeme);
                if (lvHesap.Items[0].SubItems[0].Text != "Hesap Yoktur..")
                {
                    toplam = siparis.toplamBul(lvHesap, 1);
                }
                lblToplam.Text = toplam.ToString() + " TL";
                if (genel.hesapKontrol(masa_id) == true)
                {
                    btnMasaAktar.Enabled = true;
                }
                else
                {
                    btnMasaAktar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Tekrar Tıklayınız...");
                genel.logEkle(ex.Message.ToString(),"Hesap getir listview frmMenu lvMasalar_MouseClick");
            }
        }

        #endregion Hesap Getir

        #region İade button kontrolü

        private void lvlHesap_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvHesap.SelectedItems[0].SubItems[0].Text != "Hesap Yoktur..")
                {
                    btnIade.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tekrar tıklayınız...");
            }
            
        }

        #endregion İade button kontrolü
    }
}