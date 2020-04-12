using System;

namespace Polynominals.Classes
{
    class Polynominal
    {      
        public int Power
        {
            get
            {
                return _value.Length - 1;
            }
        }

        private int[] _value;

        public int[] Value
        {
            get
            {
                return _value;
            }
            
            set
            {
                if (value is null)
                    throw new NullReferenceException();

                if (value.Length == 0)
                    throw new PolynominalAmountOfElementsException("Polynominal must have at least one element!");

                _value = value;
            }
        }
        
        public Polynominal(int[] coefficients)
        {
            Value = coefficients;
        }

        public int this[int index]
        {
            get
            {
                CheckRange(index);

                return Value[index];
            }
            set
            {
                CheckRange(index);

                Value[index] = value;
            }
        }

        private void CheckRange(int index)
        {
            if (index > Power)
                throw new IndexOutOfRangeException();
        }

        private static void CheckIsNull(Polynominal p1, Polynominal p2)
        {
            if (p1 is null || p2 is null)
            {
                throw new NullReferenceException();
            }
        }

        private static Polynominal SumUpArrayValues(Polynominal p1, Polynominal p2)
        {
            Polynominal result = new Polynominal((int[])p1.Value.Clone());            

            for (int i = 0; i <= p2.Power; i++)            
                result[i] += p2[i];            

            return result;
        }

        private static Polynominal SubtractArrayValues(Polynominal p1, Polynominal p2)
        {
            Polynominal result = new Polynominal((int[])p1.Value.Clone());

            for (int i = 0; i <= p2.Power; i++)            
                result[i] -= p2[i];            

            return result;
        }

        public static Polynominal SumUpPolynominals(Polynominal p1, Polynominal p2)
        {
            CheckIsNull(p1, p2);

            return (p1.Power >= p2.Power) ? SumUpArrayValues(p1, p2) : SumUpArrayValues(p2, p1);
        }

        public static Polynominal SubtractPolynominals(Polynominal p1, Polynominal p2)
        {
            CheckIsNull(p1, p2);

            return (p1.Power >= p2.Power) ? SubtractArrayValues(p1, p2) : SubtractArrayValues(p2, p1);
        }

        public static Polynominal MultiplyPolynominals(Polynominal p1, Polynominal p2)
        {
            CheckIsNull(p1, p2);

            int[] resultCoefs = new int[p1.Power + p2.Power + 1];

            for (int i = 0; i <= p2.Power; i++)
            {
                for (int j = i; j <= p1.Power + i; j++)
                {
                    resultCoefs[j] += p1[j - i] * p2[i];
                }
            }

            return new Polynominal(resultCoefs);
        }

        public static Polynominal operator +(Polynominal p1, Polynominal p2)
        {
            return SumUpPolynominals(p1, p2);
        }

        public static Polynominal operator -(Polynominal p1, Polynominal p2)
        {
            return SubtractPolynominals(p1, p2);
        }

        public static Polynominal operator *(Polynominal p1, Polynominal p2)
        {
            return MultiplyPolynominals(p1, p2);
        }

        public override string ToString()
        {
            string strPolynominal = "";

            for (int i = Power; i >= 0; i--)
            {
                strPolynominal += this[i].ToString() + " * x^" + i + " + ";
            }

            return strPolynominal.Substring(0, strPolynominal.Length - 9);
        }
    }
}
