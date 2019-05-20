using System;
using System.Windows.Forms;

namespace CRAS
{
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        #region Properties

        private cGenel genel = new cGenel();
        private cSiparisler siparisler = new cSiparisler();
        private cUrunler urunler = new cUrunler();
        private cAyarlar ayarlar = new cAyarlar();
        public string kategori_id = "1", ozellik_id = null, yetki_seviyesi = null, kullanici_id = null, urun_adi = null, odeme_durumu = null, rapor_cinsi = null, urun_id = null;
        public decimal[] sonuc = new decimal[3];
        private string ay = null, yil = null, gun = null;

        #endregion Properties

        #region Panel Gizle / txTemizle / toplam goster / tarih goster gizle

        public void txGuncelleTemizle()
        {
            txOzellikAdiGuncelle.Clear();
            txOzellikAdiSil.Clear();
        }

        public void panel_gizle()
        {
            pnlUrunGuncelle.Visible = false;
            pnlOzellikler.Visible = false;
            pnlRaporlar.Visible = false;
            pnlPersonel.Visible = false;
            pnlAyarlar.Visible = false;
        }

        public void toplamGoster()
        {
            lblOdemeCesit.Visible = true;
            lblKredi.Visible = true;
            lblNakit.Visible = true;
            lblTicket.Visible = true;
            txKredi.Visible = true;
            txTicket.Visible = true;
            txNakit.Visible = true;
            lblToplam.Visible = true;
            txToplam.Visible = true;
        }

        public void toplamGizle()
        {
            lblOdemeCesit.Visible = false;
            lblKredi.Visible = false;
            lblNakit.Visible = false;
            lblTicket.Visible = false;
            lblToplam.Visible = false;
            txKredi.Visible = false;
            txTicket.Visible = false;
            txNakit.Visible = false;
            txToplam.Visible = false;
        }

        public void toplamGoster(decimal[] sonuc)
        {
            txKredi.Text = sonuc[0].ToString() + " TL";
            txNakit.Text = sonuc[1].ToString() + " TL";
            txTicket.Text = sonuc[2].ToString() + " TL";
            txToplam.Text = sonuc[3].ToString() + " TL";
        }

        public void cbTarihGizle()
        {
            cbAylar.Visible = false;
            cbGunler.Visible = false;
            cbYillar.Visible = false;
            cbPersonelAy.Visible = false;
            cbPersonelGun.Visible = false;
            cbPersonelYil.Visible = false;
        }

        public void cbTarihGoster()
        {
            cbAylar.Visible = true;
            cbGunler.Visible = true;
            cbYillar.Visible = true;
            cbPersonelAy.Visible = true;
            cbPersonelGun.Visible = true;
            cbPersonelYil.Visible = true;
        }

        public void cbAylikGoster()
        {
            cbAylar.Visible = true;
            cbYillar.Visible = true;
            cbPersonelAy.Visible = true;
            cbPersonelYil.Visible = true;
        }

        public void raporlarTemizle()
        {
            lvSatilanUrunler.Items.Clear();
            lvToplamSatislar.Items.Clear();
            txKredi.Clear();
            txTicket.Clear();
            txNakit.Clear();
        }

        #endregion Panel Gizle / txTemizle / toplam goster / tarih goster gizle

        #region Giris / Cikis Buton

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion Giris / Cikis Buton

        #region tab menu

        private void urunlerGoruntule_Click(object sender, EventArgs e)
        {
            panel_gizle();
            kategori_id = null;
            pnlUrunGuncelle.Visible = true;
            ayarlar.urunleriGetir(lvUrunler, "1");
        }

        private void kategorilerGoruntule_Click(object sender, EventArgs e)
        {
            panel_gizle();
            pnlOzellikler.Visible = true;
            ayarlar.ozellikUrunGetir(lvUrunler2, "1");
            btnOzellikSil.Enabled = false;
            btnOzellikGuncelle.Enabled = false;
        }

        private void raporlarGoruntule_Click(object sender, EventArgs e)
        {
            panel_gizle();
            pnlRaporlar.Visible = true;
        }

