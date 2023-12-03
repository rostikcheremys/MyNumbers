namespace Program
{
    public interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T b);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }
}