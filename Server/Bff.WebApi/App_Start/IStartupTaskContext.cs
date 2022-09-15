namespace Bff.WebApi
{
    public interface IStartupTaskContext
    {
        Task WaitForCompletion();
    }
}