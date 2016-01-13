using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Selection
    {
        public Selection(List<Individu> P, List<Individu> C, int popSize)
        {
            P.AddRange(C);
            List<Individu> std = P.OrderByDescending(f => f.GetFitness()).ToList();
            for (int i = 0; i < popSize; i++)
            {
                Console.WriteLine(std[i].GetFitness());
            }
        }
    }
}
