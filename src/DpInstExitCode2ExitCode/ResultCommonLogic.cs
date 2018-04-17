using System;
using System.Diagnostics;

namespace DpInstExitCode2ExitCode
{
    internal sealed class ResultCommonLogic
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Exception _error;

        public Exception Error
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no error message for success.");

                return _error;
            }
        }

        [DebuggerStepThrough]
        public ResultCommonLogic(bool isFailure, Exception error)
        {
            if (isFailure)
            {
                if (error == null)
                    throw new ArgumentNullException(nameof(error), "There must be exception for failure.");
            }
            else
            {
                if (error != null)
                    throw new ArgumentException("There should be no exception for success.", nameof(error));
            }

            IsFailure = isFailure;
            _error = error;
        }
    }
}