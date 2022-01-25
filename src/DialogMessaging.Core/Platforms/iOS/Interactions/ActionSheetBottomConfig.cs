using System;

namespace DialogMessaging.Interactions;

public static partial class ActionSheetBottomConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
    /// </summary>
    public static Type CustomViewType { get; set; }
    #endregion
}

public partial interface IActionSheetBottomConfig<TActionSheetItemConfig>
{
}

public partial class ActionSheetBottomConfig
{
    #region Constructors
    public ActionSheetBottomConfig()
        : base()
    {
        CustomViewType = ActionSheetBottomConfigDefaults.CustomViewType;
    }
    #endregion
}

public partial class ActionSheetBottomAsyncConfig
{
    #region Constructors
    public ActionSheetBottomAsyncConfig()
        : base()
    {
        CustomViewType = ActionSheetBottomConfigDefaults.CustomViewType;
    }
    #endregion
}