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
        List<Individu> iBaru;
        List<Gejala> rule;
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
            beliefDgv.Rows.Clear();
            individuDgv.Rows.Clear();
            int popSize = Convert.ToInt32(popSizeBox.Text);
            int iterasi = Convert.ToInt32(iterationBox.Text);
            double cr = Convert.ToDouble(crBox.Text);
            double mr = Convert.ToDouble(mrBox.Text);

            DataTable dt = db.query("SELECT * FROM gejala");

            rule = new List<Gejala>();

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
                string d = Convert.ToString(r["diagnosa"]);
                string[] diagnosa = Array.ConvertAll(d.Split(','), di => di.Trim());
                Kasus k = new Kasus();
                k.SetGejala(gejala);
                k.SetDiagnosa(diagnosa);
                listKasus.Add(k);
            }
            
            de = new Density(rule);
            iBaru = new List<Individu>();
            List<int> index = new List<int>();
            for (int iter = 0; iter < iterasi; iter++)
            {
                // Init
                List<Individu> P;
                Console.WriteLine("Iterasi ke - " + (iter + 1) + " ---------------------------------");
                if (iter == 0)
                {
                    P = new List<Individu>();
                    Console.WriteLine("-- Dempster Shafer Individu --");
                    for (int i = 0; i < popSize; i++)
                    {
                        Console.WriteLine(">> Individu ke - " + (i + 1));
                        Individu inv = new Individu(de.GetDensity());
                        DempsterShafer ds = new DempsterShafer(inv, listKasus);
                        inv.SetFitness(ds.GetFitness());
                        P.Add(inv);
                    }
                }
                else
                {
                    P = iBaru;
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
                iBaru = slct.GetITerbaik();
                index = slct.GetIndex();
            }
            PopulateDgv(rule, iBaru[0]);
            double akurasi = iBaru[0].GetFitness() * 100; 
            labelAkurasi.Text = akurasi.ToString() + " %";

            for (int i = 0; i < iBaru.Count; i++)
            {
                int idIndividu = index[i]+1;
                string kode;
                if ( idIndividu > popSize)
                {
                    idIndividu -= popSize;
                    kode = "C" + idIndividu;
                }
                else
                {
                    kode = "P" + idIndividu;
                }
                this.individuDgv.Rows.Add(kode, iBaru[i].GetFitness());
            }

            MessageBox.Show("Proses Perhitungan Selesai");
        }

        private void PopulateDgv(List<Gejala> rule, Individu terbaik)
        {
            for (int i = 0; i < rule.Count; i++)
            {
                double[] nilaiDensity = terbaik.find(rule[i].GetKodeGejala());
                this.beliefDgv.Rows.Add(rule[i].GetKodeGejala(), nilaiDensity[0], nilaiDensity[1], nilaiDensity[2]);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (beliefDgv.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data yang disimpan!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //save individu baru ke db
                    for (int i = 0; i < rule.Count; i++)
                    {
                        //cek kode gejala
                        string kode_gejala = rule[i].GetKodeGejala();
                        double[] nilaiDensity = iBaru[0].find(rule[i].GetKodeGejala());

                        DataTable ins = db.query("SELECT * FROM individu WHERE kode_gejala = '" + kode_gejala + "'");
                        if (ins.Rows.Count == 0)
                        {
                            string query = "INSERT INTO individu ('kode_gejala', 'pneumonia', 'bronkitis', 'urti') ";
                            query += "VALUES ('"+kode_gejala.ToUpper()+"', " + nilaiDensity[0] + ", " + nilaiDensity[1] + ", " + nilaiDensity[2] + ")";
                            int created = db.nQuery(query);
                        }
                        else
                        {
                            string query = "UPDATE individu ";
                            query += "SET pneumonia = " + nilaiDensity[0];
                            query += ", bronkitis = " + nilaiDensity[1];
                            query += ", urti = " + nilaiDensity[2];
                            query += " WHERE kode_gejala = '" + kode_gejala + "'";
                            int updated = db.nQuery(query);
                        }
                    }
                    MessageBox.Show("Data berhasil disimpan!");
                }
            }
            
        } 
    }
}
