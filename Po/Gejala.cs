using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class Gejala
    {
        private string kodeGejala;
        private string namaGejala;
        private double pneumonia;
        private double bronkitis;
        private double urti;
        private double[] penyakit;

        public void SetKodeGejala(string kodeGejala)
        {
            this.kodeGejala = kodeGejala;
        }

        public string GetKodeGejala()
        {
            return this.kodeGejala;
        }

        public void SetNamaGejala(string namaGejala)
        {
            this.namaGejala = namaGejala;
        }

        public string GetNamaGejala()
        {
            return this.namaGejala;
        }

        public void SetPneumonia(double pneumonia)
        {
            this.pneumonia = pneumonia;
        }

        public double GetPneumonia()
        {
            return this.pneumonia;
        }

        public void SetBronkitis(double bronkitis)
        {
            this.bronkitis = bronkitis;
        }

        public double GetBronkitis()
        {
            return this.bronkitis;
        }

        public void SetUrti(double urti)
        {
            this.urti = urti;
        }

        public double GetUrti()
        {
            return this.urti;
        }

        public void SetPenyakit(double[] penyakit)
        {
            this.penyakit = penyakit;
        }

        public double[] GetPenyakit()
        {
            return this.penyakit;
        }

        public double GetPenyakitById(int i)
        {
            return this.penyakit[i];
        }
    }
}
