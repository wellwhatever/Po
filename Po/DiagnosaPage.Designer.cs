namespace Po
{
    partial class DiagnosaPage
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
            this.listBoxGejala = new System.Windows.Forms.CheckedListBox();
            this.diagnoseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNamaPenyakit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNilaiBelief = new System.Windows.Forms.Label();
            this.hasilTextBox = new System.Windows.Forms.RichTextBox();
            this.waktuGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.waktuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxGejala
            // 
            this.listBoxGejala.CheckOnClick = true;
            this.listBoxGejala.ColumnWidth = 220;
            this.listBoxGejala.FormattingEnabled = true;
            this.listBoxGejala.Location = new System.Drawing.Point(13, 13);
            this.listBoxGejala.MultiColumn = true;
            this.listBoxGejala.Name = "listBoxGejala";
            this.listBoxGejala.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxGejala.Size = new System.Drawing.Size(336, 259);
            this.listBoxGejala.TabIndex = 0;
            // 
            // diagnoseBtn
            // 
            this.diagnoseBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnoseBtn.Location = new System.Drawing.Point(13, 339);
            this.diagnoseBtn.Name = "diagnoseBtn";
            this.diagnoseBtn.Size = new System.Drawing.Size(336, 50);
            this.diagnoseBtn.TabIndex = 1;
            this.diagnoseBtn.Text = "PROSES";
            this.diagnoseBtn.UseVisualStyleBackColor = true;
            this.diagnoseBtn.Click += new System.EventHandler(this.diagnoseBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hasil Indikasi :";
            // 
            // labelNamaPenyakit
            // 
            this.labelNamaPenyakit.AutoSize = true;
            this.labelNamaPenyakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaPenyakit.Location = new System.Drawing.Point(352, 253);
            this.labelNamaPenyakit.Name = "labelNamaPenyakit";
            this.labelNamaPenyakit.Size = new System.Drawing.Size(0, 24);
            this.labelNamaPenyakit.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dengan nilai belief sebesar :";
            // 
            // labelNilaiBelief
            // 
            this.labelNilaiBelief.AutoSize = true;
            this.labelNilaiBelief.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNilaiBelief.Location = new System.Drawing.Point(547, 352);
            this.labelNilaiBelief.Name = "labelNilaiBelief";
            this.labelNilaiBelief.Size = new System.Drawing.Size(0, 20);
            this.labelNilaiBelief.TabIndex = 6;
            // 
            // hasilTextBox
            // 
            this.hasilTextBox.Location = new System.Drawing.Point(356, 13);
            this.hasilTextBox.Name = "hasilTextBox";
            this.hasilTextBox.Size = new System.Drawing.Size(303, 217);
            this.hasilTextBox.TabIndex = 7;
            this.hasilTextBox.Text = "";
            // 
            // waktuGroupBox
            // 
            this.waktuGroupBox.Controls.Add(this.radioButton3);
            this.waktuGroupBox.Controls.Add(this.radioButton2);
            this.waktuGroupBox.Controls.Add(this.radioButton1);
            this.waktuGroupBox.Location = new System.Drawing.Point(13, 279);
            this.waktuGroupBox.Name = "waktuGroupBox";
            this.waktuGroupBox.Size = new System.Drawing.Size(336, 54);
            this.waktuGroupBox.TabIndex = 8;
            this.waktuGroupBox.TabStop = false;
            this.waktuGroupBox.Text = "Waktu";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "(G15) > 10 hari";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(122, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(101, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "(G16) 7 - 10 hari";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(236, 20);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(95, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "(G17) 2 - 7 hari";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // DiagnosaPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 401);
            this.Controls.Add(this.waktuGroupBox);
            this.Controls.Add(this.hasilTextBox);
            this.Controls.Add(this.labelNilaiBelief);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNamaPenyakit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diagnoseBtn);
            this.Controls.Add(this.listBoxGejala);
            this.Name = "DiagnosaPage";
            this.Text = "DiagnosaPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiagnosaPage_FormClosing);
            this.waktuGroupBox.ResumeLayout(false);
            this.waktuGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listBoxGejala;
        private System.Windows.Forms.Button diagnoseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNamaPenyakit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNilaiBelief;
        private System.Windows.Forms.RichTextBox hasilTextBox;
        private System.Windows.Forms.GroupBox waktuGroupBox;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}