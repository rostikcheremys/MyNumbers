namespace Program
{
    public interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T that);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }
}