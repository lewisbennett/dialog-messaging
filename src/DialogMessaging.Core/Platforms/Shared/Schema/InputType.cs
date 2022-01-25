using System;

namespace DialogMessaging.Schema
{
    [Flags]
    public enum InputType
    {
        Default = 1,
        Name = 1 << 1,
        EmailAddress = 1 << 2,
        Password = 1 << 3,
        PhoneNumber = 1 << 4,
        Integer = 1 << 5,
        Decimal = 1 << 6,
        URI = 1 << 7
    }
}
