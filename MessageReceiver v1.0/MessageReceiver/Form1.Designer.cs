namespace MessageReceiver
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPort = new MetroSet_UI.Controls.MetroSetLabel();
            this.labelIP = new MetroSet_UI.Controls.MetroSetLabel();
            this.textBoxPort = new MetroSet_UI.Controls.MetroSetTextBox();
            this.comboBoxIP = new MetroSet_UI.Controls.MetroSetComboBox();
            this.labelTotalMessageCount = new MetroSet_UI.Controls.MetroSetLabel();
            this.listBox1 = new MetroSet_UI.Controls.MetroSetListBox();
            this.buttonListen = new MetroSet_UI.Controls.MetroSetEllipse();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPort);
            this.panel1.Controls.Add(this.labelIP);
            this.panel1.Controls.Add(this.textBoxPort);
            this.panel1.Controls.Add(this.comboBoxIP);
            this.panel1.Controls.Add(this.labelTotalMessageCount);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.buttonListen);
            this.panel1.Location = new System.Drawing.Point(13, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 570);
            this.panel1.TabIndex = 7;
            // 
            // labelPort
            // 
            this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelPort.IsDerivedStyle = true;
            this.labelPort.Location = new System.Drawing.Point(10, 55);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(46, 23);
            this.labelPort.Style = MetroSet_UI.Enums.Style.Dark;
            this.labelPort.StyleManager = null;
            this.labelPort.TabIndex = 6;
            this.labelPort.Text = "Port:";
            this.labelPort.ThemeAuthor = "Narwin";
            this.labelPort.ThemeName = "MetroDark";
            // 
            // labelIP
            // 
            this.labelIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelIP.IsDerivedStyle = true;
            this.labelIP.Location = new System.Drawing.Point(25, 23);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(46, 23);
            this.labelIP.Style = MetroSet_UI.Enums.Style.Dark;
            this.labelIP.StyleManager = null;
            this.labelIP.TabIndex = 5;
            this.labelIP.Text = "IP:";
            this.labelIP.ThemeAuthor = "Narwin";
            this.labelIP.ThemeName = "MetroDark";
            // 
            // textBoxPort
            // 
            this.textBoxPort.AutoCompleteCustomSource = null;
            this.textBoxPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBoxPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.textBoxPort.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.textBoxPort.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxPort.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxPort.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.textBoxPort.Image = null;
            this.textBoxPort.IsDerivedStyle = true;
            this.textBoxPort.Lines = null;
            this.textBoxPort.Location = new System.Drawing.Point(80, 55);
            this.textBoxPort.MaxLength = 32767;
            this.textBoxPort.Multiline = false;
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ReadOnly = false;
            this.textBoxPort.Size = new System.Drawing.Size(137, 28);
            this.textBoxPort.Style = MetroSet_UI.Enums.Style.Dark;
            this.textBoxPort.StyleManager = null;
            this.textBoxPort.TabIndex = 2;
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPort.ThemeAuthor = "Narwin";
            this.textBoxPort.ThemeName = "MetroDark";
            this.textBoxPort.UseSystemPasswordChar = false;
            this.textBoxPort.WatermarkText = "";
            this.textBoxPort.TextChanged += new System.EventHandler(this.textBoxPort_TextChanged);
            this.textBoxPort.Leave += new System.EventHandler(this.textBoxPort_Leave);
            // 
            // comboBoxIP
            // 
            this.comboBoxIP.AllowDrop = true;
            this.comboBoxIP.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.comboBoxIP.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxIP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.comboBoxIP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.comboBoxIP.CausesValidation = false;
            this.comboBoxIP.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.comboBoxIP.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.comboBoxIP.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.comboBoxIP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.comboBoxIP.FormattingEnabled = true;
            this.comboBoxIP.IsDerivedStyle = true;
            this.comboBoxIP.ItemHeight = 20;
            this.comboBoxIP.Location = new System.Drawing.Point(80, 20);
            this.comboBoxIP.Name = "comboBoxIP";
            this.comboBoxIP.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.comboBoxIP.SelectedItemForeColor = System.Drawing.Color.White;
            this.comboBoxIP.Size = new System.Drawing.Size(137, 26);
            this.comboBoxIP.Style = MetroSet_UI.Enums.Style.Dark;
            this.comboBoxIP.StyleManager = null;
            this.comboBoxIP.TabIndex = 1;
            this.comboBoxIP.ThemeAuthor = "Narwin";
            this.comboBoxIP.ThemeName = "MetroDark";
            // 
            // labelTotalMessageCount
            // 
            this.labelTotalMessageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTotalMessageCount.IsDerivedStyle = true;
            this.labelTotalMessageCount.Location = new System.Drawing.Point(10, 545);
            this.labelTotalMessageCount.Name = "labelTotalMessageCount";
            this.labelTotalMessageCount.Size = new System.Drawing.Size(165, 23);
            this.labelTotalMessageCount.Style = MetroSet_UI.Enums.Style.Dark;
            this.labelTotalMessageCount.StyleManager = null;
            this.labelTotalMessageCount.TabIndex = 6;
            this.labelTotalMessageCount.Text = "Alınan Mesaj Sayısı: 0";
            this.labelTotalMessageCount.ThemeAuthor = "Narwin";
            this.labelTotalMessageCount.ThemeName = "MetroDark";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.listBox1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBox1.HoveredItemBackColor = System.Drawing.Color.LightGray;
            this.listBox1.HoveredItemColor = System.Drawing.Color.DimGray;
            this.listBox1.IsDerivedStyle = true;
            this.listBox1.ItemHeight = 30;
            this.listBox1.Location = new System.Drawing.Point(12, 102);
            this.listBox1.MultiSelect = false;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndex = -1;
            this.listBox1.SelectedItem = null;
            this.listBox1.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.listBox1.SelectedItemColor = System.Drawing.Color.White;
            this.listBox1.SelectedText = null;
            this.listBox1.SelectedValue = null;
            this.listBox1.ShowBorder = false;
            this.listBox1.ShowScrollBar = false;
            this.listBox1.Size = new System.Drawing.Size(360, 435);
            this.listBox1.Style = MetroSet_UI.Enums.Style.Dark;
            this.listBox1.StyleManager = null;
            this.listBox1.TabIndex = 4;
            this.listBox1.ThemeAuthor = "Narwin";
            this.listBox1.ThemeName = "MetroDark";
            // 
            // buttonListen
            // 
            this.buttonListen.BorderThickness = 7;
            this.buttonListen.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonListen.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.buttonListen.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.buttonListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonListen.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonListen.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonListen.HoverTextColor = System.Drawing.Color.White;
            this.buttonListen.Image = null;
            this.buttonListen.ImageSize = new System.Drawing.Size(64, 64);
            this.buttonListen.IsDerivedStyle = true;
            this.buttonListen.Location = new System.Drawing.Point(236, 13);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonListen.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonListen.NormalTextColor = System.Drawing.Color.Black;
            this.buttonListen.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.buttonListen.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.buttonListen.PressTextColor = System.Drawing.Color.White;
            this.buttonListen.Size = new System.Drawing.Size(136, 75);
            this.buttonListen.Style = MetroSet_UI.Enums.Style.Light;
            this.buttonListen.StyleManager = null;
            this.buttonListen.TabIndex = 3;
            this.buttonListen.Text = "Dinle";
            this.buttonListen.ThemeAuthor = "Narwin";
            this.buttonListen.ThemeName = "MetroLite";
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(412, 592);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "IP Receiver";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private MetroSet_UI.Controls.MetroSetEllipse buttonListen;
        private MetroSet_UI.Controls.MetroSetListBox listBox1;
        private MetroSet_UI.Controls.MetroSetLabel labelTotalMessageCount;
        private MetroSet_UI.Controls.MetroSetTextBox textBoxPort;
        private MetroSet_UI.Controls.MetroSetComboBox comboBoxIP;
        private MetroSet_UI.Controls.MetroSetLabel labelPort;
        private MetroSet_UI.Controls.MetroSetLabel labelIP;
    }
}

