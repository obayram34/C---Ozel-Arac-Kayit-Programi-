namespace Arac_Kayit_Program
{
    partial class OdemeFormu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMusterino = new System.Windows.Forms.TextBox();
            this.lblAracno = new System.Windows.Forms.Label();
            this.txtAracno = new System.Windows.Forms.TextBox();
            this.lblMusteriNo = new System.Windows.Forms.Label();
            this.rdbDierKasaIslem = new System.Windows.Forms.RadioButton();
            this.chkDateSearh = new System.Windows.Forms.CheckBox();
            this.dtpSearchFinish = new System.Windows.Forms.DateTimePicker();
            this.dtpSearchStart = new System.Windows.Forms.DateTimePicker();
            this.btnGetCountsByDate = new System.Windows.Forms.Button();
            this.txtCountSearhByCarNo = new System.Windows.Forms.TextBox();
            this.btnCountSearhByCarNo = new System.Windows.Forms.Button();
            this.rdbNormalKasaIslem = new System.Windows.Forms.RadioButton();
            this.btnArsiv = new System.Windows.Forms.Button();
            this.btnKasaSil = new System.Windows.Forms.Button();
            this.btnKasaGuncell = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.BtnKayitAra = new System.Windows.Forms.Button();
            this.dgwAracListesi = new System.Windows.Forms.DataGridView();
            this.checkIndirim = new System.Windows.Forms.CheckBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIndirim = new System.Windows.Forms.TextBox();
            this.txtKalan = new System.Windows.Forms.TextBox();
            this.txtOdenenMiktar = new System.Windows.Forms.TextBox();
            this.txtToplamBorc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkboksKart = new System.Windows.Forms.CheckBox();
            this.chkboksNakit = new System.Windows.Forms.CheckBox();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnOde = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAracListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtMusterino);
            this.groupBox1.Controls.Add(this.lblAracno);
            this.groupBox1.Controls.Add(this.txtAracno);
            this.groupBox1.Controls.Add(this.lblMusteriNo);
            this.groupBox1.Controls.Add(this.rdbDierKasaIslem);
            this.groupBox1.Controls.Add(this.chkDateSearh);
            this.groupBox1.Controls.Add(this.dtpSearchFinish);
            this.groupBox1.Controls.Add(this.dtpSearchStart);
            this.groupBox1.Controls.Add(this.btnGetCountsByDate);
            this.groupBox1.Controls.Add(this.txtCountSearhByCarNo);
            this.groupBox1.Controls.Add(this.btnCountSearhByCarNo);
            this.groupBox1.Controls.Add(this.rdbNormalKasaIslem);
            this.groupBox1.Controls.Add(this.btnArsiv);
            this.groupBox1.Controls.Add(this.btnKasaSil);
            this.groupBox1.Controls.Add(this.btnKasaGuncell);
            this.groupBox1.Controls.Add(this.txtAra);
            this.groupBox1.Controls.Add(this.BtnKayitAra);
            this.groupBox1.Controls.Add(this.dgwAracListesi);
            this.groupBox1.Controls.Add(this.checkIndirim);
            this.groupBox1.Controls.Add(this.txtAciklama);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIndirim);
            this.groupBox1.Controls.Add(this.txtKalan);
            this.groupBox1.Controls.Add(this.txtOdenenMiktar);
            this.groupBox1.Controls.Add(this.txtToplamBorc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkboksKart);
            this.groupBox1.Controls.Add(this.chkboksNakit);
            this.groupBox1.Controls.Add(this.btnIptal);
            this.groupBox1.Controls.Add(this.btnOde);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1238, 645);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ÖDEME İŞLEMLERİ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(924, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 32);
            this.button1.TabIndex = 67;
            this.button1.Text = "ÖDE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMusterino
            // 
            this.txtMusterino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMusterino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMusterino.Location = new System.Drawing.Point(269, 122);
            this.txtMusterino.Name = "txtMusterino";
            this.txtMusterino.Size = new System.Drawing.Size(66, 21);
            this.txtMusterino.TabIndex = 65;
            this.txtMusterino.Text = "1";
            this.txtMusterino.TextChanged += new System.EventHandler(this.txtMusterino_TextChanged_1);
            // 
            // lblAracno
            // 
            this.lblAracno.AutoSize = true;
            this.lblAracno.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblAracno.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAracno.Location = new System.Drawing.Point(205, 80);
            this.lblAracno.Name = "lblAracno";
            this.lblAracno.Size = new System.Drawing.Size(58, 13);
            this.lblAracno.TabIndex = 62;
            this.lblAracno.Text = "ARAÇ NO:";
            this.lblAracno.Click += new System.EventHandler(this.lblAracno_Click);
            // 
            // txtAracno
            // 
            this.txtAracno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAracno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtAracno.Location = new System.Drawing.Point(269, 76);
            this.txtAracno.Name = "txtAracno";
            this.txtAracno.Size = new System.Drawing.Size(66, 21);
            this.txtAracno.TabIndex = 63;
            this.txtAracno.Text = "1";
            this.txtAracno.TextChanged += new System.EventHandler(this.txtAracno_TextChanged_1);
            // 
            // lblMusteriNo
            // 
            this.lblMusteriNo.AutoSize = true;
            this.lblMusteriNo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblMusteriNo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMusteriNo.Location = new System.Drawing.Point(185, 127);
            this.lblMusteriNo.Name = "lblMusteriNo";
            this.lblMusteriNo.Size = new System.Drawing.Size(78, 13);
            this.lblMusteriNo.TabIndex = 64;
            this.lblMusteriNo.Text = "MÜŞTERİ NO:";
            this.lblMusteriNo.Click += new System.EventHandler(this.lblMusteriNo_Click);
            // 
            // rdbDierKasaIslem
            // 
            this.rdbDierKasaIslem.AutoSize = true;
            this.rdbDierKasaIslem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.rdbDierKasaIslem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbDierKasaIslem.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbDierKasaIslem.Location = new System.Drawing.Point(269, 37);
            this.rdbDierKasaIslem.Name = "rdbDierKasaIslem";
            this.rdbDierKasaIslem.Size = new System.Drawing.Size(153, 17);
            this.rdbDierKasaIslem.TabIndex = 66;
            this.rdbDierKasaIslem.Text = "DİĞER KASA İŞLEMİ :";
            this.rdbDierKasaIslem.UseVisualStyleBackColor = false;
            this.rdbDierKasaIslem.CheckedChanged += new System.EventHandler(this.rdbDierKasaIslem_CheckedChanged);
            // 
            // chkDateSearh
            // 
            this.chkDateSearh.AutoSize = true;
            this.chkDateSearh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkDateSearh.Location = new System.Drawing.Point(1043, 105);
            this.chkDateSearh.Name = "chkDateSearh";
            this.chkDateSearh.Size = new System.Drawing.Size(144, 17);
            this.chkDateSearh.TabIndex = 61;
            this.chkDateSearh.Text = "TARİHE GÖRE  ARA";
            this.chkDateSearh.UseVisualStyleBackColor = true;
            this.chkDateSearh.CheckedChanged += new System.EventHandler(this.chkDateSearh_CheckedChanged);
            // 
            // dtpSearchFinish
            // 
            this.dtpSearchFinish.Enabled = false;
            this.dtpSearchFinish.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearchFinish.Location = new System.Drawing.Point(1131, 128);
            this.dtpSearchFinish.Name = "dtpSearchFinish";
            this.dtpSearchFinish.Size = new System.Drawing.Size(98, 20);
            this.dtpSearchFinish.TabIndex = 60;
            this.dtpSearchFinish.Visible = false;
            this.dtpSearchFinish.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dtpSearchStart
            // 
            this.dtpSearchStart.Enabled = false;
            this.dtpSearchStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearchStart.Location = new System.Drawing.Point(1017, 128);
            this.dtpSearchStart.Name = "dtpSearchStart";
            this.dtpSearchStart.Size = new System.Drawing.Size(108, 20);
            this.dtpSearchStart.TabIndex = 59;
            this.dtpSearchStart.Visible = false;
            this.dtpSearchStart.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnGetCountsByDate
            // 
            this.btnGetCountsByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnGetCountsByDate.Enabled = false;
            this.btnGetCountsByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetCountsByDate.ForeColor = System.Drawing.Color.Yellow;
            this.btnGetCountsByDate.Location = new System.Drawing.Point(1017, 154);
            this.btnGetCountsByDate.Name = "btnGetCountsByDate";
            this.btnGetCountsByDate.Size = new System.Drawing.Size(212, 31);
            this.btnGetCountsByDate.TabIndex = 57;
            this.btnGetCountsByDate.Text = "TARİHLER  ARASI";
            this.btnGetCountsByDate.UseVisualStyleBackColor = false;
            this.btnGetCountsByDate.Visible = false;
            // 
            // txtCountSearhByCarNo
            // 
            this.txtCountSearhByCarNo.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCountSearhByCarNo.Location = new System.Drawing.Point(1135, 191);
            this.txtCountSearhByCarNo.Multiline = true;
            this.txtCountSearhByCarNo.Name = "txtCountSearhByCarNo";
            this.txtCountSearhByCarNo.Size = new System.Drawing.Size(97, 26);
            this.txtCountSearhByCarNo.TabIndex = 56;
            this.txtCountSearhByCarNo.Text = "  Araç   NO";
            this.txtCountSearhByCarNo.Click += new System.EventHandler(this.txtCountSearhByCarNo_Click);
            this.txtCountSearhByCarNo.TextChanged += new System.EventHandler(this.txtCountSearhByCarNo_TextChanged);
            this.txtCountSearhByCarNo.Validated += new System.EventHandler(this.txtCountSearhByCarNo_Validated);
            // 
            // btnCountSearhByCarNo
            // 
            this.btnCountSearhByCarNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCountSearhByCarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCountSearhByCarNo.ForeColor = System.Drawing.Color.Yellow;
            this.btnCountSearhByCarNo.Location = new System.Drawing.Point(1017, 191);
            this.btnCountSearhByCarNo.Name = "btnCountSearhByCarNo";
            this.btnCountSearhByCarNo.Size = new System.Drawing.Size(112, 31);
            this.btnCountSearhByCarNo.TabIndex = 55;
            this.btnCountSearhByCarNo.Text = "HESAP ARA   >>";
            this.btnCountSearhByCarNo.UseVisualStyleBackColor = false;
            // 
            // rdbNormalKasaIslem
            // 
            this.rdbNormalKasaIslem.AutoSize = true;
            this.rdbNormalKasaIslem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rdbNormalKasaIslem.Checked = true;
            this.rdbNormalKasaIslem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbNormalKasaIslem.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbNormalKasaIslem.Location = new System.Drawing.Point(97, 37);
            this.rdbNormalKasaIslem.Name = "rdbNormalKasaIslem";
            this.rdbNormalKasaIslem.Size = new System.Drawing.Size(166, 17);
            this.rdbNormalKasaIslem.TabIndex = 54;
            this.rdbNormalKasaIslem.TabStop = true;
            this.rdbNormalKasaIslem.Text = "NORMAL KASA İŞLEMİ :";
            this.rdbNormalKasaIslem.UseVisualStyleBackColor = false;
            this.rdbNormalKasaIslem.CheckedChanged += new System.EventHandler(this.rdbNormalKasaIslem_CheckedChanged);
            // 
            // btnArsiv
            // 
            this.btnArsiv.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnArsiv.Location = new System.Drawing.Point(1059, 12);
            this.btnArsiv.Name = "btnArsiv";
            this.btnArsiv.Size = new System.Drawing.Size(130, 46);
            this.btnArsiv.TabIndex = 46;
            this.btnArsiv.Text = "ARŞİV";
            this.btnArsiv.UseVisualStyleBackColor = false;
            this.btnArsiv.Click += new System.EventHandler(this.btnArsiv_Click);
            // 
            // btnKasaSil
            // 
            this.btnKasaSil.BackColor = System.Drawing.Color.Firebrick;
            this.btnKasaSil.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKasaSil.Location = new System.Drawing.Point(401, 212);
            this.btnKasaSil.Name = "btnKasaSil";
            this.btnKasaSil.Size = new System.Drawing.Size(114, 46);
            this.btnKasaSil.TabIndex = 45;
            this.btnKasaSil.Text = "SİL";
            this.btnKasaSil.UseVisualStyleBackColor = false;
            // 
            // btnKasaGuncell
            // 
            this.btnKasaGuncell.BackColor = System.Drawing.Color.SeaGreen;
            this.btnKasaGuncell.Location = new System.Drawing.Point(652, 212);
            this.btnKasaGuncell.Name = "btnKasaGuncell";
            this.btnKasaGuncell.Size = new System.Drawing.Size(130, 46);
            this.btnKasaGuncell.TabIndex = 44;
            this.btnKasaGuncell.Text = "GÜNCELLE";
            this.btnKasaGuncell.UseVisualStyleBackColor = false;
            this.btnKasaGuncell.Click += new System.EventHandler(this.btnKasaGuncell_Click);
            // 
            // txtAra
            // 
            this.txtAra.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAra.Location = new System.Drawing.Point(1135, 232);
            this.txtAra.Multiline = true;
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(97, 26);
            this.txtAra.TabIndex = 43;
            this.txtAra.Text = "Musteri NO";
            this.txtAra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAra_MouseClick);
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // BtnKayitAra
            // 
            this.BtnKayitAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BtnKayitAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKayitAra.ForeColor = System.Drawing.Color.Yellow;
            this.BtnKayitAra.Location = new System.Drawing.Point(1017, 232);
            this.BtnKayitAra.Name = "BtnKayitAra";
            this.BtnKayitAra.Size = new System.Drawing.Size(112, 31);
            this.BtnKayitAra.TabIndex = 42;
            this.BtnKayitAra.Text = "HESAP ARA   >>";
            this.BtnKayitAra.UseVisualStyleBackColor = false;
            // 
            // dgwAracListesi
            // 
            this.dgwAracListesi.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgwAracListesi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgwAracListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwAracListesi.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgwAracListesi.Location = new System.Drawing.Point(6, 264);
            this.dgwAracListesi.Name = "dgwAracListesi";
            this.dgwAracListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwAracListesi.Size = new System.Drawing.Size(1226, 327);
            this.dgwAracListesi.TabIndex = 41;
            this.dgwAracListesi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAracListesi_CellContentClick);
            this.dgwAracListesi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAracListesi_CellValueChanged);
            // 
            // checkIndirim
            // 
            this.checkIndirim.AutoSize = true;
            this.checkIndirim.Location = new System.Drawing.Point(756, 42);
            this.checkIndirim.Name = "checkIndirim";
            this.checkIndirim.Size = new System.Drawing.Size(68, 17);
            this.checkIndirim.TabIndex = 18;
            this.checkIndirim.Text = "İNDİRİM";
            this.checkIndirim.UseVisualStyleBackColor = true;
            this.checkIndirim.Click += new System.EventHandler(this.checkIndirim_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(696, 143);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(196, 51);
            this.txtAciklama.TabIndex = 17;
            this.txtAciklama.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(764, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "AÇIKLAMA";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtIndirim
            // 
            this.txtIndirim.ForeColor = System.Drawing.Color.Teal;
            this.txtIndirim.Location = new System.Drawing.Point(740, 81);
            this.txtIndirim.Name = "txtIndirim";
            this.txtIndirim.Size = new System.Drawing.Size(100, 20);
            this.txtIndirim.TabIndex = 14;
            this.txtIndirim.Text = "0";
            this.txtIndirim.Visible = false;
            this.txtIndirim.TextChanged += new System.EventHandler(this.txtIndirim_TextChanged);
            this.txtIndirim.Leave += new System.EventHandler(this.txtIndirim_Leave);
            // 
            // txtKalan
            // 
            this.txtKalan.ForeColor = System.Drawing.Color.Red;
            this.txtKalan.Location = new System.Drawing.Point(507, 174);
            this.txtKalan.Name = "txtKalan";
            this.txtKalan.Size = new System.Drawing.Size(150, 20);
            this.txtKalan.TabIndex = 13;
            this.txtKalan.Text = "0";
            this.txtKalan.TextChanged += new System.EventHandler(this.txtKalan_TextChanged);
            // 
            // txtOdenenMiktar
            // 
            this.txtOdenenMiktar.ForeColor = System.Drawing.Color.Navy;
            this.txtOdenenMiktar.Location = new System.Drawing.Point(507, 130);
            this.txtOdenenMiktar.Name = "txtOdenenMiktar";
            this.txtOdenenMiktar.Size = new System.Drawing.Size(150, 20);
            this.txtOdenenMiktar.TabIndex = 12;
            this.txtOdenenMiktar.TextChanged += new System.EventHandler(this.txtOdenenMiktar_TextChanged);
            this.txtOdenenMiktar.Leave += new System.EventHandler(this.txtOdenenMiktar_Leave);
            // 
            // txtToplamBorc
            // 
            this.txtToplamBorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtToplamBorc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtToplamBorc.Location = new System.Drawing.Point(507, 81);
            this.txtToplamBorc.Name = "txtToplamBorc";
            this.txtToplamBorc.ReadOnly = true;
            this.txtToplamBorc.Size = new System.Drawing.Size(150, 21);
            this.txtToplamBorc.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "KALAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ÖDEME  MİKTARI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ÜCRET";
            // 
            // checkboksKart
            // 
            this.checkboksKart.AutoSize = true;
            this.checkboksKart.Location = new System.Drawing.Point(599, 41);
            this.checkboksKart.Name = "checkboksKart";
            this.checkboksKart.Size = new System.Drawing.Size(68, 17);
            this.checkboksKart.TabIndex = 7;
            this.checkboksKart.Text = "KARTLA";
            this.checkboksKart.UseVisualStyleBackColor = true;
            this.checkboksKart.CheckedChanged += new System.EventHandler(this.checkboksKart_CheckedChanged);
            this.checkboksKart.CheckStateChanged += new System.EventHandler(this.checkboksKart_CheckStateChanged);
            // 
            // chkboksNakit
            // 
            this.chkboksNakit.AutoSize = true;
            this.chkboksNakit.Checked = true;
            this.chkboksNakit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboksNakit.Location = new System.Drawing.Point(488, 41);
            this.chkboksNakit.Name = "chkboksNakit";
            this.chkboksNakit.Size = new System.Drawing.Size(58, 17);
            this.chkboksNakit.TabIndex = 6;
            this.chkboksNakit.Text = "NAKİT";
            this.chkboksNakit.UseVisualStyleBackColor = true;
            this.chkboksNakit.CheckStateChanged += new System.EventHandler(this.chkboksNakit_CheckStateChanged);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.IndianRed;
            this.btnIptal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIptal.Location = new System.Drawing.Point(521, 212);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(114, 46);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnOde
            // 
            this.btnOde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOde.Location = new System.Drawing.Point(788, 212);
            this.btnOde.Name = "btnOde";
            this.btnOde.Size = new System.Drawing.Size(130, 46);
            this.btnOde.TabIndex = 4;
            this.btnOde.Text = "ÖDE";
            this.btnOde.UseVisualStyleBackColor = false;
            this.btnOde.Click += new System.EventHandler(this.btnOde_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OdemeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1246, 669);
            this.Controls.Add(this.groupBox1);
            this.Name = "OdemeFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OdemeFormu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OdemeFormu_FormClosing);
            this.Load += new System.EventHandler(this.OdemeFormu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAracListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIndirim;
        private System.Windows.Forms.TextBox txtKalan;
        private System.Windows.Forms.TextBox txtOdenenMiktar;
        private System.Windows.Forms.TextBox txtToplamBorc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkboksKart;
        private System.Windows.Forms.CheckBox chkboksNakit;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnOde;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkIndirim;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button BtnKayitAra;
        private System.Windows.Forms.DataGridView dgwAracListesi;
        private System.Windows.Forms.Button btnKasaGuncell;
        private System.Windows.Forms.Button btnKasaSil;
        private System.Windows.Forms.Button btnArsiv;
        private System.Windows.Forms.RadioButton rdbNormalKasaIslem;
        private System.Windows.Forms.Button btnGetCountsByDate;
        private System.Windows.Forms.TextBox txtCountSearhByCarNo;
        private System.Windows.Forms.Button btnCountSearhByCarNo;
        private System.Windows.Forms.DateTimePicker dtpSearchFinish;
        private System.Windows.Forms.DateTimePicker dtpSearchStart;
        private System.Windows.Forms.CheckBox chkDateSearh;
        private System.Windows.Forms.TextBox txtMusterino;
        private System.Windows.Forms.Label lblAracno;
        private System.Windows.Forms.TextBox txtAracno;
        private System.Windows.Forms.Label lblMusteriNo;
        private System.Windows.Forms.RadioButton rdbDierKasaIslem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}