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
            this.listGejala = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // listGejala
            // 
            this.listGejala.ColumnWidth = 200;
            this.listGejala.FormattingEnabled = true;
            this.listGejala.Location = new System.Drawing.Point(13, 13);
            this.listGejala.MultiColumn = true;
            this.listGejala.Name = "listGejala";
            this.listGejala.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listGejala.Size = new System.Drawing.Size(336, 184);
            this.listGejala.TabIndex = 0;
            // 
            // DiagnosaPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 401);
            this.Controls.Add(this.listGejala);
            this.Name = "DiagnosaPage";
            this.Text = "DiagnosaPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiagnosaPage_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listGejala;
    }
}