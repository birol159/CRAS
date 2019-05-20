namespace CRAS
{
    partial class frmOdeme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOdeme));
            this.btnGeridon = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdTicket = new System.Windows.Forms.RadioButton();
            this.rdNakit = new System.Windows.Forms.RadioButton();
            this.rdKredi = new System.Windows.Forms.RadioButton();
            this.lvSiparis = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMasaNo = new System.Windows.Forms.Label();
            this.btnOdeme = new System.Windows.Forms.Button();
            this.lblToplam = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGeridon
            // 
            this.btnGeridon.BackgroundImage = global::CRAS.Properties.Resources._return;
            this.btnGeridon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeridon.FlatAppearance.BorderSize = 0;
            this.btnGeridon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeridon.Location = new System.Drawing.Point(933, 323);
            this.btnGeridon.Name = "btnGeridon";
            this.btnGeridon.Size = new System.Drawing.Size(69, 58);
            this.btnGeridon.TabIndex = 10;
            this.btnGeridon.UseVisualStyleBackColor = true;
            this.btnGeridon.Click += new System.EventHandler(this.btnGeridon_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImage = global::CRAS.Properties.Resources.logout2;
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Location = new System.Drawing.Point(1008, 323);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(69, 58);
            this.btnCikis.TabIndex = 9;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdTicket);
            this.groupBox1.Controls.Add(this.rdNakit);
            this.groupBox1.Controls.Add(this.rdKredi);
            this.groupBox1.Location = new System.Drawing.Point(496, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 103);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odeme Turu";
            // 
            // rdTicket
            // 
            this.rdTicket.AutoSize = true;
            this.rdTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdTicket.Location = new System.Drawing.Point(6, 65);
            this.rdTicket.Name = "rdTicket";
            this.rdTicket.Size = new System.Drawing.Size(147, 28);
            this.rdTicket.TabIndex = 2;
            this.rdTicket.TabStop = true;
            this.rdTicket.Text = "Ticket Odeme";
            this.rdTicket.UseVisualStyleBackColor = true;
            // 
            // rdNakit
            // 
            this.rdNakit.AutoSize = true;
            this.rdNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdNakit.Location = new System.Drawing.Point(6, 19);
            this.rdNakit.Name = "rdNakit";
            this.rdNakit.Size = new System.Drawing.Size(138, 28);
            this.rdNakit.TabIndex = 0;
            this.rdNakit.TabStop = true;
            this.rdNakit.Text = "Nakit Odeme";
            this.rdNakit.UseVisualStyleBackColor = true;
            // 
            // rdKredi
            // 
            this.rdKredi.AutoSize = true;
            this.rdKredi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdKredi.Location = new System.Drawing.Point(6, 42);
            this.rdKredi.Name = "rdKredi";
            this.rdKredi.Size = new System.Drawing.Size(182, 28);
            this.rdKredi.TabIndex = 1;
            this.rdKredi.TabStop = true;
            this.rdKredi.Text = "Kredi Kartı Odeme";
            this.rdKredi.UseVisualStyleBackColor = true;
            // 
            // lvSiparis
            // 
            this.lvSiparis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSiparis.Location = new System.Drawing.Point(134, 23);
            this.lvSiparis.Name = "lvSiparis";
            this.lvSiparis.Size = new System.Drawing.Size(341, 187);
            this.lvSiparis.TabIndex = 0;
            this.lvSiparis.UseCompatibleStateImageBehavior = false;
            this.lvSiparis.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Urun ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Urun Adi";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Urun Fiyat";
            this.columnHeader3.Width = 110;
            // 
            // lblMasaNo
            // 
            this.lblMasaNo.AutoSize = true;
            this.lblMasaNo.BackColor = System.Drawing.Color.Transparent;
            this.lblMasaNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMasaNo.Location = new System.Drawing.Point(12, 23);
            this.lblMasaNo.Name = "lblMasaNo";
            this.lblMasaNo.Size = new System.Drawing.Size(116, 25);
            this.lblMasaNo.TabIndex = 12;
            this.lblMasaNo.Text = "MASA NO";
            // 
            // btnOdeme
            // 
            this.btnOdeme.BackColor = System.Drawing.Color.Transparent;
            this.btnOdeme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOdeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdeme.Image = global::CRAS.Properties.Resources.if_shoppingcart_checkout_48803;
            this.btnOdeme.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOdeme.Location = new System.Drawing.Point(719, 85);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(178, 100);
            this.btnOdeme.TabIndex = 13;
            this.btnOdeme.Text = "ODEME";
            this.btnOdeme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOdeme.UseVisualStyleBackColor = false;
            this.btnOdeme.Click += new System.EventHandler(this.btnOdeme_Click);
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.BackColor = System.Drawing.Color.Transparent;
            this.lblToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplam.Location = new System.Drawing.Point(715, 42);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(54, 24);
            this.lblToplam.TabIndex = 14;
            this.lblToplam.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(531, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "TOPLAM HESAP : ";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmOdeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CRAS.Properties.Resources.background_cras_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1089, 399);
            this.Controls.Add(this.lvSiparis);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOdeme);
            this.Controls.Add(this.lblMasaNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGeridon);
            this.Controls.Add(this.btnCikis);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOdeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOdeme";
            this.Load += new System.EventHandler(this.frmOdeme_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeridon;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvSiparis;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.RadioButton rdTicket;
        private System.Windows.Forms.RadioButton rdKredi;
        private System.Windows.Forms.RadioButton rdNakit;
        private System.Windows.Forms.Label lblMasaNo;
        private System.Windows.Forms.Button btnOdeme;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}