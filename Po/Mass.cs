using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Mass
    {
        private List<string> penyakit;
        private double density;

        public void SetPenyakit(List<string> penyakit)
        {
            this.penyakit = penyakit;
        }

        public void SetDensity(double density)
        {
            this.density = density;
        }

        public List<string> GetPenyakit()
        {
            return this.penyakit;
        }

        public double GetDensity()
        {
            return this.density;
        }
    }
}