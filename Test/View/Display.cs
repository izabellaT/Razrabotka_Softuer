using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.View
{
    public class Display
    {
        public double N { get; set; }
        public double W { get; set; }
        public double L { get; set; }
        public double M { get; set; }
        public double O { get; set; }
        public double NeobhodimiPochki { get; set; }
        public double Wreme { get; set; }
        public Display()
        {
            N = 0;
            W = 0;
            L = 0;
            M = 0;
            O = 0;
            NeobhodimiPochki = 0;
            Wreme = 0;
            GetValues();
        }
        public void GetValues()
        {
            N = double.Parse(Console.ReadLine());
            W = double.Parse(Console.ReadLine());
            L = double.Parse(Console.ReadLine());
            M = double.Parse(Console.ReadLine());
            O = double.Parse(Console.ReadLine());
        }
        public void ShowResults()
        {
            Console.WriteLine(NeobhodimiPochki);
            Console.WriteLine(Wreme);
        }
    }
}
