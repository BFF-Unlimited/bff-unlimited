using System.Diagnostics;

namespace Esis.Shin.Core.Framework.Extensions
{
    /// <summary>
    /// Helps with guarding the sanity of the application
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Guards against null values.
        /// </summary>
        /// <param name="valueToGuard">The value to guard.</param>
        [DebuggerStepThrough]
        // ReSharper disable once UnusedParameter.Global
        public static void NotNull(object? valueToGuard)
        {
            if (valueToGuard is null)
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Guards against null or empty values.
        /// </summary>
        /// <param name="valueToGuard">The value to guard.</param>
        [DebuggerStepThrough]
        // ReSharper disable once UnusedParameter.Global
        public static void NotNullOrEmpty(Guid? valueToGuard)
        {
            if (valueToGuard == Guid.Empty)
                throw new ArgumentException();
        }

        /// <summary>
        /// Guards against null or empty values.
        /// </summary>
        /// <param name="valueToGuard">The value to guard.</param>
        [DebuggerStepThrough]
        // ReSharper disable once UnusedParameter.Global
        public static void NotNullOrEmpty(string? valueToGuard)
        {
            if (valueToGuard is null)
                throw new ArgumentNullException();
            if (string.IsNullOrEmpty(valueToGuard))
                throw new ArgumentException();
        }
    }
}