        private void personelGoruntule_Click(object sender, EventArgs e)
        {
            panel_gizle();
            pnlPersonel.Visible = true;
        }

        private void ayarlarGoruntule_Click(object sender, EventArgs e)
        {
            panel_gizle();
            pnlAyarlar.Visible = true;
            ayarlar.kullanicilariGetir(lvKullanicilar);// kullanicilar listboxa eklenir
            cbYetkiSeviyesiGuncelle.Items.Clear();// tekrar veri girisi engellenmesi icin silinir
            ayarlar.yetkiGetir(cbYetkiSeviyesiGuncelle);// yetki sevileri combobox a eklenir
        }

        #endregion tab menu

        #region frmLoad

        private void frmOzellikler_Load(object sender, EventArgs e)
        {
            cbTarihGizle();
            string tarih = genel.tarih_gun();
            cbGunler.SelectedIndex = Convert.ToInt32(tarih) - 1;
            tarih = genel.tarih_ay();
            cbAylar.SelectedIndex = Convert.ToInt32(tarih) - 1;
            tarih = genel.tarih_yil();
            int index = 0;
            index = (Convert.ToInt32(tarih) - 2000);
            cbYillar.SelectedIndex = index;
            cbPersonelYil.SelectedIndex = index;
            tarih = genel.tarih_gun();
            cbPersonelGun.SelectedIndex = Convert.ToInt32(tarih) - 1;
            tarih = genel.tarih_ay();
            cbPersonelAy.SelectedIndex = Convert.ToInt32(tarih) - 1;
            panel_gizle();
            toplamGizle();
            ayarlar.yetkiGetir(cbYetkiSeviyesiEkle);
            pnlUrunGuncelle.Visible = true; // gösterilecek panel
            ayarlar.urunleriGetir(lvUrunler, "1");
            ayarlar.kategoriGetir(cbKategoriler);
            btnKullaniciGuncelle.Enabled = false;
            btnKullaniciSil.Enabled = false;
            btnOzellikEkle.Enabled = false;
            btnOzellikSil.Enabled = false;
            btnOzellikGuncelle.Enabled = false;
        }

        #endregion frmLoad

        #region Ürünler

        #region Ürünleri Getir

