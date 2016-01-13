namespace Po
{
    partial class Form1
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
            this.randomBtn = new System.Windows.Forms.Button();
            this.diagnosaBtn = new System.Windows.Forms.Button();
            this.adminBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // randomBtn
            // 
            this.randomBtn.Location = new System.Drawing.Point(389, 13);
            this.randomBtn.Name = "randomBtn";
            this.randomBtn.Size = new System.Drawing.Size(75, 23);
            this.randomBtn.TabIndex = 0;
            this.randomBtn.Text = "Random";
            this.randomBtn.UseVisualStyleBackColor = true;
            this.randomBtn.Click += new System.EventHandler(this.randomBtn_Click);
            // 
            // diagnosaBtn
            // 
            this.diagnosaBtn.Location = new System.Drawing.Point(13, 42);
            this.diagnosaBtn.Name = "diagnosaBtn";
            this.diagnosaBtn.Size = new System.Drawing.Size(217, 94);
            this.diagnosaBtn.TabIndex = 1;
            this.diagnosaBtn.Text = "Diagnosa";
            this.diagnosaBtn.UseVisualStyleBackColor = true;
            this.diagnosaBtn.Click += new System.EventHandler(this.diagnosaBtn_Click);
            // 
            // adminBtn
            // 
            this.adminBtn.Location = new System.Drawing.Point(247, 42);
            this.adminBtn.Name = "adminBtn";
            this.adminBtn.Size = new System.Drawing.Size(217, 94);
            this.adminBtn.TabIndex = 2;
            this.adminBtn.Text = "Halaman Admin";
            this.adminBtn.UseVisualStyleBackColor = true;
            this.adminBtn.Click += new System.EventHandler(this.adminBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 148);
            this.Controls.Add(this.adminBtn);
            this.Controls.Add(this.diagnosaBtn);
            this.Controls.Add(this.randomBtn);
            this.Name = "Form1";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button randomBtn;
        private System.Windows.Forms.Button diagnosaBtn;
        private System.Windows.Forms.Button adminBtn;
    }
}

