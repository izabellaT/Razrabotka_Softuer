using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.View;

namespace Test.Controllers
{
    public class PlochkiController
    {
        private Remont remont;
        private Display display;
        public PlochkiController()
        {
            display = new Display();
            remont = new Remont(display.N, display.W, display.L, display.M, display.O);
            display.NeobhodimiPochki = remont.CalculatorPlochki();
            display.Wreme = remont.CalculateTime();
            display.ShowResults();
        }
    }
}
