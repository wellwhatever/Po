using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Mutasi
    {
        Random _r = new Random();
        Individu hasilMutasi;
        List<Gejala> rule;
        public Mutasi(List<Individu> individu, double mutasiRate, int popSize, double maxmin, List<Gejala> rule)
        {
            this.rule = rule;
            double offspring = mutasiRate * (double)popSize;
            offspring = Math.Floor(offspring);

            List<Gejala> g = new List<Gejala>();

            int randomIndividu = GetRandomIndex(individu.Count);
            int randomGejala = GetRandomIndex(rule.Count);
            int randomPenyakit = GetRandomIndex(3);

            double r = GetRandomNumber(-0.1, 0.1);
            
            double[] gen = individu[randomIndividu].find(rule[randomGejala].GetKodeGejala());
            gen[randomPenyakit] = gen[randomPenyakit] + (r * maxmin);

            for (int i = 0; i < rule.Count; i++)
            {
                Gejala gg = new Gejala();
                gg.SetKodeGejala(rule[i].GetKodeGejala());
                if (i == randomGejala)
                {
                    gg.SetPenyakit(gen);
                }
                else
                {
                    gg.SetPenyakit(rule[i].GetPenyakit());
                }

                g.Add(gg);
            }
            
            hasilMutasi = new Individu(g);

        }

        private int GetRandomIndex(int jumlahIndividu)
        {
            int index;
            index = _r.Next(0, jumlahIndividu - 1);

            return index;
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            return _r.NextDouble() * (maximum - minimum) + minimum;
        }

        public Individu GetMutasi()
        {
            return this.hasilMutasi;
        }
    }
}
