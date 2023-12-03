namespace Program
{
    class MyComplex : IMyNumber<MyComplex>, IComparable<MyComplex>
    {
        private readonly double _re;
        private readonly double _im;

        public MyComplex(double re, double im)
        {
            _re = re;
            _im = im;
        }
        
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(_re + that._re, _im + that._im);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(_re - that._re, _im - that._im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            double realPart = _re * that._re - _im * that._im;
            double imagPart = _re * that._im + _im * that._re;
            
            return new MyComplex(realPart, imagPart);
        }

        public MyComplex Divide(MyComplex that)
        {
            if (that._re == 0 && that._im == 0) throw new DivideByZeroException("Cannot divide by zero.");
            
            double denom = that._re * that._re + that._im * that._im;
            double realPart = (_re * that._re + _im * that._im) / denom;
            double imagPart = (_im * that._re - _re * that._im) / denom;
            
            return new MyComplex(realPart, imagPart);
        }

        public override string ToString()
        {
            if (_im == 0)
            {
                return $"{_re}";
            }
            
            return $"{_re}{(_im >= 0 ? "+" : "")}{_im}i";
        }

        public int CompareTo(MyComplex other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            
            int reComparison = _re.CompareTo(other._re);
            
            if (reComparison != 0) return reComparison;
            
            return _im.CompareTo(other._im);
        }
    }
}