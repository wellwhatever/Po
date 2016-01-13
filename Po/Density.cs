using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Density
    {
        private Random _r = new Random(); 
        private List<Gejala> density = new List<Gejala>();
        private List<Gejala> rule;
        private double minimum = 0;
        private double maximum = 1;

        public Density(List<Gejala> rule)
        {
            this.rule = rule;
        }

        private void GenerateRandom()
        {
            density.Clear();
            for (int i = 0; i < rule.Count; i++)
            {
                Gejala ge = new Gejala();
                ge.SetKodeGejala(rule[i].GetKodeGejala());
                ge.SetNamaGejala(rule[i].GetNamaGejala());
                double[] p = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    if (rule[i].GetPenyakitById(j) == 1)
                    {
                        p[j] = Math.Round(GetRandomNumber(this.minimum, this.maximum), 5);
                    }
                    else
                    {
                        p[j] = 0;
                    }
                }
                ge.SetPenyakit(p);
                density.Add(ge);
            }
        }

        public void setMinMax(double min, double max)
        {
            this.minimum = min;
            this.maximum = max;
        }

        public List<Gejala> GetDensity()
        {
            GenerateRandom();
            return this.density;
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            return _r.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
