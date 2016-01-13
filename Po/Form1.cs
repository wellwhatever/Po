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

            de = new Density(rule);
            p1 = new Individu(de.GetDensity());
            p2 = new Individu(de.GetDensity());
        }

        private void randomBtn_Click(object sender, EventArgs e)
        {
            
            DataTable doto = db.query("SELECT * FROM kasus");
            List<Kasus> ks = new List<Kasus>();
            foreach (DataRow r in doto.Rows)
            {
                string s = Convert.ToString(r["gejala"]);
                string[] gejala = Array.ConvertAll(s.Split(','), ge => ge.Trim());
                string diagnosa = Convert.ToString(r["diagnosa"]);
                //foreach (string g in gejala)
                //{
                //    double[] d1 = p1.find(g);
                //    Console.Write(g + " ");
                //    for (int i = 0; i < d1.Length; i++)
                //    {
                //        Console.Write(d1[i] + " ");
                //    }
                //    Console.WriteLine();

                //}
                //Console.WriteLine();
                Kasus k = new Kasus();
                k.SetGejala(gejala);
                k.SetDiagnosa(diagnosa);
                ks.Add(k);
            }
            string[] input = { "G2", "G11", "G15", "G3", "G6" };
            Kasus i = new Kasus();
            i.SetGejala(input);
            i.SetDiagnosa("P");
            List<Kasus> coba = new List<Kasus>();
            coba.Add(i);
            DempsterShafer shafer = new DempsterShafer(p1, coba);
            Console.WriteLine("FITNESS " + shafer.GetFitness());
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
