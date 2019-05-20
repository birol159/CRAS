using System;
using System.Windows.Forms;

namespace CRAS
{
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        #region Sınıflar

        private cGenel genel = new cGenel();
        private cSiparisler siparisler = new cSiparisler();
        private cUrunler urunler = new cUrunler();

        #endregion Sınıflar

        #region Cikis / Geridon Buttonu

        // cikis
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // geridon
        private void button10_Click(object sender, EventArgs e)
        {
            frmMenu anamenu = new frmMenu();
            this.Hide();
            anamenu.Show();
        }

        #endregion Cikis / Geridon Buttonu

        #region Menuleri cekme

        private void btnAnayemek_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "1");
        }

        private void btnMakarna_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "2");
        }

        private void btnTatlilar_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "3");
        }

        private void btnSogukicecekler_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "4");
        }

        private void btnSicakicecekler_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "5");
        }

        private void btnNargile_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "6");
        }

        private void btnSalata_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "7");
        }

        private void btnAlkol_Click(object sender, EventArgs e)
        {
            siparisler.menuGetir(lvMenu, "8");
        }

        #endregion Menuleri cekme

        #region frmLoad

        private void frmSiparis_Load(object sender, EventArgs e)
        {
            // Masa no cekme
            lblMasaNo.Text = frmMenu.masa_adi;
        }

        #endregion frmLoad

        #region Urun Gonder

        private void btnGonder_Click(object sender, EventArgs e)
        {
            siparisler.Gonder(lvSiparis, frmMenu.masa_id, this);
        }

        #endregion Urun Gonder

        #region Urun Ekle

        private void lvMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (urunler.Ozellik_kontrol(urunler.urun_id_bul(lvMenu)) == true)
            {
                urunler.ozellikCek(lvOzellik, urunler.urun_id_bul(lvMenu));
            }
            else
            {
                urunler.urunEkle(lvMenu, lvSiparis);
                lvOzellik.Items.Clear();
            }
        }

        #endregion Urun Ekle

        #region Ozellik Secme

        private void lvOzellik_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            urunler.urunEkle(lvOzellik, lvSiparis, urunler.urun_id_bul(lvOzellik, 2));
        }

        #endregion Ozellik Secme

        private void lvSiparis_MouseDoubleClick(object sender, MouseEventArgs e) // iki tıklama ile urunleri silme
        {
            if (lvSiparis.Items.Count > 0)
            {
                lvSiparis.Items.RemoveAt(lvSiparis.SelectedIndices[0]);
            }
        }
    }
}