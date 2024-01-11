namespace GateLogix
{
    partial class GateLogix
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.firmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mjenjanjeRadnogVremenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nedovoljnoSatiUTjednuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikaziPodatkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firmeToolStripMenuItem,
            this.prikaziPodatkeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(268, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // firmeToolStripMenuItem
            // 
            this.firmeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alertiToolStripMenuItem,
            this.mjenjanjeRadnogVremenaToolStripMenuItem,
            this.nedovoljnoSatiUTjednuToolStripMenuItem});
            this.firmeToolStripMenuItem.Name = "firmeToolStripMenuItem";
            this.firmeToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.firmeToolStripMenuItem.Text = "Zadatci";
            // 
            // alertiToolStripMenuItem
            // 
            this.alertiToolStripMenuItem.Name = "alertiToolStripMenuItem";
            this.alertiToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.alertiToolStripMenuItem.Text = "Obavjesti o kašnjenu/ranom odlasku";
            this.alertiToolStripMenuItem.Click += new System.EventHandler(this.alertiToolStripMenuItem_Click);
            // 
            // mjenjanjeRadnogVremenaToolStripMenuItem
            // 
            this.mjenjanjeRadnogVremenaToolStripMenuItem.Name = "mjenjanjeRadnogVremenaToolStripMenuItem";
            this.mjenjanjeRadnogVremenaToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.mjenjanjeRadnogVremenaToolStripMenuItem.Text = "Mjenjanje radnog vremena";
            this.mjenjanjeRadnogVremenaToolStripMenuItem.Click += new System.EventHandler(this.mjenjanjeRadnogVremenaToolStripMenuItem_Click);
            // 
            // nedovoljnoSatiUTjednuToolStripMenuItem
            // 
            this.nedovoljnoSatiUTjednuToolStripMenuItem.Name = "nedovoljnoSatiUTjednuToolStripMenuItem";
            this.nedovoljnoSatiUTjednuToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.nedovoljnoSatiUTjednuToolStripMenuItem.Text = "Nedovoljno sati u tjednu";
            this.nedovoljnoSatiUTjednuToolStripMenuItem.Click += new System.EventHandler(this.nedovoljnoSatiUTjednuToolStripMenuItem_Click);
            // 
            // prikaziPodatkeToolStripMenuItem
            // 
            this.prikaziPodatkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatorToolStripMenuItem,
            this.prikazToolStripMenuItem});
            this.prikaziPodatkeToolStripMenuItem.Name = "prikaziPodatkeToolStripMenuItem";
            this.prikaziPodatkeToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.prikaziPodatkeToolStripMenuItem.Text = "Podatci";
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.generatorToolStripMenuItem.Text = "Generator";
            this.generatorToolStripMenuItem.Click += new System.EventHandler(this.generatorToolStripMenuItem_Click);
            // 
            // prikazToolStripMenuItem
            // 
            this.prikazToolStripMenuItem.Name = "prikazToolStripMenuItem";
            this.prikazToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.prikazToolStripMenuItem.Text = "Prikaz";
            this.prikazToolStripMenuItem.Click += new System.EventHandler(this.prikazToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(33, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Odaberi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Unesi ID";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(33, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Unesi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GateLogix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 169);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GateLogix";
            this.Text = "GateLogix";
            this.Load += new System.EventHandler(this.GateLogix_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem firmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikaziPodatkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikazToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem alertiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mjenjanjeRadnogVremenaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nedovoljnoSatiUTjednuToolStripMenuItem;
    }
}