        private void btnAnayemekler_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "1");
        }

        private void btnMakarnalar_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "2");
        }

        private void btnTatlilar_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "3");
        }

        private void btnSalatalar_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "7");
        }

        private void btnSicakicecekler_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "5");
        }

        private void btnSogukicecekler_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "4");
        }

        private void btnNargileler_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "6");
        }

        private void btnAlkolluicecekler_Click(object sender, EventArgs e)
        {
            ayarlar.urunleriGetir(lvUrunler, "8");
        }

        #endregion Ürünleri Getir

        #region Ürünleri txt e cekme

        private void lvUrunler_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvUrunler.Items.Count > 0)
                {
                    urun_id = lvUrunler.SelectedItems[0].SubItems[0].Text;
                    kategori_id = lvUrunler.SelectedItems[0].SubItems[3].Text;
                    txAdiSil.Text = lvUrunler.SelectedItems[0].SubItems[1].Text;
                    ayarlar.urunGetir(txAdi, txFiyati, txAdiSil, urun_id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tekrar Tiklayiniz.");
            }
        }

        #endregion Ürünleri txt e cekme

        #region Ürün Güncelle / Ekle / Sil

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txAdi.Text) || !string.IsNullOrWhiteSpace(txFiyati.Text))
                {
                    string urun_fiyat = txFiyati.Text;
                    urun_fiyat = urun_fiyat.Replace(".", ",");
                    decimal fiyat = Convert.ToDecimal(urun_fiyat);
                    ayarlar.urunGuncelle(lvUrunler, txAdi, fiyat, urun_id, kategori_id);
                }
                else
                {
                    MessageBox.Show("Lütfen ürün seçiniz.");
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    MessageBox.Show("Girilen değer hatali girilmiştir lütfen tekrar deneyiniz.");
                }
                MessageBox.Show("Bir hata meydana geldi lütfen yöneticinize başvurunuz.");
                genel.logEkle(ex.Message.ToString(), "Ürün güncelleme frmAyarlar btnGuncelle_click");
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txAdi2.Text) && !string.IsNullOrWhiteSpace(txFiyati2.Text) && kategori_id != null)
                {
                    ayarlar.urunEkle(lvUrunler, txAdi2, txFiyati2, kategori_id);
                }
                else
                {
                    MessageBox.Show("Lütfen alanları boş bırakmayınız.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (urun_id != null)
                {
                    if (MessageBox.Show("Ürünü Silmek İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ayarlar.urunSil(lvUrunler, txAdiSil, kategori_id, urun_id);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz ürünü seçiniz!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        #endregion Ürün Güncelle / Ekle / Sil

        #region Kategori Seç

        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kategori = cbKategoriler.SelectedItem.ToString();
            kategori_id = ayarlar.kategori_id_bul(kategori);
        }

        #endregion Kategori Seç

        #endregion Ürünler

        #region Ayarlar

        #region Yetkiler combobox

        private void cbYetkiSeviyesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yetki = cbYetkiSeviyesiGuncelle.SelectedItem.ToString();
            yetki_seviyesi = ayarlar.yetki_seviye_bul(yetki);
        }

        private void cbYetkiSeviyesiEkle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yetki = cbYetkiSeviyesiEkle.SelectedItem.ToString();
            yetki_seviyesi = ayarlar.yetki_seviye_bul(yetki);
        }

        #endregion Yetkiler combobox

        #region Kullanici Guncelle / Ekle / sil

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txKullaniciAdiGuncelle.Text) && !string.IsNullOrWhiteSpace(txKullaniciSifreGuncelle.Text) && cbYetkiSeviyesiGuncelle.SelectedIndex != -1)
            {
                if (lvKullanicilar.Items.Count > 0)
                {
                    if (kullanici_id == null)// kullanici secilmemişse
                    {
                        kullanici_id = lvKullanicilar.SelectedItems[0].SubItems[0].Text;
                    }
                }

                ayarlar.kullaniciGuncelle(txKullaniciAdiGuncelle, txKullaniciSifreGuncelle, yetki_seviyesi, kullanici_id, lvKullanicilar);
            }
            else
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmayınız.");
            }
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txKullaniciAdiEkle.Text) && !string.IsNullOrWhiteSpace(txKullaniciSifreEkle.Text) && yetki_seviyesi != null)
            {
                ayarlar.kullaniciEkle(txKullaniciAdiEkle, txKullaniciSifreEkle, yetki_seviyesi, lvKullanicilar);
                txKullaniciAdiEkle.Clear();
                txKullaniciSifreEkle.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmayınız.");
            }
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txKullaniciAdiSil.Text))
            {
                ayarlar.kullaniciSil(txKullaniciAdiSil, lvKullanicilar, frmGiris.kullanici_adi);
                btnKullaniciSil.Enabled = false;
                txKullaniciAdiSil.Clear();
                kullanici_id = null;
                txKullaniciAdiEkle.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmayınız.");
            }
        }

        #endregion Kullanici Guncelle / Ekle / sil

        #region lvKullanicilar mouseclick

        private void lvKullanicilar_MouseClick(object sender, MouseEventArgs e)
        {
            kullanici_id = lvKullanicilar.SelectedItems[0].SubItems[0].Text;
            ayarlar.kullaniciGetir(txKullaniciAdiGuncelle, txKullaniciSifreGuncelle, kullanici_id);
            txKullaniciAdiSil.Text = lvKullanicilar.SelectedItems[0].SubItems[1].Text;
            cbYetkiSeviyesiGuncelle.Items.Clear();// tekrar veri girisi engellenmesi icin silinir
            ayarlar.yetkiGetir(cbYetkiSeviyesiGuncelle);
            btnKullaniciGuncelle.Enabled = true;
            btnKullaniciSil.Enabled = true;
        }

        #endregion lvKullanicilar mouseclick

        #region textbox ayarlari

        private void txFiyati2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber((char)e.KeyChar) || e.KeyChar == (char)44 || e.KeyChar == (char)46 || e.KeyChar == (char)8 || char.IsControl((char)e.KeyChar))// girilen sayi, nokta veya , ise izin verir textboxa girise 44 = , 46 = .
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 44 = , 46 = . 8 = backspace
            if (Char.IsNumber((char)e.KeyChar) || e.KeyChar == (char)44 || e.KeyChar == (char)46 || e.KeyChar == (char)8)// girilen sayi, nokta veya , ise izin verir textboxa girise
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion textbox ayarlari

        #endregion Ayarlar

        #region Ürün özellikler

        #region Ürünleri Getir

        private void btnAlkolluIcecekler2_Click(object sender, EventArgs e)
        {
            kategori_id = "8";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        private void btnSalata2_Click(object sender, EventArgs e)
        {
            kategori_id = "7";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        private void btnSogukIcecekler2_Click(object sender, EventArgs e)
        {
            kategori_id = "4";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        private void btnMakarna2_Click(object sender, EventArgs e)
        {
            kategori_id = "2";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        private void btnNargileler2_Click(object sender, EventArgs e)
        {
            kategori_id = "6";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        private void btnTatlilar2_Click(object sender, EventArgs e)
        {
            kategori_id = "3";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        private void btnSicakIcecekler2_Click(object sender, EventArgs e)
        {
            kategori_id = "5";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        private void btnAnayemek2_Click(object sender, EventArgs e)
        {
            kategori_id = "1";
            ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
        }

        #endregion Ürünleri Getir

        #region lisview mouseclick

        private void lvUrunler2_MouseClick(object sender, MouseEventArgs e)
        {
            string ozellik = null;

            try
            {
                btnOzellikEkle.Enabled = true;
                btnOzellikSil.Enabled = false;
                btnOzellikGuncelle.Enabled = false;

                if (lvUrunler2.Items.Count > 0)
                {
                    urun_adi = lvUrunler2.SelectedItems[0].SubItems[1].Text;
                    urun_id = lvUrunler2.SelectedItems[0].SubItems[0].Text;
                    ozellik = lvUrunler2.SelectedItems[0].SubItems[2].Text;
                    if (ozellik == "VAR")
                    {
                        btnOzellikSil.Enabled = true;
                        btnOzellikGuncelle.Enabled = true;
                    }
                    if (urunler.Ozellik_kontrol(urun_id) == true)
                    {
                        ayarlar.ozellikCek(lvOzellikler, urun_id);
                        txOzellikUrunSil.Text = urun_adi;
                        txOzellikUrunGuncelle.Text = urun_adi;
                    }
                    else
                    {
                        lvOzellikler.Items.Clear();
                        txGuncelleTemizle();
                    }
                    txOzellikUrunEkle.Text = lvUrunler2.SelectedItems[0].SubItems[1].Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tekrar Tıklayınız.");
            }
        }

        private void lvOzellikler_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvOzellikler.Items.Count > 0)
                {
                    txOzellikAdiSil.Text = lvOzellikler.SelectedItems[0].SubItems[0].Text;
                    txOzellikAdiGuncelle.Text = lvOzellikler.SelectedItems[0].SubItems[0].Text;
                    ozellik_id = lvOzellikler.SelectedItems[0].SubItems[1].Text;
                    btnOzellikGuncelle.Enabled = true;
                    btnOzellikSil.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tekrar Tıklayınız");

                ;
            }
        }

        #endregion lisview mouseclick

        #region Özellik Ekle / Sil

        private void btnOzellikEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txOzellikAdiEkle.Text))
            {
                ayarlar.ozellikEkle(lvUrunler2, lvOzellikler, txOzellikAdiEkle, urun_id);
                ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
                txOzellikAdiEkle.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen Özellik Adi Giriniz.. ");
            }
        }

        private void btnOzellikSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ürünün Özelliğini Silmek İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ayarlar.ozellikSil(lvUrunler2, lvOzellikler, txOzellikAdiSil, urun_id, ozellik_id);
                txGuncelleTemizle();
                ayarlar.ozellikUrunGetir(lvUrunler2, kategori_id);
            }
        }

        private void btnOzellikGuncelle_Click(object sender, EventArgs e)
        {
            ayarlar.ozellikGuncelle(lvUrunler2, lvOzellikler, txOzellikAdiGuncelle, ozellik_id, urun_id);
            txGuncelleTemizle();
            btnOzellikSil.Enabled = false;
            btnOzellikGuncelle.Enabled = false;
        }

        #endregion Özellik Ekle / Sil

        #endregion Ürün özellikler

        #region raporlar

        private void btnRaporGetir_Click(object sender, EventArgs e)
        {// satilan urunler 1 yapılan toplam satis 2
            if (rdGunluk.Checked == true || rdHepsi.Checked == true || rdAylik.Checked == true)
            {
                if (rapor_cinsi != null)
                {
                    ay = genel.aySec(cbAylar);
                    yil = genel.yilSec(cbYillar);
                    gun = genel.gunSec(cbGunler);
                    if (rdGunluk.Checked == true) //radiobutton kontrol
                    {
                        cbTarihGoster();
                        if (rapor_cinsi == "1") // toplam hesap
                        {
                            ayarlar.toplamUrunGunluk(lvSatilanUrunler, ay, gun, yil);
                        }
                        else if (rapor_cinsi == "2") // satilan urunler
                        {
                            ayarlar.toplamSatisGunluk(lvToplamSatislar, ay, gun, yil);
                            sonuc = ayarlar.toplamBul(lvToplamSatislar);
                            toplamGoster(sonuc);
                        }
                    }
                    else if (rdHepsi.Checked == true)
                    {
                        cbTarihGizle();
                        if (rapor_cinsi == "1") // toplam hesap
                        {
                            ayarlar.toplamUrunHepsi(lvSatilanUrunler);
                        }
                        else if (rapor_cinsi == "2") // satilan urunler
                        {
                            ayarlar.toplamSatisHepsi(lvToplamSatislar);
                            sonuc = ayarlar.toplamBul(lvToplamSatislar);
                            toplamGoster(sonuc);
                        }
                    }
                    else if (rdAylik.Checked == true)
                    {
                        cbTarihGizle();
                        cbYillar.Visible = true;
                        cbAylar.Visible = true;
                        if (rapor_cinsi == "1") // toplam hesap
                        {
                            ayarlar.toplamUrunAylik(lvSatilanUrunler, ay, yil);
                        }
                        else if (rapor_cinsi == "2") // satilan urunler
                        {
                            ayarlar.toplamSatisAylik(lvToplamSatislar, ay, yil);
                            sonuc = ayarlar.toplamBul(lvToplamSatislar);
                            toplamGoster(sonuc);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Rapor Çeşidi Seçiniz.");
            }
        }

        private void cbRaporCinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            rapor_cinsi = cbRaporCinsi.SelectedItem.ToString();
            rapor_cinsi = rapor_cinsi.Substring(0, 3); // ilk 3 harf
            // lv top satis
            if (rapor_cinsi == "SAT")// satilan urunler 1 toplam yapılan satıs 2
            {
                lvSatilanUrunler.Visible = true;
                lvToplamSatislar.Visible = false;
                toplamGizle();
                rapor_cinsi = "1";
            }
            else
            {
                lvSatilanUrunler.Visible = false;
                lvToplamSatislar.Visible = true;
                toplamGoster();
                rapor_cinsi = "2";
            }
            raporlarTemizle();
        }

        private void cbAylar_MouseClick(object sender, MouseEventArgs e)
        {
            cbAylar.Visible = false;
        }

        private void rdAylik_MouseClick(object sender, MouseEventArgs e)
        {
            cbAylikGoster();
            ay = genel.aySec(cbAylar);
            yil = genel.yilSec(cbYillar);
        }

        private void cbYillar_SelectedIndexChanged(object sender, EventArgs e)
        {
            yil = genel.yilSec(cbYillar);
        }

        private void cbAylar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ay = genel.aySec(cbAylar);
        }

        private void cbGunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            gun = genel.gunSec(cbGunler);
        }

        private void rdAylik_CheckedChanged(object sender, EventArgs e)
        {
            cbAylar.Visible = false;
            cbGunler.Visible = false;
        }

        private void rdGunluk_MouseClick(object sender, MouseEventArgs e)
        {
            cbTarihGoster();
            ay = genel.aySec(cbAylar);
            yil = genel.yilSec(cbYillar);
            gun = genel.gunSec(cbGunler);
        }

        private void rdHepsi_MouseClick(object sender, MouseEventArgs e)
        {
            cbTarihGizle();
        }

        #endregion raporlar

        #region personel hareketleri

        private void btnPersonelRapor_Click(object sender, EventArgs e)
        {
            if (rdPersonelAylik.Checked == true || rdPersonelGunluk.Checked == true || rdPersonelHepsi.Checked == true && cbPersonel.SelectedIndex > -1)
            {
                if (rdPersonelGunluk.Checked == true) // gunluk secildigi zaman
                {
                    if (rapor_cinsi == "MAS") // aktarmalar
                    {
                        ayarlar.masaAktarmaGunluk(lvPersonelMasa, ay, gun, yil);
                    }
                    else // iadeler
                    {
                        ayarlar.iadeGunluk(lvPersonel_iade, ay, gun, yil);
                    }
                }
                else if (rdPersonelAylik.Checked == true) // aylik secildigi zaman
                {
                    if (rapor_cinsi == "MAS") // aktarmalar
                    {
                        ayarlar.masaAktarmaAylik(lvPersonelMasa, ay, yil);
                    }
                    else // iadeler
                    {
                        ayarlar.iadeAylik(lvPersonel_iade, ay, yil);
                    }
                }
                else if (rdPersonelHepsi.Checked == true) // hepsi secildigi zaman
                {
                    if (rapor_cinsi == "MAS") // aktarmalar
                    {
                        ayarlar.masaAktarmaHepsi(lvPersonelMasa);
                    }
                    else // iadeler
                    {
                        ayarlar.iadeHepsi(lvPersonel_iade);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Hareket Çeşidi Seçiniz.");
            }
        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            rapor_cinsi = cbPersonel.SelectedItem.ToString();
            rapor_cinsi = rapor_cinsi.Substring(0, 3); // ilk 3 harf
            raporlarTemizle();
            if (rapor_cinsi == "MAS") // masa aktarma seçilince
            {
                lvPersonelMasa.Visible = true;
                lvPersonel_iade.Visible = false;
            }
            else
            {
                toplamGoster();
                lvPersonelMasa.Visible = false;
                lvPersonel_iade.Visible = true;
            }
        }

        private void cbPersonelAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ay = genel.aySec(cbPersonelAy);
        }

        private void cbPersonelGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            gun = genel.gunSec(cbPersonelGun);
        }

        private void cbPersonelYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            yil = genel.yilSec(cbPersonelYil);
        }

        private void rdPersonelGunluk_Click(object sender, EventArgs e)
        {
            cbTarihGoster();
            ay = genel.aySec(cbPersonelAy);
            yil = genel.yilSec(cbPersonelYil);
            gun = genel.gunSec(cbPersonelGun);
        }

        private void rdPersonelAylik_Click(object sender, EventArgs e)
        {
            cbAylikGoster();
            ay = genel.aySec(cbPersonelAy);
            yil = genel.yilSec(cbPersonelYil);
            gun = genel.gunSec(cbPersonelGun);
        }

        private void rdPersonelHepsi_Click(object sender, EventArgs e)
        {
            cbTarihGizle();
        }

        private void rdPersonelAylik_CheckedChanged(object sender, EventArgs e)
        {
            cbPersonelGun.Visible = false;
        }

        private void rdPersonelHepsi_CheckedChanged(object sender, EventArgs e)
        {
            cbTarihGizle();
        }

        #endregion personel hareketleri
    }
}