namespace CRAS
{
    partial class frmMasa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasa));
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeridon = new System.Windows.Forms.Button();
            this.lvMasalar = new System.Windows.Forms.ListView();
            this.btnLoca = new System.Windows.Forms.Button();
            this.btnBahce = new System.Windows.Forms.Button();
            this.btnSalon = new System.Windows.Forms.Button();
            this.btnMasaAktar = new System.Windows.Forms.Button();
            this.lvHesap = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMasaNo = new System.Windows.Forms.Label();
            this.lvHedefMasa = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImage = global::CRAS.Properties.Resources.logout2;
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Location = new System.Drawing.Point(1073, 436);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(69, 58);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnGeridon
            // 
            this.btnGeridon.BackgroundImage = global::CRAS.Properties.Resources._return;
            this.btnGeridon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeridon.FlatAppearance.BorderSize = 0;
            this.btnGeridon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeridon.Location = new System.Drawing.Point(998, 436);
            this.btnGeridon.Name = "btnGeridon";
            this.btnGeridon.Size = new System.Drawing.Size(69, 58);
            this.btnGeridon.TabIndex = 11;
            this.btnGeridon.UseVisualStyleBackColor = true;
            this.btnGeridon.Click += new System.EventHandler(this.btnGeridon_Click);
            // 
            // lvMasalar
            // 
            this.lvMasalar.FullRowSelect = true;
            this.lvMasalar.GridLines = true;
            this.lvMasalar.Location = new System.Drawing.Point(8, 61);
            this.lvMasalar.Name = "lvMasalar";
            this.lvMasalar.Size = new System.Drawing.Size(669, 433);
            this.lvMasalar.TabIndex = 12;
            this.lvMasalar.TileSize = new System.Drawing.Size(125, 125);
            this.lvMasalar.UseCompatibleStateImageBehavior = false;
            this.lvMasalar.View = System.Windows.Forms.View.Tile;
            this.lvMasalar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvMasalar_MouseClick);
            // 
            // btnLoca
            // 
            this.btnLoca.BackColor = System.Drawing.Color.Transparent;
            this.btnLoca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoca.Location = new System.Drawing.Point(458, 12);
            this.btnLoca.Name = "btnLoca";
            this.btnLoca.Size = new System.Drawing.Size(219, 37);
            this.btnLoca.TabIndex = 13;
            this.btnLoca.Text = "LOCA";
            this.btnLoca.UseVisualStyleBackColor = false;
            this.btnLoca.Click += new System.EventHandler(this.btnLoca_Click);
            // 
            // btnBahce
            // 
            this.btnBahce.BackColor = System.Drawing.Color.Transparent;
            this.btnBahce.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBahce.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBahce.Location = new System.Drawing.Point(233, 12);
            this.btnBahce.Name = "btnBahce";
            this.btnBahce.Size = new System.Drawing.Size(219, 37);
            this.btnBahce.TabIndex = 14;
            this.btnBahce.Text = "BAHCE";
            this.btnBahce.UseVisualStyleBackColor = false;
            this.btnBahce.Click += new System.EventHandler(this.btnBahce_Click);
            // 
            // btnSalon
            // 
            this.btnSalon.BackColor = System.Drawing.Color.Transparent;
            this.btnSalon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSalon.Location = new System.Drawing.Point(8, 12);
            this.btnSalon.Name = "btnSalon";
            this.btnSalon.Size = new System.Drawing.Size(219, 37);
            this.btnSalon.TabIndex = 15;
            this.btnSalon.Text = "SALON";
            this.btnSalon.UseVisualStyleBackColor = false;
            this.btnSalon.Click += new System.EventHandler(this.btnSalon_Click);
            // 
            // btnMasaAktar
            // 
            this.btnMasaAktar.BackColor = System.Drawing.Color.Transparent;
            this.btnMasaAktar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMasaAktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMasaAktar.Image = global::CRAS.Properties.Resources.if_exchange_2914482;
            this.btnMasaAktar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMasaAktar.Location = new System.Drawing.Point(714, 436);
            this.btnMasaAktar.Name = "btnMasaAktar";
            this.btnMasaAktar.Size = new System.Drawing.Size(221, 58);
            this.btnMasaAktar.TabIndex = 16;
            this.btnMasaAktar.Text = "MASA AKTAR";
            this.btnMasaAktar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasaAktar.UseVisualStyleBackColor = false;
            this.btnMasaAktar.Click += new System.EventHandler(this.btnMasaAktar_Click);
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
            this.lvHesap.Location = new System.Drawing.Point(683, 37);
            this.lvHesap.Name = "lvHesap";
            this.lvHesap.Size = new System.Drawing.Size(441, 181);
            this.lvHesap.TabIndex = 17;
            this.lvHesap.UseCompatibleStateImageBehavior = false;
            this.lvHesap.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Urun Adı";
            this.columnHeader1.Width = 127;
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
            // lblMasaNo
            // 
            this.lblMasaNo.AutoSize = true;
            this.lblMasaNo.BackColor = System.Drawing.Color.Transparent;
            this.lblMasaNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMasaNo.Location = new System.Drawing.Point(683, 9);
            this.lblMasaNo.Name = "lblMasaNo";
            this.lblMasaNo.Size = new System.Drawing.Size(213, 24);
            this.lblMasaNo.TabIndex = 18;
            this.lblMasaNo.Text = "AKTARILACAK MASA";
            // 
            // lvHedefMasa
            // 
            this.lvHedefMasa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvHedefMasa.FullRowSelect = true;
            this.lvHedefMasa.Location = new System.Drawing.Point(683, 249);
            this.lvHedefMasa.Name = "lvHedefMasa";
            this.lvHedefMasa.Size = new System.Drawing.Size(441, 181);
            this.lvHedefMasa.TabIndex = 17;
            this.lvHedefMasa.UseCompatibleStateImageBehavior = false;
            this.lvHedefMasa.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Urun Adı";
            this.columnHeader6.Width = 127;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Urun Fiyat";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Urun Ozellik";
            this.columnHeader8.Width = 132;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Urun ID";
            this.columnHeader9.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Adisyon ID";
            this.columnHeader10.Width = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(683, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "HEDEF MASA";
            // 
            // frmMasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CRAS.Properties.Resources.background_cras_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1154, 506);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvHedefMasa);
            this.Controls.Add(this.lblMasaNo);
            this.Controls.Add(this.lvHesap);
            this.Controls.Add(this.btnMasaAktar);
            this.Controls.Add(this.btnLoca);
            this.Controls.Add(this.btnBahce);
            this.Controls.Add(this.btnSalon);
            this.Controls.Add(this.lvMasalar);
            this.Controls.Add(this.btnGeridon);
            this.Controls.Add(this.btnCikis);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMasa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMasa";
            this.Load += new System.EventHandler(this.frmMasa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeridon;
        private System.Windows.Forms.ListView lvMasalar;
        private System.Windows.Forms.Button btnLoca;
        private System.Windows.Forms.Button btnBahce;
        private System.Windows.Forms.Button btnSalon;
        private System.Windows.Forms.Button btnMasaAktar;
        private System.Windows.Forms.ListView lvHesap;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblMasaNo;
        private System.Windows.Forms.ListView lvHedefMasa;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label label1;
    }
}