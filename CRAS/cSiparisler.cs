using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CRAS
{
    internal class cSiparisler
    {
        #region Properties

        private cGenel genel = new cGenel();
        private cUrunler urunler = new cUrunler();

        #endregion Properties

        #region Menu / Hesap Getir

        public void menuGetir(ListView lvMenu, string kategori_id)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select * from urunler where kategori_id = " + kategori_id;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvMenu.Items.Clear();
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["urun_id"].ToString());
                    item.SubItems.Add(oku["urun_adi"].ToString());
                    item.SubItems.Add(oku["urun_fiyat"].ToString());
                    lvMenu.Items.Add(item);
                }
            }
            genel.baglanti_kapat();
        }

        public void hesapGetir(ListView lvSiparis, string masa_id, Button odeme)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT adisyonlar.adisyon_odeme_durumu,adisyonlar.adisyon_id,adisyonlar.adisyon_urun_id," +
                "urunler.urun_adi,urunler.urun_fiyat,adisyonlar.urun_ozellik_adi, adisyonlar.masa_id" +
                " FROM adisyonlar" +
                " LEFT JOIN urunler " +
                "ON adisyonlar.adisyon_urun_id = urunler.urun_id " +
                "where adisyonlar.masa_id=@masa_id and adisyonlar.adisyon_odeme_durumu=@durum";
            genel.sqlgonder.Parameters.AddWithValue("@masa_id", masa_id);
            genel.sqlgonder.Parameters.AddWithValue("@durum", "0");
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvSiparis.Items.Clear();
                string urun_adi = "", urun_id = "", ozellik = "", adisyon_id = "";
                if (oku.HasRows)
                {
                    odeme.Enabled = true;
                    while (oku.Read())
                    {
                        urun_id = oku["adisyon_urun_id"].ToString();
                        adisyon_id = oku["adisyon_id"].ToString();
                        urun_adi = oku["urun_adi"].ToString();
                        ozellik = oku["urun_ozellik_adi"].ToString();
                        decimal fiyat = Convert.ToDecimal(oku["urun_fiyat"].ToString());
                        ListViewItem item = new ListViewItem(urun_adi);
                        item.SubItems.Add(fiyat.ToString());
                        item.SubItems.Add(ozellik.ToString());
                        item.SubItems.Add(urun_id.ToString());
                        item.SubItems.Add(adisyon_id.ToString());
                        lvSiparis.Items.Add(item);
                    }
                }
                else
                {
                    ListViewItem item = new ListViewItem("Hesap Yoktur..");
                    lvSiparis.Items.Add(item);
                    odeme.Enabled = false;
                }
                genel.sqlgonder.Parameters.Clear();
                genel.baglanti_kapat();
            }
        }

        public void hesapGetir(ListView lvSiparis, string masa_id)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT adisyonlar.adisyon_odeme_durumu,adisyonlar.adisyon_id,adisyonlar.adisyon_urun_id," +
                "urunler.urun_adi,urunler.urun_fiyat,adisyonlar.urun_ozellik_adi, adisyonlar.masa_id" +
                " FROM adisyonlar" +
                " LEFT JOIN urunler " +
                "ON adisyonlar.adisyon_urun_id = urunler.urun_id " +
                "where adisyonlar.masa_id=@masa_id and adisyonlar.adisyon_odeme_durumu=@durum";
            genel.sqlgonder.Parameters.AddWithValue("@masa_id", masa_id);
            genel.sqlgonder.Parameters.AddWithValue("@durum", "0");
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvSiparis.Items.Clear();
                string urun_adi = "", urun_id = "", ozellik = "", adisyon_id = "";
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        urun_id = oku["adisyon_urun_id"].ToString();
                        adisyon_id = oku["adisyon_id"].ToString();
                        urun_adi = oku["urun_adi"].ToString();
                        ozellik = oku["urun_ozellik_adi"].ToString();
                        decimal fiyat = Convert.ToDecimal(oku["urun_fiyat"].ToString());
                        ListViewItem item = new ListViewItem(urun_adi);
                        item.SubItems.Add(fiyat.ToString());
                        item.SubItems.Add(ozellik.ToString());
                        item.SubItems.Add(urun_id.ToString());
                        item.SubItems.Add(adisyon_id.ToString());
                        lvSiparis.Items.Add(item);
                    }
                }
                else
                {
                    ListViewItem item = new ListViewItem("Hesap Yoktur..");
                    lvSiparis.Items.Add(item);
                }
                genel.sqlgonder.Parameters.Clear();
                genel.baglanti_kapat();
            }
        }

        public void odeme_hesap_getir(ListView lvSiparis, string masa_id) // odeme kismi hesap getirme
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT adisyonlar.adisyon_urun_id,urunler.urun_adi,urunler.urun_fiyat,adisyonlar.urun_ozellik_adi, adisyonlar.masa_id FROM adisyonlar LEFT JOIN urunler ON adisyonlar.adisyon_urun_id = urunler.urun_id where adisyonlar.masa_id =" + masa_id;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                lvSiparis.Items.Clear();
                string urun_adi = "", urun_id = "", ozellik = "";
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        urun_id = oku["adisyon_urun_id"].ToString();
                        urun_adi = oku["urun_adi"].ToString();
                        ozellik = oku["urun_ozellik_adi"].ToString();
                        decimal fiyat = Convert.ToDecimal(oku["urun_fiyat"].ToString());
                        ListViewItem item = new ListViewItem(urun_id);
                        item.SubItems.Add(urun_adi);
                        item.SubItems.Add(fiyat.ToString());
                        lvSiparis.Items.Add(item);
                    }
                }
                else
                {
                    ListViewItem item = new ListViewItem("Hesap Yoktur..2.else");
                    lvSiparis.Items.Add(item);
                }
            }

            genel.baglanti_kapat();
        }

        #endregion Menu / Hesap Getir

        #region ToplamBul

        public decimal toplamBul(string masa_id)
        {
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "SELECT  ads.adisyon_urun_id,urunler.urun_fiyat" +
                "FROM adisyonlar as ads " +
                "LEFT JOIN urunler " +
                "ON ads.adisyon_urun_id = urunler.urun_id " +
                "WHERE ads.masa_id=@masa_id AND ads.adisyon_odeme_durumu=@durum";
            genel.sqlgonder.Parameters.AddWithValue("@masa_id", masa_id);
            genel.sqlgonder.Parameters.AddWithValue("@durum", "0");
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                decimal toplam = 0;
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        decimal fiyat = Convert.ToDecimal(oku["urun_fiyat"].ToString());
                        toplam += fiyat;
                    }
                }
                genel.sqlgonder.Parameters.Clear();
                genel.baglanti_kapat();
                return toplam;
            }
        }

        public decimal toplamBul(ListView lvHesap, int yer)
        {
            decimal top = 0;
            if (lvHesap.Items.Count > 0)
            {
                for (int i = 0; i < lvHesap.Items.Count; i++)
                {
                    top += Convert.ToDecimal(lvHesap.Items[i].SubItems[yer].Text);
                }
            }

            return top;
        }

        #endregion ToplamBul

        #region urunleri gonder

        public void Gonder(ListView lvsiparis, string masa_id, Form frm2)
        {
            string urun_id = "";
            string urun_ozellik = "";
            try
            {
                if (lvsiparis.Items.Count > 0)
                {
                    genel.baglanti_ac();
                    genel.sqlgonder.Connection = genel.baglanti;
                    for (int i = 0; i < lvsiparis.Items.Count; i++)
                    {
                        urun_id = lvsiparis.Items[i].SubItems[0].Text;
                        urun_ozellik = lvsiparis.Items[i].SubItems[3].Text;
                        genel.sqlgonder.CommandText = "insert into adisyonlar (adisyon_urun_id,urun_ozellik_adi,masa_id) VALUES (@id,@ozellik,@masaid)";
                        genel.sqlgonder.Parameters.AddWithValue("@id", urun_id);
                        genel.sqlgonder.Parameters.AddWithValue("@ozellik", urun_ozellik);
                        genel.sqlgonder.Parameters.AddWithValue("@masaid", masa_id);
                        genel.sqlgonder.ExecuteNonQuery();
                        genel.sqlgonder.Parameters.Clear();
                    }
                    genel.sqlgonder.CommandText = "update masalar set masa_durum = 1 where masa_id=@masaid";
                    genel.sqlgonder.Parameters.AddWithValue("@masaid", masa_id);
                    genel.sqlgonder.ExecuteNonQuery();
                    genel.sqlgonder.Parameters.Clear();
                    genel.baglanti_kapat();
                    frmMenu frm = new frmMenu();
                    frm2.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen önce Ürün Ekleyiniz");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Terkar Tıklayınız.");
            }
        }

        #endregion urunleri gonder

        #region Raporlar

        public int rapor_adet(string urun_id)
        {
            int adet = 0;

            genel.baglanti_ac();
            string tarih = genel.tarih_kisa();
            genel.sqlgonder.CommandText = "select * from raporlar where rapor_urun_id =@urun_id and rapor_tarih=@tarih";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih);
            genel.sqlgonder.Connection = genel.baglanti;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                genel.sqlgonder.Parameters.Clear();
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        adet = Convert.ToInt16(oku["rapor_urun_adet"].ToString());
                    }
                }
                genel.baglanti_kapat();
                genel.sqlgonder.Parameters.Clear();
                return adet;
            }
        }

        public bool rapor_urun_kontrol(string urun_id)
        {
            genel.baglanti_ac();
            string tarih = genel.tarih_kisa();
            genel.sqlgonder.CommandText = "select * from raporlar where rapor_urun_id =@urun_id and rapor_tarih=@tarih";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih);
            genel.sqlgonder.Connection = genel.baglanti;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                genel.sqlgonder.Parameters.Clear();
                if (oku.HasRows)
                {
                    genel.baglanti_kapat();
                    return true;
                }
                else
                {
                    genel.sqlgonder.Parameters.Clear();
                    genel.baglanti_kapat();
                    return false;
                }
            }
        }

        public bool rapor_urun_kontrol(string urun_id, string ay, string yil)
        {
            bool deger = false;
            genel.baglanti_ac();
            string tarih = genel.tarih_kisa();

            genel.sqlgonder.CommandText = "select * from aylik_raporlar where rapor_urun_id =@urun_id and rapor_ayi=@ay and rapor_yili=@yil";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.Parameters.AddWithValue("@ay", ay);
            genel.sqlgonder.Parameters.AddWithValue("@yil", yil);
            genel.sqlgonder.Connection = genel.baglanti;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                genel.sqlgonder.Parameters.Clear();
                if (oku.HasRows)
                {
                    genel.baglanti_kapat();
                    deger = true; return deger;
                }
                return deger;
            }
        }

        public void raporEkle(ListView lvUrunler)
        {
            string ay = DateTime.Now.ToString("MM");
            string yil = DateTime.Now.ToString("yyyy");
            try
            {
                if (lvUrunler.Items.Count > 0)
                {
                    string urun_id = "";
                    int adet = 0;
                    string tarih = genel.tarih_kisa();
                    genel.baglanti_ac();
                    genel.sqlgonder.Connection = genel.baglanti;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        adet = 0;
                        urun_id = lvUrunler.Items[i].SubItems[0].Text;
                        if (rapor_urun_kontrol(urun_id) == false) // urun yoksa
                        {
                            genel.sqlgonder.CommandText = "insert into raporlar (rapor_tarih,rapor_urun_id,rapor_urun_adet) VALUES ( @tarih , @urun_id , 1 ) ";
                            genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih);
                            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                            genel.baglanti_ac();
                            genel.sqlgonder.ExecuteNonQuery();
                            genel.sqlgonder.Parameters.Clear();
                        }
                        else if (rapor_urun_kontrol(urun_id, ay, yil) == false) // aylik yoksa
                        {
                            genel.sqlgonder.CommandText = "insert into aylik_raporlar (rapor_ayi,rapor_yili,rapor_urun_id,rapor_urun_adet) VALUES ( @ay,@yil, @urun_id , 1 ) ";
                            genel.sqlgonder.Parameters.AddWithValue("@ay", ay);
                            genel.sqlgonder.Parameters.AddWithValue("@yil", yil);
                            genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih);
                            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                            genel.baglanti_ac();
                            genel.sqlgonder.ExecuteNonQuery();
                            genel.sqlgonder.Parameters.Clear();
                        }
                        else if (rapor_urun_kontrol(urun_id) == true) // urun varsa
                        {
                            adet = rapor_adet(urun_id);
                            adet++;
                            genel.sqlgonder.CommandText = " update raporlar set rapor_urun_adet=@adet where rapor_urun_id =@urun_id";
                            genel.sqlgonder.Parameters.AddWithValue("@adet", adet);
                            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                            genel.baglanti_ac();
                            genel.sqlgonder.ExecuteNonQuery();
                            genel.sqlgonder.Parameters.Clear();
                        }
                        else if (rapor_urun_kontrol(urun_id, ay, yil) == true) // aylik varsa
                        {
                            genel.sqlgonder.CommandText = " update aylik_raporlar set rapor_urun_adet=@adet where rapor_urun_id =@urun_id and rapor_ayi=@ay and rapor_yili=@yil";
                            genel.sqlgonder.Parameters.AddWithValue("@adet", adet);
                            genel.sqlgonder.Parameters.AddWithValue("@ay", ay);
                            genel.sqlgonder.Parameters.AddWithValue("@yil", yil);
                            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                            genel.sqlgonder.ExecuteNonQuery();
                            genel.sqlgonder.Parameters.Clear();
                        }
                    }
                    genel.baglanti_kapat();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public int rapor_adet_ay(string urun_id, string ay, string yil)
        {
            int adet = 0;
            genel.baglanti_ac();
            genel.sqlgonder.CommandText = "select rapor_urun_adet from aylik_raporlar where rapor_urun_id =@urun_id and rapor_ayi=@ay and rapor_yili=@yil";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.Parameters.AddWithValue("@ay", ay);
            genel.sqlgonder.Parameters.AddWithValue("@yil", yil);
            genel.sqlgonder.Connection = genel.baglanti;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                genel.sqlgonder.Parameters.Clear();
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        adet = Convert.ToInt16(oku["rapor_urun_adet"].ToString());
                    }
                }
                genel.baglanti_kapat();
                genel.sqlgonder.Parameters.Clear();
                return adet;
            }
        }

        public void aylikRaporEkle(ListView lvUrunler)
        {
            try
            {
                if (lvUrunler.Items.Count > 0)
                {
                    string urun_id = "";
                    int adet = 0;
                    string ay = DateTime.Now.ToString("MM");
                    string yil = DateTime.Now.ToString("yyyy");
                    genel.baglanti_ac();
                    genel.sqlgonder.Connection = genel.baglanti;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        adet = 0;
                        urun_id = lvUrunler.Items[i].SubItems[0].Text;
                        if (rapor_urun_kontrol(urun_id, ay, yil) == false) // urun yoksa
                        {
                            genel.sqlgonder.CommandText = "insert into aylik_raporlar (rapor_ayi,rapor_yili,rapor_urun_id,rapor_urun_adet) VALUES ( @ay ,@yil, @urun_id , 1 ) ";
                            genel.sqlgonder.Parameters.AddWithValue("@ay", ay);
                            genel.sqlgonder.Parameters.AddWithValue("@yil", yil);
                            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                            genel.baglanti_ac();
                            genel.sqlgonder.ExecuteNonQuery();
                            genel.sqlgonder.Parameters.Clear();
                        }
                        else if (rapor_urun_kontrol(urun_id) == true) // urun varsa
                        {
                            adet = rapor_adet_ay(urun_id, ay, yil);
                            adet++;
                            genel.sqlgonder.CommandText = " update aylik_raporlar set rapor_urun_adet=@adet where rapor_urun_id =@urun_id and rapor_ayi=@ay and rapor_yili=@yil";
                            genel.sqlgonder.Parameters.AddWithValue("@adet", adet);
                            genel.sqlgonder.Parameters.AddWithValue("@ay", ay);
                            genel.sqlgonder.Parameters.AddWithValue("@yil", yil);
                            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
                            genel.baglanti_ac();
                            genel.sqlgonder.ExecuteNonQuery();
                            genel.sqlgonder.Parameters.Clear();
                        }
                    }
                    genel.baglanti_kapat();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion Raporlar

        #region Hesap Odeme

        public void hesapOdeme(ListView lvSiparis, string masa_id, string odemeTuru)
        {
            decimal toplam = 0;
            string tarih = genel.tarih_uzun();
            toplam = toplamBul(lvSiparis, 2);
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = " update adisyonlar  set adisyon_odeme_durumu=1 where adisyon_odeme_durumu=0 and masa_id=@masa_id";
            genel.sqlgonder.Parameters.AddWithValue("@masa_id", masa_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            genel.sqlgonder.CommandText = "INSERT INTO satislar(satis_toplam_fiyat,satis_masa_id,satis_odeme_turu,satis_tarih) VALUES " +
                "( @fiyat,@masa_id,@odeme_turu,@tarih) ";
            genel.sqlgonder.Parameters.AddWithValue("@fiyat", toplam);
            genel.sqlgonder.Parameters.AddWithValue("@masa_id", masa_id);
            genel.sqlgonder.Parameters.AddWithValue("@odeme_turu", odemeTuru);
            genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih);
            genel.sqlgonder.ExecuteNonQuery(); // sorgu gonderılır
            genel.sqlgonder.Parameters.Clear(); // parametreler sifirlanir
            genel.sqlgonder.CommandText = "update masalar set masa_durum=0 where masa_id=@masaid";
            genel.sqlgonder.Parameters.AddWithValue("@masaid", masa_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            raporEkle(lvSiparis);
            genel.baglanti_kapat();
        }

        #endregion Hesap Odeme

        #region Urun Iade

        public void urun_iade(ListView lvHesap, string masa_id, string kullanici, Button odeme)
        {
            try
            {
                genel.baglanti_ac();
                if (lvHesap.SelectedItems[0].SubItems[0].Text != "Hesap Yoktur..")
                {
                    string tarih = genel.tarih_uzun();
                    string adisyon_id = lvHesap.SelectedItems[0].SubItems[4].Text;
                    string urun_id = lvHesap.SelectedItems[0].SubItems[3].Text;
                    string urun_adi = lvHesap.SelectedItems[0].SubItems[0].Text;
                    string personel_id = genel.personel_id(frmGiris.kullanici_adi);
                    genel.baglanti_ac();
                    genel.sqlgonder.Connection = genel.baglanti;
                    genel.sqlgonder.CommandText = "INSERT INTO iadeler(iade_urun_id,iade_personel_id,iade_masa_id,iade_tarih) VALUES(@urunid,@personelid,@masaid,@tarih) ";
                    genel.sqlgonder.Parameters.AddWithValue("@urunid", urun_id);
                    genel.sqlgonder.Parameters.AddWithValue("@personelid", personel_id);
                    genel.sqlgonder.Parameters.AddWithValue("@masaid", masa_id);
                    genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih);
                    genel.sqlgonder.ExecuteNonQuery();
                    genel.sqlgonder.Parameters.Clear();
                    genel.sqlgonder.CommandText = "Delete from adisyonlar where adisyon_id=" + adisyon_id;
                    genel.sqlgonder.ExecuteNonQuery();
                    hesapGetir(lvHesap, masa_id);
                    MessageBox.Show(urun_adi + " İade edilmiştir..");
                    genel.baglanti_kapat();
                    odeme.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Tekrar Seçim Yapınız." + ex.Message);
                genel.sqlgonder.Parameters.Clear();
            }
        }

        #endregion Urun Iade

        #region Masa Aktar

        public void masa_aktar(string masa_id, string aktarilacak, Form form)
        {
            string masa_adi = genel.masa_adi_bul(masa_id);
            genel.baglanti_ac();
            string tarih = genel.tarih_uzun();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "update adisyonlar set masa_id=@aktarilacak where masa_id=@masa_id";
            genel.sqlgonder.Parameters.AddWithValue("@aktarilacak", aktarilacak);
            genel.sqlgonder.Parameters.AddWithValue("@masa_id", masa_id);
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            string personel_id = genel.personel_id(frmGiris.kullanici_adi);
            genel.baglanti_ac();
            genel.sqlgonder.CommandText = " insert into aktarmalar(aktarma_masa_id,aktarma_aktarilan_masa_id,aktarma_personel_id,aktarma_tarihi) VALUES (@masa_adi,@aktarilacak,@personel_id,@tarih) ";
            genel.sqlgonder.Parameters.AddWithValue("@masa_adi", masa_adi); // aktarilan masanın adı
            genel.sqlgonder.Parameters.AddWithValue("@aktarilacak", aktarilacak); // aktarildigi masanin adi
            genel.sqlgonder.Parameters.AddWithValue("@personel_id", personel_id); // kim aktarma islemini yapdı
            genel.sqlgonder.Parameters.AddWithValue("@tarih", tarih); // ne zaman yapdı
            genel.sqlgonder.ExecuteNonQuery();
            genel.sqlgonder.Parameters.Clear();
            masa_id = genel.masa_adi_bul(masa_id);
            genel.baglanti_ac();
            aktarilacak = genel.masa_adi_bul(aktarilacak);
            frmMenu frm = new frmMenu();
            form.Hide();
            frm.Show();
            MessageBox.Show(masa_id + " => " + aktarilacak + " masasına aktarılmıştır...");
        }

        #endregion Masa Aktar
    }
}