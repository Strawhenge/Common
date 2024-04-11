using System;

namespace Strawhenge.Common.Logging
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Information = 1,
        Warning = 2,
        Error = 4,
        All = 7
    }
}