using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CRAS
{
    internal class cUrunler
    {
        #region propertiz

        private cGenel genel = new cGenel();

        #endregion propertiz

        #region ID Bulma

        public string urun_id_bul(ListView lvMenu)
        {
            string urun_id = null;
            try
            {
                if (lvMenu.Items.Count > 0)
                {
                    urun_id = lvMenu.SelectedItems[0].SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("urun_id_bul=>" + ex.Message);
            }

            return urun_id;
        }

        public string urun_id_bul(ListView lvMenu, int yer) // listview deki yerini belirterek bulmak
        {
            string urun_id = null;
            try
            {
                if (lvMenu.Items.Count > 0)
                {
                    urun_id = lvMenu.SelectedItems[0].SubItems[yer].Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("urun_id_bul=>" + ex.Message);
            }

            return urun_id;
        }

        #region gereksiz

        public string adisyon_id_bul(string masa_id)
        {
            string adisyon_id = "";
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select * from adisyonlar where masa_id = " + masa_id;
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        if (masa_id == oku["masa_id"].ToString())
                        {
                            adisyon_id = oku["masa_id"].ToString();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hesap Yoktur...");
                }
                return adisyon_id;
            }
        }

        #endregion gereksiz

        #endregion ID Bulma

        #region Urun Ozellik Kontrol

        public bool Ozellik_kontrol(string urun_id) // ozellik var ise true degeri dondurur
        {
            Boolean deger = false;
            genel.sqlgonder.CommandText = "Select * from urunler where urun_ozellik =1 and urun_id=@urun_id";
            genel.sqlgonder.Parameters.AddWithValue("@urun_id", urun_id);
            genel.sqlgonder.Connection = genel.baglanti;
            genel.baglanti_ac();
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

        #endregion Urun Ozellik Kontrol

        #region Ozellikleri Ekleme

        public void ozellikCek(ListView lvOzellik, string urun_id)
        {
            genel.setHeight(lvOzellik, 250); // listview hücresinin boyutunu büyültmek
            genel.baglanti_ac();
            genel.sqlgonder.Connection = genel.baglanti;
            genel.sqlgonder.CommandText = "Select * from ozellikler where urun_id = " + urun_id;
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
                genel.baglanti_kapat();
            }
        }

        #endregion Ozellikleri Ekleme

        #region Ozelliksiz Urun Ekle

        public void urunEkle(ListView lvMenu, ListView lvSiparis)
        {
            string urun_id = null, urun_adi = null, urun_fiyat = null;
            try
            {
                if (lvMenu.Items.Count > 0)
                {
                    urun_id = lvMenu.SelectedItems[0].SubItems[0].Text;
                    urun_adi = lvMenu.SelectedItems[0].SubItems[1].Text;
                    urun_fiyat = lvMenu.SelectedItems[0].SubItems[2].Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Tekrar Ürün Seçiniz");
            }

            if (lvMenu.Items.Count > 0)
            {
                ListViewItem item = new ListViewItem(urun_id);
                item.SubItems.Add(urun_adi);
                item.SubItems.Add(urun_fiyat);
                item.SubItems.Add("");
                lvSiparis.Items.Add(item);
            }
        }

        #endregion Ozelliksiz Urun Ekle

        #region Ozellikli Urun Ekleme

        public void urunEkle(ListView lvOzellikli, ListView lvSiparis, string urun_id)
        {
            string urun_ozellik = null, urun_adi = null, urun_fiyat = null, urun_ozellik_id = null;
            try
            {
                if (lvOzellikli.Items.Count > 0)
                {
                    urun_ozellik = lvOzellikli.SelectedItems[0].SubItems[0].Text;
                    urun_ozellik_id = lvOzellikli.SelectedItems[0].SubItems[1].Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Tekrar Seçiniz.");
            }

            genel.sqlgonder.CommandText = "Select * from urunler where urun_id =" + urun_id;
            genel.sqlgonder.Connection = genel.baglanti;
            genel.baglanti_ac();
            using (MySqlDataReader oku = genel.sqlgonder.ExecuteReader())
            {
                while (oku.Read())
                {
                    urun_adi = oku["urun_adi"].ToString();
                    urun_fiyat = oku["urun_fiyat"].ToString();
                }
                ListViewItem item = new ListViewItem(urun_id);
                item.SubItems.Add(urun_adi);
                item.SubItems.Add(urun_fiyat);
                item.SubItems.Add(urun_ozellik);
                lvSiparis.Items.Add(item);
                genel.baglanti_kapat();
            }
        }

        #endregion Ozellikli Urun Ekleme
    }
}