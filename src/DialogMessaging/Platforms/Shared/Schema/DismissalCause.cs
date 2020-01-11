using System;

namespace DialogMessaging.Schema
{
    [Flags]
    public enum DismissalCause
    {
        Dismissed = 1,
        OkButton = 2,
        DeleteButton = 4,
        CancelButton = 8
    }
}
