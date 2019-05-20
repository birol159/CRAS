using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CRAS
{
    internal class cAyarlar
    {
        #region Properties

        private cGenel genel = new cGenel();
        private cSiparisler siparisler = new cSiparisler();
        private cUrunler urunler = new cUrunler();
        public string[] aylar = new string[13];

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public object Index { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public string[] aylari_yaz(string[] ay)
        {
            ay[1] = "Ocak";
            ay[2] = "Şubat";
            ay[3] = "Mart";
            ay[4] = "Nisan";
            ay[5] = "Mayıs";
            ay[6] = "Haziran";
            ay[7] = "Temmuz";
            ay[8] = "Ağustos";
            ay[9] = "Eylül";
            ay[10] = "Ekim";
            ay[11] = "Kasım";
            ay[12] = "Aralık";
            return ay;
        }

        #endregion Properties

        #region Urunler

        public string kategori_id_bul(string kat_adi)// kategori id bulunur
        {
            string kat_id = "";
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "select * from kategoriler where kategori_ad='" + kat_adi + "'";
            genel.sqlgonder.Parameters.AddWithValue("@ad", kat_adi);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                genel.sqlgonder.Parameters.Clear();
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        kat_id = oku["kategori_id"].ToString();
                    }
                }
            }
            genel.baglanti_kapat();
            return kat_id;
        }

        public void urunleriGetir(ListView lvMenu, string kategori_id)
        {
            genel.baglanti_ac();
            string aktif = "1";
            MySqlCommand sqlgonder = new MySqlCommand();
            sqlgonder.Connection = genel.baglanti;
            sqlgonder.CommandText = "SELECT urunler.urun_id,urunler.urun_adi,urunler.urun_fiyat,urunler.kategori_id,urunler.urun_aktif from urunler left join kategoriler on 'urunler.kategori_id'='kategoriler.kategori_id'";
            using (MySqlDataReader oku = sqlgonder.ExecuteReader())
            {
                lvMenu.Items.Clear();
                while (oku.Read())
                {
                    if (kategori_id == oku["kategori_id"].ToString() && aktif == oku["urun_aktif"].ToString())
                    {
                        ListViewItem item = new ListViewItem(oku["urun_id"].ToString());
                        item.SubItems.Add(oku["urun_adi"].ToString());
                        item.SubItems.Add(oku["urun_fiyat"].ToString());
                        item.SubItems.Add(oku["kategori_id"].ToString());
                        lvMenu.Items.Add(item);
                    }
                }
            }
            genel.baglanti_kapat();
        }

        public void kategoriGetir(ComboBox cbKategoriler)// kategoriler combobox a getirilir
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "select * from kategoriler";
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = oku["kategori_ad"].ToString();
                        item.Index = oku["kategori_id"].ToString();
                        cbKategoriler.Items.Add(item);
                    }
                }
            }
            genel.baglanti_kapat();
        }

        public bool urun_kontrol(string urun_adi)//Urun daha once eklenmismi kontrol eder
        {
            genel.baglanti_ac();
            bool kontrol = false;
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select urun_adi from urunler where urun_adi=@urun_adi";
            genel.sqlgonder.Parameters.AddWithValue("@urun_adi", urun_adi);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                if (oku.HasRows)
                {
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();

            return kontrol;
        }

        public void urunEkle(ListView lvUrunler, TextBox txAdi, TextBox txFiyati, string kategori_id)//yeni urun eklenir
        {
            string urun_adi = txAdi.Text;
            string urun_fiyat = txFiyati.Text;
            urun_fiyat = urun_fiyat.Replace(",", ".");
            bool kontrol = urun_kontrol(urun_adi);
            if (kontrol == true)
            {
                MessageBox.Show("Eklemek istediğiniz ürün zaten mevcuttur.");
            }
            else
            {
                genel.baglanti_ac();
                genel.sqlgonder.Connection = genel.baglanti;
                genel.sqlgonder.CommandText = "insert into urunler (urun_adi,urun_fiyat,kategori_id)values (@urun_adi,@urun_fiyat,@kat_id)";
                genel.sqlgonder.Parameters.Clear();
                genel.sqlgonder.Parameters.AddWithValue("@urun_adi", urun_adi);
                genel.sqlgonder.Parameters.AddWithValue("@urun_fiyat", urun_fiyat);
                genel.sqlgonder.Parameters.AddWithValue("@kat_id", kategori_id);
                genel.sqlgonder.ExecuteNonQuery();
                genel.sqlgonder.Parameters.Clear();
                genel.baglanti_kapat();
                urunleriGetir(lvUrunler, kategori_id);
                MessageBox.Show(urun_adi + " isimli ürün başarıyla eklenmiştir.");
            }
        }

        public void urunGuncelle(ListView lvUrunler, TextBox txAdi, decimal fiyat, string urun_id, string kategori_id)//ekli olan urun guncellenir
        {
            genel.baglanti_ac();
            string urun_adi = txAdi.Text;
            decimal urun_fiyati = fiyat;
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "UPDATE urunler SET urun_adi =@urun_adi,urun_fiyat =@urun_fiyati WHERE urun_id=@urun_id";
            genel.sqlgonder.Parameters.Clear();
            genel.sqlgonder.Parameters.AddWithValue("@urun_adi", urun_adi);
            genel.sqlgonder.Parameters.AddWithValue("@urun_fiyati", urun_fiyati);
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            MessageBox.Show("Ürün başarıyla güncellenmiştir.");
            urunleriGetir(lvUrunler, kategori_id);

            genel.baglanti_kapat();
        }

        public void urunSil(ListView lvUrunler, TextBox txAdiSil, string kategori_id, string urun_id)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            //DELETE FROM `urunler` WHERE `urunler`.`urun_id` = 39
            genel.sqlgonder.CommandText = "UPDATE urunler set urun_aktif=0  where urun_id=@urun_id";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            urunleriGetir(lvUrunler, kategori_id);
            MessageBox.Show("Ürün başarıyla silinmiştir.");
            genel.baglanti_kapat();
        }

        public void urunGetir(TextBox txAdi, TextBox txFiyati, TextBox txAdiSil, string urun_id)//urunler textbox a gonderilir
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select * from urunler where urun_id = " + urun_id;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                while (oku.Read())
                {
                    txAdi.Text = oku["urun_adi"].ToString();
                    txFiyati.Text = oku["urun_fiyat"].ToString();
                }
            }
            genel.baglanti_kapat();
        }

        #endregion Urunler

        #region Ayarlar

        public void kullanicilariGetir(ListView lvUsers) // kullanicilar listview a getirilir
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select kullanici.kullanici_id,kullanici.kullanici_adi,kullanici.kullanici_sifre,kullanici.yetki_id,yetkiler.yetki_seviyesi,yetkiler.yetki_adi,kullanici.kullanici_aktif FROM kullanici LEFT JOIN yetkiler on kullanici.yetki_id=yetkiler.yetki_id where kullanici.kullanici_aktif=1 ";
            lvUsers.Items.Clear();
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku[0].ToString());
                    item.SubItems.Add(oku[1].ToString());
                    item.SubItems.Add(oku[4].ToString());
                    item.SubItems.Add(oku[2].ToString());
                    item.SubItems.Add(oku[3].ToString());
                    item.SubItems.Add(oku[5].ToString());
                    lvUsers.Items.Add(item);
                }
            }

            genel.baglanti_kapat();
        }

        public void kullaniciGetir(TextBox txAdi, TextBox txSifre, string kullanici_id) // kullanicilar textbox a gonderilir
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select * from kullanici  where kullanici_id = " + kullanici_id;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                while (oku.Read())
                {
                    txAdi.Text = oku["kullanici_adi"].ToString();
                    txSifre.Text = oku["kullanici_sifre"].ToString();
                }
            }
            genel.baglanti_kapat();
        }

        public void yetkiGetir(ComboBox cbYetkiler) // yetkiler combobox a getirilir
        {
            genel.baglanti_ac();
            cbYetkiler.Items.Clear();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "select * from yetkiler";
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = oku["yetki_adi"].ToString();
                        cbYetkiler.Items.Add(item);
                    }
                }
            }
            genel.baglanti_kapat();
        }

        public string yetki_seviye_bul(string yetki_adi) // yetki seviyesi ID'si bulunur
        {
            string yetki_seviye = null;
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;

            genel.sqlgonder.CommandText = "select * from yetkiler where yetki_adi='" + yetki_adi + "'";
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                while (oku.Read())
                {
                    yetki_seviye = oku["yetki_id"].ToString();
                }
            }

            genel.baglanti_kapat();

            return yetki_seviye;
        }

        public void kullaniciGuncelle(TextBox txAdi, TextBox txSifre, string yetki_id, string kullanici_id, ListView lvKullanicilar)
        {
            genel.baglanti_ac();
            string kullanici_adi = txAdi.Text;
            string kullanici_sifre = txSifre.Text;
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "UPDATE kullanici SET kullanici_adi='" + kullanici_adi + "',kullanici_sifre='" + kullanici_sifre + "' , yetki_id=@yetki WHERE kullanici_id=@kullanici_id";
            genel.sqlgonder.Parameters.AddWithValue("@yetki", yetki_id);
            genel.sqlgonder.Parameters.AddWithValue("@kullanici_id", kullanici_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            MessageBox.Show("Kullanici başarıyla güncellenmiştir.");
            kullanicilariGetir(lvKullanicilar);

            genel.baglanti_kapat();
        }

        public bool kullanici_kontrol(string kullanici_adi)
        {
            bool kontrol = false;
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select kullanici_adi from kullanici where kullanici_adi=@k_adi";
            genel.sqlgonder.Parameters.AddWithValue("@k_adi", kullanici_adi);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                if (oku.HasRows)
                {
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
            return kontrol;
        }

        public void kullaniciEkle(TextBox txKullaniciAdiEkle, TextBox txKullaniciSifreEkle, string yetki_id, ListView lvKullanicilar)
        {
            string kullanici_adi = txKullaniciAdiEkle.Text;
            string kullanici_sifre = txKullaniciSifreEkle.Text;
            if (kullanici_kontrol(kullanici_adi) == true)// ayni kullanici adi kontrolu
            {
                MessageBox.Show("Aynı Kullanıcı Adı İle Kayıtlı Kullanıcı Mevcuttur.");
            }
            else
            {
                genel.baglanti_ac();
                genel.sqlgonder.Connection = genel.baglanti;
                genel.sqlgonder.CommandText = "insert into kullanici (kullanici_adi,kullanici_sifre,yetki_id) VALUES (@k_adi,@k_sifre,@yetki_id)";
                genel.sqlgonder.Parameters.AddWithValue("@k_adi", kullanici_adi);
                genel.sqlgonder.Parameters.AddWithValue("@k_sifre", kullanici_sifre);
                genel.sqlgonder.Parameters.AddWithValue("@yetki_id", yetki_id);
                genel.sqlgonder.ExecuteNonQuery();
                genel.sqlgonder.Parameters.Clear();
                MessageBox.Show("Kullanıcı Başarıyla Eklenmiştir");
                kullanicilariGetir(lvKullanicilar);
            }
            genel.baglanti_kapat();
        }

        public void kullaniciSil(TextBox txKullaniciAdiSil, ListView lvKullanicilar, string giris_kullanicisi)
        {
            genel.baglanti_ac();
            if (giris_kullanicisi != frmGiris.kullanici_adi) // giris yapilan kullanici kontrolu yapilir
            {
                string kullanici_adi = txKullaniciAdiSil.Text;
                genel.sqlgonder.Connection = genel.baglanti;
                genel.sqlgonder.CommandText = "UPDATE kullanici set kullanici_aktif=0 where kullanici_adi=@k_adi";
                genel.sqlgonder.Parameters.AddWithValue("@k_adi", kullanici_adi);
                genel.sqlgonder.ExecuteNonQuery();
                genel.sqlgonder.Parameters.Clear();
                MessageBox.Show("Kullanıcı Başarıyla Silinmiştir");
                kullanicilariGetir(lvKullanicilar);
            }
            else
            {
                MessageBox.Show("Giriş Yapılan Kullanıcı Silinemez");
            }

            genel.baglanti_kapat();
        }

        #endregion Ayarlar

        #region Özellikler

        #region Ürünleri Getir

        public void ozellikUrunGetir(ListView lvMenu, string kategori_id)
        {
            genel.baglanti_ac();
            MySqlCommand sqlgonder = new MySqlCommand();
            sqlgonder.Connection = genel.baglanti;
            sqlgonder.CommandText = "SELECT urunler.urun_id,urunler.urun_adi,urunler.urun_ozellik,urunler.urun_fiyat,urunler.kategori_id , urunler.urun_aktif from urunler left join kategoriler on 'urunler.kategori_id'='kategoriler.kategori_id'";
            using (MySqlDataReader oku = sqlgonder.ExecuteReader())
            {
                lvMenu.Items.Clear();
                while (oku.Read())
                {
                    if (kategori_id == oku["kategori_id"].ToString() && oku["urun_aktif"].ToString() == "1")
                    {
                        ListViewItem item = new ListViewItem(oku["urun_id"].ToString());
                        item.SubItems.Add(oku["urun_adi"].ToString());
                        bool ozellik = (bool)oku["urun_ozellik"];
                        if (ozellik == true)
                        {
                            item.SubItems.Add("VAR");
                        }
                        else
                        {
                            item.SubItems.Add("YOK");
                        }
                        lvMenu.Items.Add(item);
                    }
                }
            }
            genel.baglanti_kapat();
        }

        #endregion Ürünleri Getir

        #region ozellik kontrol / getir

        public void ozellikCek(ListView lvOzellik, string urun_id)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select * from ozellikler where urun_id=@urun_id";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvOzellik.Items.Clear();
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["ozellik_adi"].ToString());
                    item.SubItems.Add(oku["ozellik_id"].ToString());
                    item.SubItems.Add(oku["urun_id"].ToString());
                    lvOzellik.Items.Add(item);
                }
                genel.sqlgonder.Parameters.Clear();
                genel.baglanti_kapat();
            }
        }

        public bool ozellik_kontrol(string ozellik_adi, string urun_id)//özellik adi varmi kontrol eder
        {
            genel.baglanti_ac();
            bool kontrol = false;
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select * from ozellikler where ozellik_adi=@ozellik_adi and urun_id=@urun_id";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.Parameters.AddWithValue("@ozellik_adi", ozellik_adi);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                if (oku.HasRows)
                {
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();

            return kontrol;
        }

        public bool ozellik_kontrol(string urun_id) // özellik varmi kontrol eder
        {
            genel.baglanti_ac();
            Boolean deger = false;
            genel.sqlgonder.CommandText = "Select * from ozellikler where urun_id = @urun_id";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.Connection = genel.baglanti;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                if (oku.HasRows)
                {
                    deger = true;
                }
                genel.sqlgonder.Parameters.Clear();
                genel.baglanti_kapat();
                return deger;
            }
        }

        #endregion ozellik kontrol / getir

        #region Özellik Ekle / Güncelle / Sil

        public void ozellikEkle(ListView lvUrunler, ListView lvOzellikler, TextBox txAdiEkle, string urun_id)//yeni ozellik eklenir
        {
            string ozellik_adi = txAdiEkle.Text;
            bool kontrol = ozellik_kontrol(ozellik_adi, urun_id);
            if (kontrol == true)
            {
                MessageBox.Show("Eklemek istediğiniz özellik zaten mevcuttur.");
            }
            else
            {
                genel.baglanti_ac();
                genel.sqlgonder.Connection = genel.baglanti;
                if (urunler.Ozellik_kontrol(urun_id) == false)
                {
                    genel.sqlgonder.CommandText = "UPDATE urunler SET urun_ozellik=1 WHERE urun_id=@urun_id";
                    genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                    genel.sqlgonder.ExecuteNonQuery();
                    genel.sqlgonder.Parameters.Clear();
                }
                genel.sqlgonder.CommandText = "insert into ozellikler (ozellik_adi,urun_id)values (@ozellik_adi,@urun_id)";
                genel.sqlgonder.Parameters.AddWithValue("@ozellik_adi", ozellik_adi);
                genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                genel.sqlgonder.ExecuteNonQuery();
                genel.sqlgonder.Parameters.Clear();
                genel.baglanti_kapat();
                ozellikCek(lvOzellikler, urun_id);
                MessageBox.Show("Özellik Başarıyla Eklenmiştir.");
            }
        }

        public void ozellikGuncelle(ListView lvUrunler, ListView lvOzellikler, TextBox txAdiGuncelle, string ozellik_id, string urun_id)//ekli olan ozellik guncellenir
        {
            genel.baglanti_ac();
            string ozellik_adi = txAdiGuncelle.Text;
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "UPDATE ozellikler SET ozellik_adi=@ozellik_adi WHERE ozellik_id=@ozellik_id";
            genel.sqlgonder.Parameters.AddWithValue("@ozellik_adi", ozellik_adi);
            genel.sqlgonder.Parameters.AddWithValue("@ozellik_id", ozellik_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            MessageBox.Show("Ürün başarıyla güncellenmiştir.");
            ozellikCek(lvOzellikler, urun_id);
            genel.baglanti_kapat();
        }

        public void urun_ozellik_kapat(string urun_id)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "UPDATE urunler SET urun_ozellik=0 WHERE urun_id=@urun_id";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void ozellikSil(ListView lvUrunler, ListView lvOzellik, TextBox txAdiSil, string urun_id, string ozellik_id)
        {
            genel.baglanti_ac();
            string ozellik_adi = txAdiSil.Text;
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "delete from ozellikler where ozellik_id=@ozellik_id";
            genel.sqlgonder.Parameters.AddWithValue("@ozellik_id", ozellik_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            if (ozellik_kontrol(urun_id) == true)
            {
                ozellikCek(lvOzellik, urun_id);
            }
            else
            {
                urun_ozellik_kapat(urun_id);
            }
            MessageBox.Show("Özellik başarıyla silinmiştir.");
            genel.baglanti_kapat();
        }

        #endregion Özellik Ekle / Güncelle / Sil

        #endregion Özellikler

        #region raporlar

        public string gun_duzeltme(string gun)
        {
            if (gun == "1" || gun == "2" || gun == "3" || gun == "4" || gun == "5" || gun == "6" || gun == "7" || gun == "8" || gun == "9")
            {
                gun = "0" + gun;
            }

            return gun;
        }

        public decimal[] toplamBul(ListView lvTop)
        {// 0 tarih 1 satış 2 odeme turu
            string odeme_turu = null;
            decimal[] sonuc = new decimal[4];
            decimal k_top = 0, n_top = 0, t_top = 0, fiyat = 0;
            if (lvTop.Items.Count > 0)
            {
                for (int i = 0; i < lvTop.Items.Count; i++)
                {
                    odeme_turu = lvTop.Items[i].SubItems[2].Text;
                    fiyat = Convert.ToDecimal(lvTop.Items[i].SubItems[1].Text);
                    if (odeme_turu == "Kredi Kartı") k_top += fiyat;
                    if (odeme_turu == "Nakit") n_top += fiyat;
                    if (odeme_turu == "Ticket") t_top += fiyat;
                }
                sonuc[0] = k_top;
                sonuc[1] = n_top;
                sonuc[2] = t_top;
                sonuc[3] = k_top + n_top + t_top;
            }
            return sonuc;
        }

        public void toplamUrunGunluk(ListView lvSat, string ay, string gun, string yil)
        {
            string tarih = tarih = yil + "-" + ay + "-" + gun;
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT raporlar.rapor_tarih,urunler.urun_adi,raporlar.rapor_urun_adet FROM raporlar" +
                " LEFT JOIN urunler ON raporlar.rapor_urun_id = urunler.urun_id where rapor_tarih=@tarih ORDER BY raporlar.rapor_id  DESC";
            genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvSat.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    string tarih2 = oku[0].ToString();
                    string urun_adi = oku[1].ToString();
                    string urun_adet = oku[2].ToString();
                    tarih2 = tarih2.Substring(0, 10);
                    ListViewItem item = new ListViewItem(tarih2);
                    item.SubItems.Add(urun_adi);
                    item.SubItems.Add(urun_adet);
                    lvSat.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void toplamSatisGunluk(ListView lvTop, string ay, string gun, string yil)
        {
            gun = gun_duzeltme(gun);
            string tarih = yil + "-" + ay + "-" + gun;
            string tarih_2 = tarih;
            tarih = tarih + " 00:00:00";
            tarih_2 = tarih_2 + " 23:59:59";
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT satis_toplam_fiyat,satis_tarih,satis_odeme_turu FROM satislar where satis_tarih BETWEEN @tarih1 AND @tarih2 ORDER BY satis_tarih  DESC";
            genel.sqlgonder.Parameters.AddWithValue("@tarih1", tarih);
            genel.sqlgonder.Parameters.AddWithValue("@tarih2", tarih_2);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvTop.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    string odeme = oku["satis_odeme_turu"].ToString();
                    string tarih2 = oku["satis_tarih"].ToString();
                    ListViewItem item = new ListViewItem(tarih2);
                    item.SubItems.Add(oku["satis_toplam_fiyat"].ToString());
                    if (odeme == "1") item.SubItems.Add("Kredi Kartı");
                    if (odeme == "2") item.SubItems.Add("Nakit");
                    if (odeme == "3") item.SubItems.Add("Ticket");
                    lvTop.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void toplamUrunAylik(ListView lvSat, string ay, string yil)
        {
            aylari_yaz(aylar);
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT aylik_raporlar.rapor_ayi,aylik_raporlar.rapor_yili,aylik_raporlar.rapor_urun_id,aylik_raporlar.rapor_urun_adet" +
                ",urunler.urun_adi FROM aylik_raporlar LEFT JOIN urunler ON aylik_raporlar.rapor_urun_id = urunler.urun_id where aylik_raporlar.rapor_ayi=@rapor_ayi and aylik_raporlar.rapor_yili=@rapor_yil ORDER BY aylik_raporlar.rapor_id  DESC ";
            genel.sqlgonder.Parameters.AddWithValue("@rapor_ayi", ay);
            genel.sqlgonder.Parameters.AddWithValue("@rapor_yil", yil);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                int deger = Convert.ToInt32(ay);
                lvSat.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    string urun_adi = oku[4].ToString(), urun_adet = oku[3].ToString();

                    ListViewItem item = new ListViewItem(aylar[Convert.ToInt32(ay)] + " " + yil);
                    item.SubItems.Add(urun_adi);
                    item.SubItems.Add(urun_adet);
                    lvSat.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void toplamSatisAylik(ListView lvTop, string ay, string yil)
        {
            aylari_yaz(aylar);
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT satis_toplam_fiyat,satis_tarih,satis_odeme_turu FROM satislar where satis_tarih between @baslangic and @bitis ORDER BY satis_tarih  DESC";
            string tarih = yil + "-" + ay + "-01";
            genel.sqlgonder.Parameters.AddWithValue("@baslangic", tarih);
            tarih = yil + "-" + ay + "-31";
            genel.sqlgonder.Parameters.AddWithValue("@bitis", tarih);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                int deger = Convert.ToInt32(ay);
                lvTop.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    string odeme = oku["satis_odeme_turu"].ToString();
                    string tarih2 = oku["satis_tarih"].ToString();
                    tarih2 = tarih2.Substring(0, 10);
                    ListViewItem item = new ListViewItem(aylar[deger] + " " + yil);
                    item.SubItems.Add(oku["satis_toplam_fiyat"].ToString());
                    if (odeme == "1") item.SubItems.Add("Kredi Kartı");
                    if (odeme == "2") item.SubItems.Add("Nakit");
                    if (odeme == "3") item.SubItems.Add("Ticket");
                    lvTop.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void toplamUrunHepsi(ListView lvSat)
        {
            genel.baglanti_ac();
            aylari_yaz(aylar);
            string ay = null, yil = null;
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT aylik_raporlar.rapor_ayi,aylik_raporlar.rapor_yili,aylik_raporlar.rapor_urun_id,aylik_raporlar.rapor_urun_adet" +
                ",urunler.urun_adi FROM aylik_raporlar LEFT JOIN urunler ON aylik_raporlar.rapor_urun_id = urunler.urun_id ORDER BY aylik_raporlar.rapor_id  DESC ";
            //ay = tarih.Substring(5, 2));
            //yil = tarih.Substring(0, 4));
            aylari_yaz(aylar);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvSat.Items.Clear();
                while (oku.Read())
                {
                    ay = oku["rapor_ayi"].ToString();
                    yil = oku["rapor_yili"].ToString();
                    int deger = Convert.ToInt32(ay);
                    string urun_adi = oku[4].ToString(), urun_adet = oku[3].ToString();

                    ListViewItem item = new ListViewItem(aylar[Convert.ToInt32(ay)] + " " + yil);
                    item.SubItems.Add(urun_adi);
                    item.SubItems.Add(urun_adet);
                    lvSat.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void toplamSatisHepsi(ListView lvTop)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT satis_toplam_fiyat,satis_tarih,satis_odeme_turu FROM satislar ORDER BY satis_tarih DESC ";
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvTop.Items.Clear();
                while (oku.Read())
                {
                    string odeme = oku["satis_odeme_turu"].ToString();
                    string tarih2 = oku["satis_tarih"].ToString();
                    tarih2 = tarih2.Substring(0, 10);
                    ListViewItem item = new ListViewItem(oku["satis_tarih"].ToString());
                    item.SubItems.Add(oku["satis_toplam_fiyat"].ToString());
                    if (odeme == "1") item.SubItems.Add("Kredi Kartı");
                    if (odeme == "2") item.SubItems.Add("Nakit");
                    if (odeme == "3") item.SubItems.Add("Ticket");
                    lvTop.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        #endregion raporlar

        #region personel hareketleri

        public void masaAktarmaGunluk(ListView lvMasa, string ay, string gun, string yil)
        {
            gun = gun_duzeltme(gun);
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            string tarih = yil + "-" + ay + "-" + gun;
            string tarih_2 = tarih;
            tarih = tarih + " 00.00.00";
            tarih_2 = tarih_2 + " 23.59.59";
            genel.sqlgonder.CommandText = "SELECT aktarmalar.aktarma_masa_id,aktarmalar.aktarma_aktarilan_masa_id ,aktarmalar.aktarma_personel_id,aktarmalar.aktarma_tarihi,kullanici.kullanici_id,kullanici.kullanici_adi,masalar.masa_id,masalar.masa_adi " +
                "FROM aktarmalar " +
                "LEFT JOIN masalar  " +
                " on masalar.masa_id = aktarmalar.aktarma_aktarilan_masa_id " +
                "LEFT JOIN kullanici  " +
                "on kullanici.kullanici_id = aktarmalar.aktarma_personel_id " +
                "where aktarmalar.aktarma_tarihi BETWEEN @tarih1 AND @tarih2";
            genel.sqlgonder.Parameters.AddWithValue("@tarih1", tarih);
            genel.sqlgonder.Parameters.AddWithValue("@tarih2", tarih_2);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvMasa.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    //tarih = oku["aktarma_tarihi"].ToString();
                    ListViewItem item = new ListViewItem(oku["aktarma_tarihi"].ToString());
                    item.SubItems.Add(oku["aktarma_masa_id"].ToString());
                    item.SubItems.Add(oku["masa_adi"].ToString());
                    item.SubItems.Add(oku["kullanici_adi"].ToString());
                    lvMasa.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void iadeGunluk(ListView lvIade, string ay, string gun, string yil)
        {
            gun = gun_duzeltme(gun);
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            string tarih = yil + "-" + ay + "-" + gun;
            string tarih_2 = tarih;
            tarih = tarih + " 00.00.00";
            tarih_2 = tarih_2 + " 23.59.59";
            genel.sqlgonder.CommandText = "SELECT i.iade_tarih,u.urun_adi,m.masa_adi,k.kullanici_adi  FROM iadeler as i " +
                "LEFT JOIN masalar as m ON m.masa_id = i.iade_masa_id LEFT JOIN kullanici as k ON k.kullanici_id = i.iade_personel_id " +
                "LEFT JOIN urunler as u ON i.iade_urun_id = u.urun_id where i.iade_tarih BETWEEN @tarih1 AND @tarih2";
            genel.sqlgonder.Parameters.AddWithValue("@tarih1", tarih);
            genel.sqlgonder.Parameters.AddWithValue("@tarih2", tarih_2);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvIade.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["iade_tarih"].ToString());
                    item.SubItems.Add(oku["urun_adi"].ToString());
                    item.SubItems.Add(oku["masa_adi"].ToString());
                    item.SubItems.Add(oku["kullanici_adi"].ToString());
                    lvIade.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void masaAktarmaAylik(ListView lvMasa, string ay, string yil)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            string tarih = yil + "-" + ay + "-01";
            int ay2 = Convert.ToInt32(ay); ay2++;
            ay = gun_duzeltme(ay2.ToString());
            string tarih_2 = yil + "-" + ay + "-31";
            tarih = tarih + " 00.00.00";
            tarih_2 = tarih_2 + " 23.59.59";
            genel.sqlgonder.CommandText = "SELECT aktarmalar.aktarma_masa_id,aktarmalar.aktarma_aktarilan_masa_id ,aktarmalar.aktarma_personel_id,aktarmalar.aktarma_tarihi,kullanici.kullanici_id,kullanici.kullanici_adi,masalar.masa_id,masalar.masa_adi " +
                "FROM aktarmalar " +
                "LEFT JOIN masalar  " +
                " on masalar.masa_id = aktarmalar.aktarma_aktarilan_masa_id " +
                "LEFT JOIN kullanici  " +
                "on kullanici.kullanici_id = aktarmalar.aktarma_personel_id " +
                "where aktarmalar.aktarma_tarihi BETWEEN @tarih1 AND @tarih2";
            genel.sqlgonder.Parameters.AddWithValue("@tarih1", tarih);
            genel.sqlgonder.Parameters.AddWithValue("@tarih2", tarih_2);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvMasa.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["aktarma_tarihi"].ToString());
                    item.SubItems.Add(oku["aktarma_masa_id"].ToString());
                    item.SubItems.Add(oku["masa_adi"].ToString());
                    item.SubItems.Add(oku["kullanici_adi"].ToString());
                    lvMasa.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void iadeAylik(ListView lvIade, string ay, string yil)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            string tarih = yil + "-" + ay + "-01";
            int ay2 = Convert.ToInt32(ay); ay2++;
            ay = gun_duzeltme(ay2.ToString());
            string tarih_2 = yil + "-" + ay + "-31";
            tarih = tarih + " 00.00.00";
            tarih_2 = tarih_2 + " 23.59.59";
            genel.sqlgonder.CommandText = "SELECT i.iade_tarih,u.urun_adi,m.masa_adi,k.kullanici_adi  FROM iadeler as i " +
                "LEFT JOIN masalar as m ON m.masa_id = i.iade_masa_id LEFT JOIN kullanici as k ON k.kullanici_id = i.iade_personel_id " +
                "LEFT JOIN urunler as u ON i.iade_urun_id = u.urun_id where i.iade_tarih BETWEEN @tarih1 AND @tarih2";
            genel.sqlgonder.Parameters.AddWithValue("@tarih1", tarih);
            genel.sqlgonder.Parameters.AddWithValue("@tarih2", tarih_2);
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvIade.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["iade_tarih"].ToString());
                    item.SubItems.Add(oku["urun_adi"].ToString());
                    item.SubItems.Add(oku["masa_adi"].ToString());
                    item.SubItems.Add(oku["kullanici_adi"].ToString());
                    lvIade.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void masaAktarmaHepsi(ListView lvMasa)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT aktarmalar.aktarma_masa_id,aktarmalar.aktarma_aktarilan_masa_id ,aktarmalar.aktarma_personel_id,aktarmalar.aktarma_tarihi,kullanici.kullanici_id,kullanici.kullanici_adi,masalar.masa_id,masalar.masa_adi " +
                "FROM aktarmalar " +
                "LEFT JOIN masalar  " +
                " on masalar.masa_id = aktarmalar.aktarma_aktarilan_masa_id " +
                "LEFT JOIN kullanici  " +
                "on kullanici.kullanici_id = aktarmalar.aktarma_personel_id ";
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvMasa.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["aktarma_tarihi"].ToString());
                    item.SubItems.Add(oku["aktarma_masa_id"].ToString());
                    item.SubItems.Add(oku["masa_adi"].ToString());
                    item.SubItems.Add(oku["kullanici_adi"].ToString());
                    lvMasa.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        public void iadeHepsi(ListView lvIade)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT i.iade_tarih,u.urun_adi,m.masa_adi,k.kullanici_adi  FROM iadeler as i " +
               "LEFT JOIN masalar as m ON m.masa_id = i.iade_masa_id LEFT JOIN kullanici as k ON k.kullanici_id = i.iade_personel_id " +
               "LEFT JOIN urunler as u ON i.iade_urun_id = u.urun_id ";
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvIade.Items.Clear();
                if (oku.HasRows == false)
                {
                    MessageBox.Show("Kayıtlı Rapor Bulunmamaktadir.");
                }
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["iade_tarih"].ToString());
                    item.SubItems.Add(oku["urun_adi"].ToString());
                    item.SubItems.Add(oku["masa_adi"].ToString());
                    item.SubItems.Add(oku["kullanici_adi"].ToString());
                    lvIade.Items.Add(item);
                }
            }
            genel.sqlgonder.Parameters.Clear();
            genel.baglanti_kapat();
        }

        #endregion personel hareketleri
    }
}