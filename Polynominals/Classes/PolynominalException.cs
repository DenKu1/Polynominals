using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynominals.Classes
{
    class PolynominalAmountOfElementsException : Exception
    {
        public PolynominalAmountOfElementsException(string message): base(message)
        {
        }
    }
}
