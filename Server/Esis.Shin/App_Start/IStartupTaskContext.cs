namespace Esis.Shin
{
    public interface IStartupTaskContext
    {
        Task WaitForCompletion();
    }
}