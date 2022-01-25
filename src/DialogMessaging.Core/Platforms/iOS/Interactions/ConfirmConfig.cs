using System;

namespace DialogMessaging.Interactions;

public static partial class ConfirmConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
    /// </summary>
    public static Type CustomViewType { get; set; }
    #endregion
}

public partial interface IConfirmConfig
{
}

public partial class ConfirmConfig
{
    #region Constructors
    public ConfirmConfig()
        : base()
    {
        CustomViewType = ConfirmConfigDefaults.CustomViewType;
    }
    #endregion
}

public partial class ConfirmAsyncConfig
{
    #region Constructors
    public ConfirmAsyncConfig()
        : base()
    {
        CustomViewType = ConfirmConfigDefaults.CustomViewType;
    }
    #endregion
}