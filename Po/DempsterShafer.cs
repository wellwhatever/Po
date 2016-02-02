using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Po
{
    class DempsterShafer
    {
        private Individu individu;
        private double[,] mass;
        private List<Kasus> data;
        private double fitness;
        private int counter = 0;
        private List<Mass> mFinal;

        public DempsterShafer(Individu individu, List<Kasus> data)
        {
            this.individu = individu;
            this.data = data;

            for (int i = 0; i < data.Count; i++)
            {
                Console.Write("Kasus " + (i + 1) + " | ");
                string[] gejala = data[i].GetGejala();
                int jumlahM = (gejala.Length*2)-1;
                List<List<Mass>> Masses = new List<List<Mass>>();
                int mCounter = 0;

                for (int j = 0; j < gejala.Length; j++)
                {
                    double[] nilaiGejala = individu.find(gejala[j]);
                    double max = GetMaximumDensity(nilaiGejala); // max jadi nilai m  
                    if (max == 1)
                    {
                        Mass m = new Mass();
                        m.SetPenyakit(GetKodePenyakit(nilaiGejala));
                        m.SetDensity(max);
                     
                        if(m.GetPenyakit().Contains(data[i].GetDiagnosa())) {
                            counter++;
                        }
                        break;
                    }
                    //Console.WriteLine(gejala[j] + " " + max);
                    List<string> sTheta = new List<string>() { "theta" };
                    if (j == 0) { // gejala pertama 
                        List<Mass> M = new List<Mass>();

                        Mass m = new Mass();
                        m.SetPenyakit(GetKodePenyakit(nilaiGejala));
                        m.SetDensity(max);
                        M.Add(m);
                        
                        Mass mTheta = new Mass();
                        mTheta.SetPenyakit(sTheta);
                        mTheta.SetDensity(GetTheta(max));

                        M.Add(mTheta);

                        Masses.Add(M); // m1
                        //mCounter = 0;
                    } else { // gejala ke-2 dst
                        //Console.WriteLine("Gejala ke- " + gejala[j]);

                        List<Mass> M = new List<Mass>();

                        Mass m = new Mass();
                        m.SetPenyakit(GetKodePenyakit(nilaiGejala));
                        m.SetDensity(max);
                        M.Add(m);

                        //DebugString(m.GetPenyakit());

                        Mass mTheta = new Mass();
                        mTheta.SetPenyakit(sTheta);
                        mTheta.SetDensity(GetTheta(max));

                        M.Add(mTheta);

                        Masses.Add(M);
                        mCounter++;

                        List<Mass> matriksKombinasi = new List<Mass>();

                        matriksKombinasi = CombineMass(Masses[mCounter - 1], Masses[mCounter]);
                        List<Mass> mBaru = GetMassBaru(matriksKombinasi);

                        Masses.Add(mBaru);
                        mCounter++;
                        //Console.WriteLine(mCounter + " " + mBaru[mBaru.Count-1].GetDensity());
                        
                    }
                    
                }
                // ambil dari m yang terakhir, nilai yg terbesar
                // bandingkan diagnosa pakar dg hasil (intersect)
                // count+1 kalo ada;

                mFinal = Masses[mCounter];
                int indeksMaks = 0;
                double terbesar = 0;
                                
                for (int x = 0; x < mFinal.Count; x++)
                {
                    if (terbesar < mFinal[x].GetDensity())
                    {
                        terbesar = mFinal[x].GetDensity();
                        indeksMaks = x;
                    }
                }

                List<string> d = mFinal[indeksMaks].GetPenyakit();

                DebugString(d);
                Console.Write(" | Nilai Belief : " + terbesar);
                Console.WriteLine();


                if (d.Contains(data[i].GetDiagnosa()))
                {
                    counter++;
                }
                //Console.WriteLine();
            }
        }

        private double GetTheta(double maximumDensity)
        {
            return 1 - maximumDensity;
        }

        private List<Mass> CombineMass(List<Mass> a, List<Mass> b)
        {
            List<Mass> hasilKombinasi = new List<Mass>();
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < b.Count; j++)
                {
                    Mass hasilKali = new Mass();
                    hasilKali.SetPenyakit(GetIntersection(a[i].GetPenyakit(), b[j].GetPenyakit()));
                    hasilKali.SetDensity(Math.Round((a[i].GetDensity() * b[j].GetDensity()), 3));
                    //Console.WriteLine(a[i].GetDensity() + " * " + b[j].GetDensity() + " = " + hasilKali.GetDensity());
                    hasilKombinasi.Add(hasilKali);
                }
            }
            //Console.WriteLine("--");
            return hasilKombinasi;
        }

        private double GetMaximumDensity(double[] array)
        {
            return array.Max();
        }

        private List<string> GetKodePenyakit(double[] dens)
        {
            List<string> kodePenyakit = new List<string>();
            if (dens[0] != 0) kodePenyakit.Add("P");
            if (dens[1] != 0) kodePenyakit.Add("B");
            if (dens[2] != 0) kodePenyakit.Add("U");
            return kodePenyakit;
        }

        private List<string> GetIntersection(List<string> a, List<string> b)
        {
            List<string> intersection = new List<string>();
            if (!a.Contains("theta") && !b.Contains("theta"))
            {
                intersection = a.Intersect(b, StringComparer.OrdinalIgnoreCase).ToList();
                if (intersection.Count == 0)
                {
                    intersection.Add("kosong");
                }
            }
            else if(!a.Contains("theta") && b.Contains("theta"))
            {
                intersection = a;
            }
            else if (a.Contains("theta") && !b.Contains("theta"))
            {
                intersection = b;
            }
            else if (a.Contains("theta") && b.Contains("theta"))
            {
                intersection = a;
            }

            return intersection;
        }

        private List<Mass> GetMassBaru(List<Mass> mK)
        {
            List<Mass> mBaru = new List<Mass>();
            List<int> indeksOfMass = new List<int>();
            double pembagi = 0;
            double pembilang = 0;
            // bool kosong = false;

            for (int i = 0; i < mK.Count; i++)
            {
                if(indeksOfMass.Contains(i)) continue; // lanjut ke i berikutnya kalo indeks ke-i udah diperiksa di j
                indeksOfMass.Add(i);
                
                //Console.Write("indeks ke-" + i + " ");
                //DebugString(mK[i].GetPenyakit());
                //Console.WriteLine();

                if (mK[i].GetPenyakit().Contains("kosong"))
                {
                    pembagi = mK[i].GetDensity();
                }
                else
                {
                    pembilang = mK[i].GetDensity();
                }
                
                
                for (int j = i + 1; j < mK.Count; j++)
                {                
                    var a = mK[i].GetPenyakit(); 
                    var b = mK[j].GetPenyakit();

                    if(b.Contains("kosong")){
                        pembagi += mK[j].GetDensity();
                        indeksOfMass.Add(j);
                    } else {
                        //var intersect = a.Intersect(b, StringComparer.OrdinalIgnoreCase).ToList();
                        if (IsEqual(a, b))
                        {
                            pembilang += mK[j].GetDensity();
                            indeksOfMass.Add(j);
                        }
                    }
                }

                if (!mK[i].GetPenyakit().Contains("kosong"))
                {
                    //DebugString(mK[i].GetPenyakit());
                    //Console.WriteLine(pembilang + " / (1 - " + pembagi + ") ");

                    Mass mm = new Mass();
                    mm.SetPenyakit(mK[i].GetPenyakit());
                    double nDensity = pembilang / (1 - pembagi);
                    mm.SetDensity(Math.Round(nDensity, 5));

                    mBaru.Add(mm);
                }
                
            }
            //Console.WriteLine("------------------------------");
            return mBaru;

        }

        public double GetFitness()
        {
            fitness = (double) counter / (double) data.Count;
            return Math.Round(fitness, 5);
        }

        private bool IsEqual(List<string> a, List<string> b)
        {
            string s1 = "";
            string s2 = "";

            foreach (string s in a)
            {
                s1 += s;
            }

            foreach (string s in b)
            {
                s2 += s;
            }

            if ((a.Count == b.Count) && s1.Equals(s2))
            {
                return true;
            }

            return false;
        }

        private void DebugString(List<string> list){
            foreach (string s in list)
            {
                Console.Write(s + " ");
            }
        }

        public List<Mass> GetMFinal()
        {
            return this.mFinal;
        }
    }
}
