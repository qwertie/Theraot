﻿#if NET20 || NET30 || NET35

namespace System.Threading.Tasks
{
    public enum TaskStatus
    {
        Created,
        WaitingForActivation,
        WaitingToRun,
        Running,
        WaitingForChildrenToComplete,
        RanToCompletion,
        Canceled,
        Faulted
    }
}

#endif