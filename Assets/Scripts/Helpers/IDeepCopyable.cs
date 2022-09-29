namespace Helpers
{
    public interface IDeepCopyable<T>
    {
        T DeepCopy();
    }
}