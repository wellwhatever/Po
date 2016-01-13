using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Individu
    {
        private Dictionary<string, double[]> gejala = new Dictionary<string, double[]>();
        private double fitness;

        public Individu(List<Gejala> density)
        {
            for (int i = 0; i < density.Count; i++)
            {
                gejala.Add(density[i].GetKodeGejala(), density[i].GetPenyakit());
            }
        }

        public double[] find(string kodeGejala)
        {
            double[] value;
            if (gejala.TryGetValue(kodeGejala, out value))
            {
               return value;
            }
            return value;
        }

        public void SetFitness(double fitness)
        {
            this.fitness = fitness;
        }

        public double GetFitness()
        {
            return this.fitness;
        }
    }
}
