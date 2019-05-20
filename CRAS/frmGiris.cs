using System;
using System.Windows.Forms;

namespace CRAS
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        #region Properties

        public static string kullanici_adi = null;
        private cGenel genel = new cGenel();

        #endregion Properties

        #region Giris Yap

        private void button1_Click(object sender, EventArgs e)
        {
            string kadi = kullaniciadi.Text;
            string sifre = ksifre.Text;

            if (genel.cras_giris(kadi, sifre) == true)
            {
                kullanici_adi = kadi;
                frmMenu anamenu = new frmMenu();
                this.Hide();
                anamenu.Show();
            }
            else
            {
                MessageBox.Show("Kullanici Adi Sifre Yanlis...\nTekrar Deneyiniz");
                ksifre.Clear();
            }
        }

        #endregion Giris Yap

        #region Cikis Yap

        private void button2_Click(object sender, EventArgs e)// cikis butonu
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion Cikis Yap
    }
}