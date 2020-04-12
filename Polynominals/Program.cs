using System;
using Polynominals.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynominals
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynominal a = new Polynominal(new int[] { 1, 2, 3, 4 });
            Polynominal b = new Polynominal(new int[] { 2, 1, 1 });

            Polynominal res1 = a + b;
            Polynominal res2 = a - b;
            Polynominal res3 = a * b;

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);

            Console.ReadKey();
        }
    }
}
