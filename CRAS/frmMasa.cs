using System;
using System.Windows.Forms;

namespace CRAS
{
    public partial class frmMasa : Form
    {
        public frmMasa()
        {
            InitializeComponent();
        }

        #region Properties

        private cGenel genel = new cGenel();
        private cSiparisler siparis = new cSiparisler();
        public string aktarilan = null;

        #endregion Properties

        #region Cikis / Geri don

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

        #endregion Cikis / Geri don

        #region Masa Getir

        private void btnSalon_Click(object sender, EventArgs e)
        {
            genel.masaGetir(lvMasalar, "1", frmMenu.masa_id);
        }

        private void btnBahce_Click(object sender, EventArgs e)
        {
            genel.masaGetir(lvMasalar, "2", frmMenu.masa_id);
        }

        private void btnLoca_Click(object sender, EventArgs e)
        {
            genel.masaGetir(lvMasalar, "3", frmMenu.masa_id);
        }

        #endregion Masa Getir

        #region frmLoad

        private void frmMasa_Load(object sender, EventArgs e)
        {
            genel.masaGetir(lvMasalar, "1", frmMenu.masa_id);
            btnMasaAktar.Enabled = false;
            siparis.hesapGetir(lvHesap, frmMenu.masa_id);
        }

        #endregion frmLoad

        #region Masa Aktar

        private void btnMasaAktar_Click(object sender, EventArgs e)
        {
            if (genel.hesapKontrol(frmMenu.masa_id) == true)
            {
                if(MessageBox.Show("Eklemek istediğiniz masada zaten hesap bulunmaktadır, bu hesapları birleştirmek istediğinize emin misiniz ?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    siparis.masa_aktar(frmMenu.masa_id, aktarilan, this);
                }
            }
            else
            {
                siparis.masa_aktar(frmMenu.masa_id, aktarilan, this);
            }
            
        }

        #endregion Masa Aktar

        #region listview Tek Tik

        private void lvMasalar_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                btnMasaAktar.Enabled = true;
                aktarilan = lvMasalar.SelectedItems[0].SubItems[1].Text;
                siparis.hesapGetir(lvHedefMasa, aktarilan);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tekrar tıklayınız...");
                
            }
           
        }

        #endregion listview Tek Tik
    }
}