namespace Program
{
    class MyComplex : IMyNumber<MyComplex>
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
            return new MyComplex(_re * that._re - _im * that._im, _re * that._im + _im * that._re);
        }

        public MyComplex Divide(MyComplex that)
        {
            double denom = that._re * that._re + that._im * that._im;
            
            if (denom == 0) throw new DivideByZeroException("Cannot divide by zero.");
            
            return new MyComplex((_re * that._re + _im * that._im) / denom, (_im * that._re - _re * that._im) / denom);
        }

        public override string ToString()
        {
            if (_im == 0) return $"{_re}";
            
            return $"{_re}{(_im >= 0 ? "+" : "")}{_im}i";
        }
    }
}