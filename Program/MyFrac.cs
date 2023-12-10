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

        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(_nom * that._denom + that._nom * _denom, _denom * that._denom);
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(_nom * that._denom - that._nom * _denom, _denom * that._denom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(_nom * that._nom, _denom * that._denom);
        }

        public MyFrac Divide(MyFrac that)
        {
            if (that._nom == 0) throw new DivideByZeroException("Cannot divide by zero.");
            
            return new MyFrac(_nom * that._denom, _denom * that._nom);
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