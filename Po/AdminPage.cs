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
    public partial class AdminPage : Form
    {
        private SqliteDatabase db;
        bool formClosed;
        Density de;
        public AdminPage()
        {
            InitializeComponent();
            db = new SqliteDatabase();
            LoadGejala();
            LoadKasus();
            formClosed = false;
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {

        }

        private void LoadGejala()
        {
            string qr = "SELECT kode_gejala as 'Kode Gejala', nama_gejala as 'Nama Gejala', pneumonia, bronkitis, urti FROM gejala";
            gejalaDgv.DataSource = db.query(qr);
        }

        private void LoadKasus()
        {
            string qr = "SELECT * FROM kasus";
            kasusDgv.DataSource = db.query(qr);
        }

        private void AdminPage_FormClosing(object sender, FormClosingEventArgs e)
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

        private void prosesBtn_Click(object sender, EventArgs e)
        {
            int popSize = Convert.ToInt32(popSizeBox.Text);
            int iterasi = Convert.ToInt32(iterationBox.Text);
            double cr = Convert.ToDouble(crBox.Text);
            double mr = Convert.ToDouble(mrBox.Text);

            DataTable dt = db.query("SELECT * FROM gejala");

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

            DataTable ks = db.query("SELECT * FROM kasus");

            List<Kasus> listKasus = new List<Kasus>();
            foreach (DataRow r in ks.Rows)
            {
                string s = Convert.ToString(r["gejala"]);
                string[] gejala = Array.ConvertAll(s.Split(','), ge => ge.Trim());
                string diagnosa = Convert.ToString(r["diagnosa"]);
                Kasus k = new Kasus();
                k.SetGejala(gejala);
                k.SetDiagnosa(diagnosa);
                listKasus.Add(k);
            }
            
            de = new Density(rule);
            for (int iter = 0; iter < iterasi; iter++)
            {
                Console.WriteLine("Iteasi ke - " + (iter + 1) + " ---------------------------------");
                List<Individu> P = new List<Individu>();
                Console.WriteLine("-- Dempster Shafer Individu --");
                for (int i = 0; i < popSize; i++)
                {
                    Console.WriteLine(">> Individu ke - " + (i + 1));
                    Individu inv = new Individu(de.GetDensity());
                    DempsterShafer ds = new DempsterShafer(inv, listKasus);
                    inv.SetFitness(ds.GetFitness());
                    P.Add(inv);
                }

                List<Individu> C = new List<Individu>();
                CrossOver co = new CrossOver(P, cr, popSize);
                C = co.GetCrossover();

                Console.WriteLine("-- Dempster Shafer Crossover --");
                for (int j = 0; j < C.Count; j++)
                {
                    Console.WriteLine(">> Crossover ke - " + (j + 1));
                    DempsterShafer ds = new DempsterShafer(C[j], listKasus);
                    C[j].SetFitness(ds.GetFitness());
                }

                double minimum = C[0].GetFitness();
                double maximum = 0;
                for (int k = 0; k < C.Count; k++)
                {
                    if (minimum > C[k].GetFitness()) minimum = C[k].GetFitness();
                    if (maximum < C[k].GetFitness()) maximum = C[k].GetFitness();
                }

                double maxmin = maximum - minimum;

                Console.WriteLine("-- Mutasi, Dempster Shafer Mutasi --");
                Mutasi mts = new Mutasi(P, mr, popSize, maxmin, rule);
                C.Add(mts.GetMutasi());
                DempsterShafer dss = new DempsterShafer(C[C.Count - 1], listKasus);
                C[C.Count - 1].SetFitness(dss.GetFitness());

                Console.WriteLine("-- Nilai Fitness Akhir --");
                Selection slct = new Selection(P, C, popSize);
            }
        }
    }
}
