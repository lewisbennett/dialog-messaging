using System;

namespace DialogMessaging.Interactions;

public static partial class LoginConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
    /// </summary>
    public static Type CustomViewType { get; set; }
    #endregion
}

public partial interface ILoginConfig
{
}

public partial class LoginConfig
{
    #region Constructors
    public LoginConfig()
        : base()
    {
        CustomViewType = LoginConfigDefaults.CustomViewType;
    }
    #endregion
}

public partial class LoginAsyncConfig
{
    #region Constructors
    public LoginAsyncConfig()
        : base()
    {
        CustomViewType = LoginConfigDefaults.CustomViewType;
    }
    #endregion
}