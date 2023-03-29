using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Remont
    {
        private double n;
        private double w;
        private double l;
        private double m;
        private double o;
        double neobhodimiPlochki = 0;
        public Remont(double n, double w, double l, double m, double o)
        {
            N = n;
            W = w;
            L = l;
            M = m;
            O = o;
        }
        public double N
        {
            get { return this.n; }
            set
            {
                if (value <0 || value > 1000)
                {
                    Console.WriteLine("Invalid n");
                }
                else
                {
                    this.n = value;
                }
            }
        }
        public double W
        {
            get { return this.w; }
            set
            {
                if (value < 0.1 || value > 10.00)
                {
                    Console.WriteLine("Invalid w");
                }
                else
                {
                    this.w = value;
                }
            }
        }
        public double L
        {
            get { return this.l; }
            set
            {
                if (value < 0.1 || value > 10.00)
                {
                    Console.WriteLine("Invalid l");
                }
                else
                {
                    this.l = value;
                }
            }
        }
        public double M
        {
            get { return this.m; }
            set
            {
                if (value < 0 || value > 10)
                {
                    Console.WriteLine("Invalid m");
                }
                else
                {
                    this.m = value;
                }
            }
        }
        public double O
        {
            get { return this.o; }
            set
            {
                if (value < 0 || value > 10)
                {
                    Console.WriteLine("Invalid o");
                }
                else
                {
                    this.o = value;
                }
            }
        }
        public double CalculatorPlochki()
        {
            double peika = this.M * this.O; //plosht na peikata
            double ploshtadka = this.N * this.N; //plosht na ploshtadkata
            double plochki = this.W * this.L; //plosht na plochkite

            neobhodimiPlochki = (ploshtadka - peika) / plochki;

            return neobhodimiPlochki;
        }
        public double CalculateTime()
        {
            double wreme = 0;
            wreme = neobhodimiPlochki * 0.2;
            return wreme;
        }
    }
}
