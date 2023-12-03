using System.Numerics;

namespace Program
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private readonly BigInteger _nom;
        private readonly BigInteger _denom;

        private MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0) throw new DivideByZeroException("Denominator cannot be zero.");
            
            _nom = nom;
            _denom = denom;
            
            BigInteger gcd = BigInteger.GreatestCommonDivisor(_nom, _denom);
            
            _nom /= gcd;
            _denom /= gcd;

            if (_denom >= 0) return;
            
            _nom = -_nom;
            _denom = -_denom;
        }
        
        public MyFrac(int nom, int denom) : this(new BigInteger(nom), new BigInteger(denom)) { }

        public MyFrac Add(MyFrac b)
        {
            return new MyFrac(BigInteger.Add(BigInteger.Multiply(_nom, b._denom), 
                    BigInteger.Multiply(_denom, b._nom)),
                BigInteger.Multiply(_denom, b._denom)
            );
        }

        public MyFrac Subtract(MyFrac b)
        {
            return new MyFrac(BigInteger.Subtract(BigInteger.Multiply(_nom, b._denom), 
                    BigInteger.Multiply(_denom, b._nom)),
                BigInteger.Multiply(_denom, b._denom)
            );
        }

        public MyFrac Multiply(MyFrac b)
        {
            return new MyFrac(BigInteger.Multiply(_nom, b._nom), 
                BigInteger.Multiply(_denom, b._denom)
            );
        }

        public MyFrac Divide(MyFrac b)
        {
            if (b._nom == 0) throw new DivideByZeroException("Cannot divide by zero.");

            return new MyFrac(BigInteger.Multiply(_nom, b._denom), 
                BigInteger.Multiply(_denom, b._nom)
            );
        }

        public override string ToString()
        {
            return $"{_nom}/{_denom}";
        }

        public int CompareTo(MyFrac other)
        {
            BigInteger value1 = _nom * other._denom;
            BigInteger value2 = other._nom * _denom;
                
            return value1.CompareTo(value2);
        }
    }
}