using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Selection
    {
        List<Individu> sorted;
        List<int> index;
        List<Individu> iTerbaik;
        public Selection(List<Individu> P, List<Individu> C, int popSize)
        {
            P.AddRange(C);
            //List<Individu> std = P.OrderByDescending(f => f.GetFitness()).ToList();
            sort(P);
            iTerbaik = new List<Individu>();
            for (int i = 0; i < popSize; i++)
            {
                int idIndividu = index[i]+1;
                if ( idIndividu > popSize)
                {
                    idIndividu -= popSize;
                    Console.Write("C" + idIndividu + " | ");
                }
                else
                {
                    Console.Write("P" + idIndividu + " | ");
                }
                Console.WriteLine(P[index[i]].GetFitness());
                iTerbaik.Add(P[index[i]]);
            }
        }

        private void sort(List<Individu> listIndividu)
        {
            var std = listIndividu
                        .Select((x, i) => new KeyValuePair<Individu, int>(x, i))
                        .OrderByDescending(x => x.Key.GetFitness())
                        .ToList();
            sorted = std.Select(x => x.Key).ToList();
            index = std.Select(x => x.Value).ToList();
        }

        public List<Individu> GetITerbaik()
        {
            return this.iTerbaik;
        }

        public List<int> GetIndex()
        {
            return this.index;
        }
    }
}
