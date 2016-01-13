using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Po
{
    public partial class DiagnosaPage : Form
    {
        bool formClosed;
        SqliteDatabase db;
        public DiagnosaPage()
        {
            InitializeComponent();
            formClosed = false;

            db = new SqliteDatabase();
            loadGejala();
        }

        private void DiagnosaPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (!formClosed)
            {
                this.formClosed = true;
                var home = (Form1)Tag;
                home.Show();
                this.Close();
            }
        }

        private void loadGejala()
        {
            DataTable dt = db.query("SELECT kode_gejala, nama_gejala FROM gejala");
            foreach (DataRow row in dt.Rows)
            {
                var items = listGejala.Items;
                string item = "(" + Convert.ToString(row["kode_gejala"]) + ") " + Convert.ToString(row["nama_gejala"]);
                items.Add(item);
            }
        } 
    }
}
