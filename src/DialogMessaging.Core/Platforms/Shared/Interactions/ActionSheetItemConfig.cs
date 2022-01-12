using System;
using DialogMessaging.Interactions.Base;

namespace DialogMessaging.Interactions;

public static partial class ActionSheetItemConfigDefaults
{
}

public partial interface IActionSheetItemConfig : IBaseInteraction
{
    #region Properties
    /// <summary>
    ///     Gets the action invoked when the item is clicked.
    /// </summary>
    Action ClickAction { get; }
    #endregion
}

public partial class ActionSheetItemConfig : BaseInteraction, IActionSheetItemConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the action invoked when the item is clicked.
    /// </summary>
    public Action ClickAction { get; set; }
    #endregion
}

public partial class ActionSheetItemAsyncConfig : BaseAsyncInteraction, IActionSheetItemConfig
{
    #region Properties
    /// <summary>
    ///     Gets the action invoked when the item is clicked.
    /// </summary>
    public Action ClickAction { get; }
    #endregion
}