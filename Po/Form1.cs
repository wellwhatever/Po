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
    public partial class Form1 : Form
    {
        private Density de;
        private Individu p1;
        private Individu p2;
        SqliteDatabase db;
        public Form1()
        {
            InitializeComponent();
            db = new SqliteDatabase();
            DataTable dt = new DataTable();
            dt = db.query("SELECT * FROM gejala");

            List<Gejala> rule = new List<Gejala>();

            double[,] cek = {
                {0.534, 0.875, 0.530},
                {0.238, 0.374, 0.573},
                {0.468,	0,	0},
                {0.375,	0.583, 0.384},
                {0,	0.347, 0.474},
                {0.472,	0.582, 0},
                {0,	0.285, 0.372},
                {0,	0.514, 0.572},
                {0.372,	0.512, 0},
                {0.582,	0, 0},
                {0,	0.352, 0},
                {0,	0,	0.235},
                {0.682,	0.235, 0},
                {0,	0.523, 0},
                {0.5325, 0,	0},
                {0.5244, 0.483,	0},
                {0,	0.602, 0.662}
            };

            List<double[]> cok = new List<double[]>();
            for (int z = 0; z < cek.GetLength(0); z++)
            {
                double[] fak = new double[3];
                fak[0] = cek[z, 0];
                fak[1] = cek[z, 1];
                fak[2] = cek[z, 2];
                cok.Add(fak);
            }


                foreach (DataRow row in dt.Rows)
                {
                    Gejala g = new Gejala();
                    double[] p = new double[3];
                    g.SetKodeGejala(Convert.ToString(row["kode_gejala"]));
                    g.SetNamaGejala(Convert.ToString(row["nama_gejala"]));
                    p[0] = Convert.ToDouble(row["pneumonia"]);
                    p[1] = Convert.ToDouble(row["bronkitis"]);
                    p[2] = Convert.ToDouble(row["urti"]);
                    g.SetPenyakit(p);
                    rule.Add(g);
                }

            List<Gejala> pesatu = new List<Gejala>();

            for (int i = 0; i < rule.Count; i++)
            {
                Gejala h = new Gejala();
                h.SetKodeGejala(rule[i].GetKodeGejala());
                h.SetPenyakit(cok[i]);
                pesatu.Add(h);
            }

            de = new Density(rule);
            p1 = new Individu(pesatu);
            p2 = new Individu(de.GetDensity());
        }

        private void randomBtn_Click(object sender, EventArgs e)
        {
            
            //DataTable doto = db.query("SELECT * FROM kasus");
            //List<Kasus> ks = new List<Kasus>();
            //foreach (DataRow r in doto.Rows)
            //{
            //    string s = Convert.ToString(r["gejala"]);
            //    string[] gejala = Array.ConvertAll(s.Split(','), ge => ge.Trim());
            //    string diagnosa = Convert.ToString(r["diagnosa"]);
            //    Kasus k = new Kasus();
            //    k.SetGejala(gejala);
            //    k.SetDiagnosa(diagnosa);
            //    ks.Add(k);
            //}
            //string[] input = { "G2", "G11", "G15", "G3", "G6" };
            //Kasus i = new Kasus();
            //i.SetGejala(input);
            //i.SetDiagnosa("P");
            //List<Kasus> coba = new List<Kasus>();
            //coba.Add(i);
            //DempsterShafer shafer = new DempsterShafer(p1, ks);
            //Console.WriteLine("FITNESS " + shafer.GetFitness());
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            AdminPage am = new AdminPage();
            am.Tag = this;
            am.Show(this);
            Hide();
        }

        private void diagnosaBtn_Click(object sender, EventArgs e)
        {
            DiagnosaPage dp = new DiagnosaPage();
            dp.Tag = this;
            dp.Show(this);
            Hide();
        }

    }
}
