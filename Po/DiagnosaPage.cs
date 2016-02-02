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
            DataTable dt = db.query("SELECT kode_gejala, nama_gejala FROM gejala WHERE kode_gejala NOT IN ('G15', 'G16', 'G17')");
            foreach (DataRow row in dt.Rows)
            {
                var items = listBoxGejala.Items;
                string item = "(" + Convert.ToString(row["kode_gejala"]) + ") " + Convert.ToString(row["nama_gejala"]);
                items.Add(item);
            }
        }

        private void diagnoseBtn_Click(object sender, EventArgs e)
        {
            List<Kasus> listKasus = new List<Kasus>();
            Kasus input = new Kasus();
            List<string> temp = new List<string>();
            for (int i = 0; i < listBoxGejala.Items.Count; i++)
            {
                if (listBoxGejala.GetItemChecked(i))
                {
                    string str = (string) listBoxGejala.Items[i];
                    temp.Add(str.Split('(', ')')[1]);
                }
            }

            foreach (Control control in this.waktuGroupBox.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        string str = radio.Text;
                        temp.Add(str.Split('(', ')')[1]);
                    }
                }
            }

            string[] gejala = temp.ToArray();
            input.SetGejala(gejala);
            listKasus.Add(input);
            Diagnose(listKasus);
        }

        private void Diagnose(List<Kasus> listKasus)
        {
            DataTable dota = db.query("SELECT * FROM individu");
            List<Gejala> iv = new List<Gejala>();
            foreach (DataRow dr in dota.Rows)
            {
                Gejala g = new Gejala();
                g.SetKodeGejala(Convert.ToString(dr["kode_gejala"]));
                double[] p = new double[3];
                p[0] = Convert.ToDouble(dr["pneumonia"]);
                p[1] = Convert.ToDouble(dr["bronkitis"]);
                p[2] = Convert.ToDouble(dr["urti"]);
                g.SetPenyakit(p);
                iv.Add(g);
            }

            Individu iu = new Individu(iv);
            DempsterShafer ds = new DempsterShafer(iu, listKasus);
            List<Mass> hasilAkhir = ds.GetMFinal();
            int indeksMaks = 0;
            double terbesar = 0;

            for (int x = 0; x < hasilAkhir.Count; x++)
            {
                if (terbesar < hasilAkhir[x].GetDensity())
                {
                    terbesar = hasilAkhir[x].GetDensity();
                    indeksMaks = x;
                }
            }

            List<string> d = hasilAkhir[indeksMaks].GetPenyakit();
            string namaPenyakit = "";
            foreach (string s in d)
            {
                namaPenyakit += GetNamaPenyakit(s) + "\n";
            }
            labelNamaPenyakit.Text = namaPenyakit;

            string nilaiBelief = Convert.ToString(terbesar);
            labelNilaiBelief.Text = nilaiBelief;
            
        }

        private string GetNamaPenyakit(string str)
        {
            switch (str)
            {
                case "P" :
                    return "PNEUMONIA";
                case "B" :
                    return "BRONKITIS";
                case "U" :
                    return "URTI";
                default :
                    return "TIDAK DITEMUKAN";
            }
        }
    }
}
