namespace Po
{
    partial class AdminPage
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
            this.adminTab = new System.Windows.Forms.TabControl();
            this.tabRule = new System.Windows.Forms.TabPage();
            this.gejalaDgv = new System.Windows.Forms.DataGridView();
            this.tabKasus = new System.Windows.Forms.TabPage();
            this.kasusDgv = new System.Windows.Forms.DataGridView();
            this.tabPengujian = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.saveBtn = new System.Windows.Forms.Button();
            this.beliefDgv = new System.Windows.Forms.DataGridView();
            this.kode_gejala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pneumonia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bronkitis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.individuDgv = new System.Windows.Forms.DataGridView();
            this.individu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fitness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prosesBtn = new System.Windows.Forms.Button();
            this.iterationBox = new System.Windows.Forms.TextBox();
            this.mrBox = new System.Windows.Forms.TextBox();
            this.crBox = new System.Windows.Forms.TextBox();
            this.popSizeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAkurasi = new System.Windows.Forms.Label();
            this.adminTab.SuspendLayout();
            this.tabRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gejalaDgv)).BeginInit();
            this.tabKasus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kasusDgv)).BeginInit();
            this.tabPengujian.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beliefDgv)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.individuDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // adminTab
            // 
            this.adminTab.Controls.Add(this.tabRule);
            this.adminTab.Controls.Add(this.tabKasus);
            this.adminTab.Controls.Add(this.tabPengujian);
            this.adminTab.Location = new System.Drawing.Point(13, 13);
            this.adminTab.Name = "adminTab";
            this.adminTab.SelectedIndex = 0;
            this.adminTab.Size = new System.Drawing.Size(671, 364);
            this.adminTab.TabIndex = 0;
            // 
            // tabRule
            // 
            this.tabRule.Controls.Add(this.gejalaDgv);
            this.tabRule.Location = new System.Drawing.Point(4, 22);
            this.tabRule.Name = "tabRule";
            this.tabRule.Padding = new System.Windows.Forms.Padding(3);
            this.tabRule.Size = new System.Drawing.Size(663, 338);
            this.tabRule.TabIndex = 0;
            this.tabRule.Text = "Rule Gejala";
            this.tabRule.UseVisualStyleBackColor = true;
            // 
            // gejalaDgv
            // 
            this.gejalaDgv.AllowUserToAddRows = false;
            this.gejalaDgv.AllowUserToDeleteRows = false;
            this.gejalaDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gejalaDgv.Location = new System.Drawing.Point(7, 7);
            this.gejalaDgv.Name = "gejalaDgv";
            this.gejalaDgv.ReadOnly = true;
            this.gejalaDgv.Size = new System.Drawing.Size(416, 325);
            this.gejalaDgv.TabIndex = 0;
            // 
            // tabKasus
            // 
            this.tabKasus.Controls.Add(this.kasusDgv);
            this.tabKasus.Location = new System.Drawing.Point(4, 22);
            this.tabKasus.Name = "tabKasus";
            this.tabKasus.Padding = new System.Windows.Forms.Padding(3);
            this.tabKasus.Size = new System.Drawing.Size(663, 338);
            this.tabKasus.TabIndex = 1;
            this.tabKasus.Text = "Kasus";
            this.tabKasus.UseVisualStyleBackColor = true;
            // 
            // kasusDgv
            // 
            this.kasusDgv.AllowUserToAddRows = false;
            this.kasusDgv.AllowUserToDeleteRows = false;
            this.kasusDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kasusDgv.Location = new System.Drawing.Point(7, 7);
            this.kasusDgv.Name = "kasusDgv";
            this.kasusDgv.ReadOnly = true;
            this.kasusDgv.Size = new System.Drawing.Size(357, 325);
            this.kasusDgv.TabIndex = 0;
            // 
            // tabPengujian
            // 
            this.tabPengujian.Controls.Add(this.tabControl1);
            this.tabPengujian.Controls.Add(this.prosesBtn);
            this.tabPengujian.Controls.Add(this.iterationBox);
            this.tabPengujian.Controls.Add(this.mrBox);
            this.tabPengujian.Controls.Add(this.crBox);
            this.tabPengujian.Controls.Add(this.popSizeBox);
            this.tabPengujian.Controls.Add(this.label4);
            this.tabPengujian.Controls.Add(this.label3);
            this.tabPengujian.Controls.Add(this.label2);
            this.tabPengujian.Controls.Add(this.label1);
            this.tabPengujian.Location = new System.Drawing.Point(4, 22);
            this.tabPengujian.Name = "tabPengujian";
            this.tabPengujian.Padding = new System.Windows.Forms.Padding(3);
            this.tabPengujian.Size = new System.Drawing.Size(663, 338);
            this.tabPengujian.TabIndex = 2;
            this.tabPengujian.Text = "Pengujian";
            this.tabPengujian.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(193, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 320);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelAkurasi);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.saveBtn);
            this.tabPage1.Controls.Add(this.beliefDgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hasil Belief Optimal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(260, 267);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(190, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save to Database";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // beliefDgv
            // 
            this.beliefDgv.AllowUserToAddRows = false;
            this.beliefDgv.AllowUserToDeleteRows = false;
            this.beliefDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beliefDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kode_gejala,
            this.pneumonia,
            this.bronkitis,
            this.urti});
            this.beliefDgv.Location = new System.Drawing.Point(4, 4);
            this.beliefDgv.Name = "beliefDgv";
            this.beliefDgv.ReadOnly = true;
            this.beliefDgv.Size = new System.Drawing.Size(446, 256);
            this.beliefDgv.TabIndex = 0;
            // 
            // kode_gejala
            // 
            this.kode_gejala.HeaderText = "KODE GEJALA";
            this.kode_gejala.Name = "kode_gejala";
            this.kode_gejala.ReadOnly = true;
            // 
            // pneumonia
            // 
            this.pneumonia.HeaderText = "PNEUMONIA";
            this.pneumonia.Name = "pneumonia";
            this.pneumonia.ReadOnly = true;
            // 
            // bronkitis
            // 
            this.bronkitis.HeaderText = "BRONKITIS";
            this.bronkitis.Name = "bronkitis";
            this.bronkitis.ReadOnly = true;
            // 
            // urti
            // 
            this.urti.HeaderText = "URTI";
            this.urti.Name = "urti";
            this.urti.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.individuDgv);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(456, 294);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generasi Terakhir";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // individuDgv
            // 
            this.individuDgv.AllowUserToAddRows = false;
            this.individuDgv.AllowUserToDeleteRows = false;
            this.individuDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.individuDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.individu,
            this.fitness});
            this.individuDgv.Location = new System.Drawing.Point(4, 6);
            this.individuDgv.Name = "individuDgv";
            this.individuDgv.ReadOnly = true;
            this.individuDgv.Size = new System.Drawing.Size(246, 285);
            this.individuDgv.TabIndex = 0;
            // 
            // individu
            // 
            this.individu.HeaderText = "Individu";
            this.individu.Name = "individu";
            this.individu.ReadOnly = true;
            // 
            // fitness
            // 
            this.fitness.HeaderText = "Nilai Fitness";
            this.fitness.Name = "fitness";
            this.fitness.ReadOnly = true;
            // 
            // prosesBtn
            // 
            this.prosesBtn.Location = new System.Drawing.Point(112, 120);
            this.prosesBtn.Name = "prosesBtn";
            this.prosesBtn.Size = new System.Drawing.Size(75, 23);
            this.prosesBtn.TabIndex = 8;
            this.prosesBtn.Text = "Proses";
            this.prosesBtn.UseVisualStyleBackColor = true;
            this.prosesBtn.Click += new System.EventHandler(this.prosesBtn_Click);
            // 
            // iterationBox
            // 
            this.iterationBox.Location = new System.Drawing.Point(87, 94);
            this.iterationBox.Name = "iterationBox";
            this.iterationBox.Size = new System.Drawing.Size(100, 20);
            this.iterationBox.TabIndex = 7;
            // 
            // mrBox
            // 
            this.mrBox.Location = new System.Drawing.Point(87, 67);
            this.mrBox.Name = "mrBox";
            this.mrBox.Size = new System.Drawing.Size(100, 20);
            this.mrBox.TabIndex = 6;
            // 
            // crBox
            // 
            this.crBox.Location = new System.Drawing.Point(87, 40);
            this.crBox.Name = "crBox";
            this.crBox.Size = new System.Drawing.Size(100, 20);
            this.crBox.TabIndex = 5;
            // 
            // popSizeBox
            // 
            this.popSizeBox.Location = new System.Drawing.Point(87, 12);
            this.popSizeBox.Name = "popSizeBox";
            this.popSizeBox.Size = new System.Drawing.Size(100, 20);
            this.popSizeBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Maks Iterasi";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pop Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mutation Rate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cross Rate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hasil Akurasi : ";
            // 
            // labelAkurasi
            // 
            this.labelAkurasi.AutoSize = true;
            this.labelAkurasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAkurasi.Location = new System.Drawing.Point(87, 267);
            this.labelAkurasi.Name = "labelAkurasi";
            this.labelAkurasi.Size = new System.Drawing.Size(0, 20);
            this.labelAkurasi.TabIndex = 3;
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 389);
            this.Controls.Add(this.adminTab);
            this.Name = "AdminPage";
            this.Text = "AdminPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminPage_FormClosing);
            this.Load += new System.EventHandler(this.AdminPage_Load);
            this.adminTab.ResumeLayout(false);
            this.tabRule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gejalaDgv)).EndInit();
            this.tabKasus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kasusDgv)).EndInit();
            this.tabPengujian.ResumeLayout(false);
            this.tabPengujian.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beliefDgv)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.individuDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl adminTab;
        private System.Windows.Forms.TabPage tabRule;
        private System.Windows.Forms.TabPage tabKasus;
        private System.Windows.Forms.DataGridView gejalaDgv;
        private System.Windows.Forms.DataGridView kasusDgv;
        private System.Windows.Forms.TabPage tabPengujian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iterationBox;
        private System.Windows.Forms.TextBox mrBox;
        private System.Windows.Forms.TextBox crBox;
        private System.Windows.Forms.TextBox popSizeBox;
        private System.Windows.Forms.Button prosesBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView beliefDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kode_gejala;
        private System.Windows.Forms.DataGridViewTextBoxColumn pneumonia;
        private System.Windows.Forms.DataGridViewTextBoxColumn bronkitis;
        private System.Windows.Forms.DataGridViewTextBoxColumn urti;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView individuDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn individu;
        private System.Windows.Forms.DataGridViewTextBoxColumn fitness;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label labelAkurasi;
        private System.Windows.Forms.Label label5;
    }
}