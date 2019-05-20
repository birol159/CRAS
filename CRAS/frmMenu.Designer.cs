namespace CRAS
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.button2 = new System.Windows.Forms.Button();
            this.btnSalon = new System.Windows.Forms.Button();
            this.btnBahce = new System.Windows.Forms.Button();
            this.btnLoca = new System.Windows.Forms.Button();
            this.lvMasalar = new System.Windows.Forms.ListView();
            this.lvHesap = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOdeme = new System.Windows.Forms.Button();
            this.btnSiparis = new System.Windows.Forms.Button();
            this.btnMasaAktar = new System.Windows.Forms.Button();
            this.btnIade = new System.Windows.Forms.Button();
            this.lblTopHesap = new System.Windows.Forms.Label();
            this.lblToplam = new System.Windows.Forms.Label();
            this.btnGeridon = new System.Windows.Forms.Button();
            this.btnKilitle = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::CRAS.Properties.Resources.logout2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(1083, 537);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 58);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSalon
            // 
            this.btnSalon.BackColor = System.Drawing.Color.Transparent;
            this.btnSalon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalon.Location = new System.Drawing.Point(12, 4);
            this.btnSalon.Name = "btnSalon";
            this.btnSalon.Size = new System.Drawing.Size(219, 37);
            this.btnSalon.TabIndex = 4;
            this.btnSalon.Text = "SALON";
            this.btnSalon.UseVisualStyleBackColor = false;
            this.btnSalon.Click += new System.EventHandler(this.btnSalon_Click);
            // 
            // btnBahce
            // 
            this.btnBahce.BackColor = System.Drawing.Color.Transparent;
            this.btnBahce.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBahce.Location = new System.Drawing.Point(237, 4);
            this.btnBahce.Name = "btnBahce";
            this.btnBahce.Size = new System.Drawing.Size(219, 37);
            this.btnBahce.TabIndex = 4;
            this.btnBahce.Text = "BAHCE";
            this.btnBahce.UseVisualStyleBackColor = false;
            this.btnBahce.Click += new System.EventHandler(this.btnBahce_Click);
            // 
            // btnLoca
            // 
            this.btnLoca.BackColor = System.Drawing.Color.Transparent;
            this.btnLoca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoca.Location = new System.Drawing.Point(462, 4);
            this.btnLoca.Name = "btnLoca";
            this.btnLoca.Size = new System.Drawing.Size(219, 37);
            this.btnLoca.TabIndex = 4;
            this.btnLoca.Text = "LOCA";
            this.btnLoca.UseVisualStyleBackColor = false;
            this.btnLoca.Click += new System.EventHandler(this.btnLoca_Click);
            // 
            // lvMasalar
            // 
            this.lvMasalar.FullRowSelect = true;
            this.lvMasalar.GridLines = true;
            this.lvMasalar.Location = new System.Drawing.Point(12, 55);
            this.lvMasalar.Name = "lvMasalar";
            this.lvMasalar.Size = new System.Drawing.Size(669, 467);
            this.lvMasalar.TabIndex = 5;
            this.lvMasalar.TileSize = new System.Drawing.Size(125, 125);
            this.lvMasalar.UseCompatibleStateImageBehavior = false;
            this.lvMasalar.View = System.Windows.Forms.View.Tile;
            this.lvMasalar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvlMasalar_MouseClick);
            this.lvMasalar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvlMasalar_MouseDoubleClick);
            // 
            // lvHesap
            // 
            this.lvHesap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lvHesap.FullRowSelect = true;
            this.lvHesap.Location = new System.Drawing.Point(711, 55);
            this.lvHesap.Name = "lvHesap";
            this.lvHesap.Size = new System.Drawing.Size(441, 181);
            this.lvHesap.TabIndex = 6;
            this.lvHesap.UseCompatibleStateImageBehavior = false;
            this.lvHesap.View = System.Windows.Forms.View.Details;
            this.lvHesap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvlHesap_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Urun Adı";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Urun Fiyat";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Urun Ozellik";
            this.columnHeader2.Width = 132;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Urun ID";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Adisyon ID";
            this.columnHeader5.Width = 0;
            // 
            // btnOdeme
            // 
            this.btnOdeme.BackColor = System.Drawing.Color.Transparent;
            this.btnOdeme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOdeme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOdeme.Image = global::CRAS.Properties.Resources.if_shoppingcart_checkout_488031;
            this.btnOdeme.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOdeme.Location = new System.Drawing.Point(961, 289);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(191, 142);
            this.btnOdeme.TabIndex = 7;
            this.btnOdeme.Text = "ODEME";
            this.btnOdeme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOdeme.UseVisualStyleBackColor = false;
            this.btnOdeme.Click += new System.EventHandler(this.btnOdeme_Click);
            // 
            // btnSiparis
            // 
            this.btnSiparis.BackColor = System.Drawing.Color.Transparent;
            this.btnSiparis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSiparis.ForeColor = System.Drawing.Color.Black;
            this.btnSiparis.Image = global::CRAS.Properties.Resources.if_document_add_48755;
            this.btnSiparis.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSiparis.Location = new System.Drawing.Point(702, 289);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(235, 68);
            this.btnSiparis.TabIndex = 7;
            this.btnSiparis.Text = "SIPARIS EKLE";
            this.btnSiparis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiparis.UseVisualStyleBackColor = false;
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // btnMasaAktar
            // 
            this.btnMasaAktar.BackColor = System.Drawing.Color.Transparent;
            this.btnMasaAktar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMasaAktar.ForeColor = System.Drawing.Color.Black;
            this.btnMasaAktar.Image = global::CRAS.Properties.Resources.if_exchange_2914482;
            this.btnMasaAktar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMasaAktar.Location = new System.Drawing.Point(702, 437);
            this.btnMasaAktar.Name = "btnMasaAktar";
            this.btnMasaAktar.Size = new System.Drawing.Size(235, 68);
            this.btnMasaAktar.TabIndex = 7;
            this.btnMasaAktar.Text = "MASA AKTAR";
            this.btnMasaAktar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasaAktar.UseVisualStyleBackColor = false;
            this.btnMasaAktar.Click += new System.EventHandler(this.btnMasaAktar_Click);
            // 
            // btnIade
            // 
            this.btnIade.BackColor = System.Drawing.Color.Transparent;
            this.btnIade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIade.ForeColor = System.Drawing.Color.Black;
            this.btnIade.Image = global::CRAS.Properties.Resources.if_document_delete_48756;
            this.btnIade.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIade.Location = new System.Drawing.Point(702, 363);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(235, 68);
            this.btnIade.TabIndex = 7;
            this.btnIade.Text = "IADE";
            this.btnIade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIade.UseVisualStyleBackColor = false;
            this.btnIade.Click += new System.EventHandler(this.btnIade_Click);
            // 
            // lblTopHesap
            // 
            this.lblTopHesap.AutoSize = true;
            this.lblTopHesap.BackColor = System.Drawing.Color.Transparent;
            this.lblTopHesap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblTopHesap.Location = new System.Drawing.Point(708, 254);
            this.lblTopHesap.Name = "lblTopHesap";
            this.lblTopHesap.Size = new System.Drawing.Size(108, 15);
            this.lblTopHesap.TabIndex = 8;
            this.lblTopHesap.Text = "TOPLAM HESAP : ";
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.BackColor = System.Drawing.Color.Transparent;
            this.lblToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblToplam.Location = new System.Drawing.Point(811, 254);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(0, 15);
            this.lblToplam.TabIndex = 8;
            // 
            // btnGeridon
            // 
            this.btnGeridon.BackColor = System.Drawing.Color.Transparent;
            this.btnGeridon.BackgroundImage = global::CRAS.Properties.Resources._return;
            this.btnGeridon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeridon.FlatAppearance.BorderSize = 0;
            this.btnGeridon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeridon.Location = new System.Drawing.Point(1008, 537);
            this.btnGeridon.Name = "btnGeridon";
            this.btnGeridon.Size = new System.Drawing.Size(69, 58);
            this.btnGeridon.TabIndex = 11;
            this.btnGeridon.UseVisualStyleBackColor = false;
            this.btnGeridon.Click += new System.EventHandler(this.btnGeridon_Click);
            // 
            // btnKilitle
            // 
            this.btnKilitle.BackColor = System.Drawing.Color.Transparent;
            this.btnKilitle.BackgroundImage = global::CRAS.Properties.Resources.lock_icon;
            this.btnKilitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKilitle.FlatAppearance.BorderSize = 0;
            this.btnKilitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKilitle.Location = new System.Drawing.Point(933, 537);
            this.btnKilitle.Name = "btnKilitle";
            this.btnKilitle.Size = new System.Drawing.Size(69, 58);
            this.btnKilitle.TabIndex = 11;
            this.btnKilitle.UseVisualStyleBackColor = false;
            this.btnKilitle.Click += new System.EventHandler(this.btnKilitle_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.Transparent;
            this.btnAyarlar.BackgroundImage = global::CRAS.Properties.Resources.if_Streamline_76_185096;
            this.btnAyarlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyarlar.FlatAppearance.BorderSize = 0;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAyarlar.Location = new System.Drawing.Point(858, 537);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(69, 58);
            this.btnAyarlar.TabIndex = 11;
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::CRAS.Properties.Resources.background_cras_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1165, 607);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnKilitle);
            this.Controls.Add(this.btnGeridon);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.lblTopHesap);
            this.Controls.Add(this.btnIade);
            this.Controls.Add(this.btnMasaAktar);
            this.Controls.Add(this.btnSiparis);
            this.Controls.Add(this.btnOdeme);
            this.Controls.Add(this.lvHesap);
            this.Controls.Add(this.lvMasalar);
            this.Controls.Add(this.btnLoca);
            this.Controls.Add(this.btnBahce);
            this.Controls.Add(this.btnSalon);
            this.Controls.Add(this.button2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSalon;
        private System.Windows.Forms.Button btnBahce;
        private System.Windows.Forms.Button btnLoca;
        private System.Windows.Forms.ListView lvMasalar;
        private System.Windows.Forms.ListView lvHesap;
        private System.Windows.Forms.Button btnOdeme;
        private System.Windows.Forms.Button btnSiparis;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnMasaAktar;
        private System.Windows.Forms.Button btnIade;
        private System.Windows.Forms.Label lblTopHesap;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnGeridon;
        private System.Windows.Forms.Button btnKilitle;
        private System.Windows.Forms.Button btnAyarlar;
    }
}