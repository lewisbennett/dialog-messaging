using System;

namespace DialogMessaging.Interactions;

public static partial class ActionSheetConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
    /// </summary>
    public static Type CustomViewType { get; set; }
    #endregion
}

public partial interface IActionSheetConfig<TActionSheetItemConfig>
{
}

public partial class ActionSheetConfig
{
    #region Constructors
    public ActionSheetConfig()
        : base()
    {
        CustomViewType = ActionSheetConfigDefaults.CustomViewType;
    }
    #endregion
}

public partial class ActionSheetAsyncConfig
{
    #region Constructors
    public ActionSheetAsyncConfig()
        : base()
    {
        CustomViewType = ActionSheetConfigDefaults.CustomViewType;
    }
    #endregion
}