using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CRAS
{
    internal class cGenel
    {
        #region Connection / Command

        public MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=brlcglrx_cras;Uid=root;Pwd=12345678;SslMode=none;Encrypt=false;charset=utf8;");

        public MySqlCommand sqlgonder = new MySqlCommand();

        #region baglanti ac kapat

        public void baglanti_ac()// kapaliysa ac
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }

        public void baglanti_kapat()// aciksa kapat
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
        }

        #endregion baglanti ac kapat

        #endregion Connection / Command

        #region Giris Yapma

        public bool cras_giris(string kulladi, string sifre)
        {
            baglanti_ac();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select * from kullanici where kullanici_adi = @k_ad and kullanici_sifre = @k_sifre and kullanici_aktif = 1";
            sqlgonder.Parameters.AddWithValue("@k_ad", kulladi);
            sqlgonder.Parameters.AddWithValue("@k_sifre", sifre);
            using (MySqlDataReader oku = sqlgonder.ExecuteReader())
            {
                sqlgonder.Parameters.Clear();
                if (oku.Read())
                {
                    baglanti_kapat();
                    return true;
                }
                else
                {
                    baglanti_kapat();
                    return false;
                }
            }
        }

        #endregion Giris Yapma

        #region Personel ID Bulma

        public string personel_id(string kullanici)
        {
            string personel_id = "";

            baglanti_ac();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select * from kullanici where kullanici_adi=@kadi";
            sqlgonder.Parameters.AddWithValue("@kadi",kullanici);
            MySqlDataReader oku = sqlgonder.ExecuteReader();
            sqlgonder.Parameters.Clear();
            while (oku.Read())
            {
                personel_id = oku["kullanici_id"].ToString();
            }
            baglanti_kapat();
            return personel_id;
        }

        #endregion Personel ID Bulma

        #region Masa Adi Bulma

        public string masa_adi_bul(string masa_id)
        {
            string masa_adi = "";
            baglanti_ac();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select masa_adi from masalar where masa_id=" + masa_id;
            MySqlDataReader oku = sqlgonder.ExecuteReader();
            while (oku.Read())
            {
                masa_adi = oku["masa_adi"].ToString();
            }
            baglanti_kapat();
            return masa_adi;
        }

        #endregion Masa Adi Bulma

        #region Hesap Kontrol

        public bool hesapKontrol(string masa_id)
        {
            baglanti_ac();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select * from adisyonlar where masa_id=@masa_id and adisyon_odeme_durumu=0";
            sqlgonder.Parameters.AddWithValue("masa_id", masa_id);
            MySqlDataReader oku = sqlgonder.ExecuteReader();
            sqlgonder.Parameters.Clear();
            if (oku.HasRows)
            {
                baglanti_kapat();
                return true;
            }
            else
            {
                baglanti_kapat();
                return false;
            }
        }

        #endregion Hesap Kontrol

        #region Yukseklik Ayarlama

        public void setHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(height, height);
            listView.SmallImageList = imgList;
        }

        #endregion Yukseklik Ayarlama

        #region Masa Getir

        public void masaGetir(ListView lvlMasalar, string masa_tur)
        {
            setHeight(lvlMasalar, 250);
            baglanti_ac();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select * from masalar where masa_tur=" + masa_tur + " ORDER BY masa_id ASC";
            using (MySqlDataReader oku = sqlgonder.ExecuteReader())
            {
                int deger = 0;
                lvlMasalar.Items.Clear();
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["masa_adi"].ToString());
                    item.SubItems.Add(oku["masa_id"].ToString());
                    lvlMasalar.BackColor = Color.White;

                    lvlMasalar.Items.Add(item);
                    deger++;
                }
                baglanti_kapat();
            }
        }

        public void masaGetir(ListView lvlMasalar, string masa_tur, string masa_id)
        {
            baglanti_ac();
            MySqlCommand sqlgonder = new MySqlCommand();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select * from masalar where masa_tur=" + masa_tur + " ORDER BY masa_id ASC";
            using (MySqlDataReader oku = sqlgonder.ExecuteReader())
            {
                lvlMasalar.Items.Clear();
                while (oku.Read())
                {
                    if (masa_id != oku["masa_id"].ToString())
                    {
                        ListViewItem item = new ListViewItem(oku["masa_adi"].ToString());
                        item.SubItems.Add(oku["masa_id"].ToString());
                        lvlMasalar.Items.Add(item);
                    }
                }
                baglanti_kapat();
            }
        }

        #endregion Masa Getir

        #region Tarih Fonksiyonları

        public string tarih_ay()
        {
            string tarih = DateTime.Now.ToString("MM");
            return tarih;
        }

        public string tarih_gun()
        {
            string tarih = DateTime.Now.ToString("dd");
            return tarih;
        }

        public string tarih_yil()
        {
            string tarih = DateTime.Now.ToString("yyyy");
            return tarih;
        }

        public string tarih_kisa()
        {
            string tarih = DateTime.Now.ToString("yyyy-MM-dd");
            return tarih;
        }

        public string tarih_uzun()
        {
            string tarih = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return tarih;
        }

        public string tarih_cevir(string tarih)
        {
            string tarih2 = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return tarih;
        }

        public string yilSec(ComboBox cbYillar)
        {
            return (string)cbYillar.SelectedItem;
            //return cbYillar.GetItemText(cbYillar.SelectedItem);
        }

        public string aySec(ComboBox cbAylar)
        {
            string deger = null;
            deger = cbAylar.SelectedIndex.ToString();
            int ay = Convert.ToInt16(deger) + 1;
            deger = ay.ToString();
            if (deger == "1" || deger == "2" || deger == "3" || deger == "4" || deger == "5" || deger == "6" || deger == "7" || deger == "8" || deger == "9")
            {
                deger = "0" + deger;
            }
            return deger;
        }

        public string gunSec(ComboBox cbGunler)
        {
            return cbGunler.GetItemText(cbGunler.SelectedItem);
        }

        #endregion Tarih Fonksiyonları

        #region Yetki Sistemi

        public string yetki_seviyesi_bul(string yetki_id)
        {
            string yetki_seviyesi = null;
            baglanti_ac();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select * from yetkiler where yetki_id= @y_id";
            sqlgonder.Parameters.AddWithValue("@y_id", yetki_id);
            using (MySqlDataReader oku = sqlgonder.ExecuteReader())
            {
                while (oku.Read())
                {
                    yetki_seviyesi = oku["yetki_seviyesi"].ToString();
                }
            }
            sqlgonder.Parameters.Clear();
            return yetki_seviyesi;
        }

        public void yetkilendirme(string kullanici_adi, Button iade, Button aktar, Button ayarlar, Button odeme)
        {
            baglanti_ac();
            string yetki_id = null;
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "Select yetki_id from kullanici where kullanici_adi = @k_adi";
            sqlgonder.Parameters.AddWithValue("@k_adi", kullanici_adi);
            using (MySqlDataReader oku = sqlgonder.ExecuteReader())
            {
                sqlgonder.Parameters.Clear();
                while (oku.Read())
                {
                    yetki_id = oku["yetki_id"].ToString();
                }
            }
            baglanti_kapat();
            string yetki_seviyesi = yetki_seviyesi_bul(yetki_id);
            if (yetki_seviyesi == "10")
            {
                iade.Visible = true;
                aktar.Visible = true;
                ayarlar.Visible = true;
                odeme.Visible = true;
            }
            else if (yetki_seviyesi == "7")
            {
                aktar.Visible = true;
                iade.Visible = true;
                ayarlar.Visible = false;
                odeme.Visible = false;
            }
            else
            {
                iade.Visible = false;
                aktar.Visible = false;
                ayarlar.Visible = false;
                odeme.Visible = false;
            }
        }

        #endregion Yetki Sistemi

        public void logEkle(string ex,string aciklama)
        {
            string mesaj = ex;
            baglanti_ac();
            sqlgonder.Connection = baglanti;
            sqlgonder.CommandText = "INSERT INTO hata_loglari (log_mesaj,log_tarih,log_form_kisim) Values (@mesaj,@tarih,@aciklama)";
            sqlgonder.Parameters.AddWithValue("@mesaj",mesaj);
            sqlgonder.Parameters.AddWithValue("@tarih", tarih_uzun());
            sqlgonder.Parameters.AddWithValue("@aciklama", aciklama);
            sqlgonder.ExecuteNonQuery();
            sqlgonder.Parameters.Clear();
            baglanti_kapat();


        }
    }
}