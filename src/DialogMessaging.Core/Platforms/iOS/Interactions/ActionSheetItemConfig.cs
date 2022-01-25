using System;

namespace DialogMessaging.Interactions;

public static partial class ActionSheetItemConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
    /// </summary>
    public static Type CustomViewType { get; set; }
    #endregion
}

public partial interface IActionSheetItemConfig
{
}

public partial class ActionSheetItemConfig
{
    #region Constructors
    public ActionSheetItemConfig()
        : base()
    {
        CustomViewType = ActionSheetItemConfigDefaults.CustomViewType;
    }
    #endregion
}

public partial class ActionSheetItemAsyncConfig
{
    #region Constructors
    public ActionSheetItemAsyncConfig()
        : base()
    {
        CustomViewType = ActionSheetItemConfigDefaults.CustomViewType;
    }
    #endregion
}