using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Kasus
    {
        private string[] gejala;
        private string diagnosa;

        public void SetGejala(string[] gejala)
        {
            this.gejala = gejala;
        }

        public string[] GetGejala()
        {
            return this.gejala;
        }

        public string GetGejalaById(int i)
        {
            return this.gejala[i];
        }

        public void SetDiagnosa(string diagnosa)
        {
            this.diagnosa = diagnosa;
        }

        public string GetDiagnosa()
        {
            return this.diagnosa;
        }
    }
}
