using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Po
{
    class CrossOver
    {
        Random _r = new Random();
        List<Gejala> rule;
        List<Individu> crossover;

        public CrossOver(List<Individu> individu, double crossrate, int popSize)
        {
            double offspring = crossrate * (double) popSize;
            offspring = Math.Floor(offspring);

            SqliteDatabase db = new SqliteDatabase();

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

            Density de = new Density(rule);
            de.setMinMax(-0.25, 0.25);
            Individu alpha = new Individu(de.GetDensity());

            crossover = new List<Individu>();

            int[] randomIndividu = generateNumber(individu.Count);
            int offset = 0;
            while (crossover.Count < offspring)
            {
                List<Gejala> c = new List<Gejala>();
                c = Cross(individu[offset], individu[offset + 1], alpha);
                Individu v = new Individu(c);
                crossover.Add(v);

                if (crossover.Count < offspring)
                {
                    c = Cross(individu[offset + 1], individu[offset], alpha);
                    Individu v2 = new Individu(c);
                    crossover.Add(v2);
                    offset = offset + 2;
                }    
            }
            
        }

        private int[] shuffle(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(_r.NextDouble() * (n - i));
                int t = array[r];
                array[r] = array[i];
                array[i] = t;
            }

            return array;
        }

        private int[] generateNumber(int N)
        {
            int[] number = new int[N];

            for (int i = 0; i < N; i++)
            {
                number[i] = i + 1;
            }

            number = shuffle(number);

            return number;
        }

        private int GetRandomIndex(int jumlahIndividu)
        {
            int i = _r.Next(0, jumlahIndividu - 1);
            return i;
        }

        private List<Gejala> Cross(Individu a, Individu b, Individu alpha)
        {
            List<Gejala> hasilKross = new List<Gejala>();
            for (int i = 0; i < rule.Count; i++)
            {
                Gejala g = new Gejala();
                double[] aDen = a.find(rule[i].GetKodeGejala());
                double[] bDen = b.find(rule[i].GetKodeGejala());
                double[] alphaden = alpha.find(rule[i].GetKodeGejala());
                double[] hasil = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    hasil[j] = aDen[j] + alphaden[j] * (bDen[j] - aDen[j]);
                }

                g.SetKodeGejala(rule[i].GetKodeGejala());
                g.SetPenyakit(hasil);

                hasilKross.Add(g);
            }

            return hasilKross;
        }

        public List<Individu> GetCrossover()
        {
            return this.crossover;
        }


    }
}
