namespace Esis.Shin
{

    internal sealed class StartupTaskContext : IStartupTaskContext
    {
        private readonly TaskCompletionSource<bool> _startupComplete = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        private int _outstandingTaskCount;

        public bool IsComplete => _outstandingTaskCount == 0 && !HasError;
        public bool HasError { get; private set; }

        public void RegisterTask() =>
            Interlocked.Increment(ref _outstandingTaskCount);

        public void CompleteTask()
        {
            var count = Interlocked.Decrement(ref _outstandingTaskCount);
            if (count == 0)
                _startupComplete.TrySetResult(true);
        }

        public Task WaitForCompletion() => _startupComplete.Task;

        public void FailTask(Exception ex)
        {
            HasError = true;

            _startupComplete.TrySetException(ex);
        }
    }
}