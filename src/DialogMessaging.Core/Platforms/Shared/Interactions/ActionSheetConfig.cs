using System;
using System.Collections.Generic;
using DialogMessaging.Interactions.Base;

namespace DialogMessaging.Interactions;

public static partial class ActionSheetConfigDefaults
{
}

public partial interface IActionSheetConfig<TActionSheetItemConfig> : IBaseDialogConfig
    where TActionSheetItemConfig : IActionSheetItemConfig
{
    #region Properties
    /// <summary>
    ///     Gets the action invoked when the 'cancel' button is clicked.
    /// </summary>
    Action CancelButtonClickAction { get; }

    /// <summary>
    ///     Gets or sets the text displayed on the 'cancel' button.
    /// </summary>
    string CancelButtonText { get; set; }

    /// <summary>
    ///     Gets the action invoked when an item is clicked.
    /// </summary>
    Action<TActionSheetItemConfig> ItemClickAction { get; }

    /// <summary>
    ///     Gets the action sheet items.
    /// </summary>
    List<TActionSheetItemConfig> Items { get; }
    #endregion
}

public partial class ActionSheetConfig : BaseDialogConfig, IActionSheetConfig<ActionSheetItemConfig>
{
    #region Properties
    /// <summary>
    ///     Gets or sets the action invoked when the 'cancel' button is clicked.
    /// </summary>
    public Action CancelButtonClickAction { get; set; }

    /// <summary>
    ///     Gets or sets the text displayed on the 'cancel' button.
    /// </summary>
    public string CancelButtonText { get; set; }

    /// <summary>
    ///     Gets or sets the action invoked when an item is clicked.
    /// </summary>
    public Action<ActionSheetItemConfig> ItemClickAction { get; set; }

    /// <summary>
    ///     Gets the action sheet items.
    /// </summary>
    public List<ActionSheetItemConfig> Items { get; } = new();
    #endregion
}

public partial class ActionSheetAsyncConfig : BaseDialogAsyncConfig, IActionSheetConfig<ActionSheetItemAsyncConfig>
{
    #region Properties
    /// <summary>
    ///     Gets the action invoked when the 'cancel' button is clicked.
    /// </summary>
    public Action CancelButtonClickAction { get; internal set; }

    /// <summary>
    ///     Gets or sets the text displayed on the 'cancel' button.
    /// </summary>
    public string CancelButtonText { get; set; }

    /// <summary>
    ///     Gets the action invoked when an item is clicked.
    /// </summary>
    public Action<ActionSheetItemAsyncConfig> ItemClickAction { get; internal set; }

    /// <summary>
    ///     Gets the action sheet items.
    /// </summary>
    public List<ActionSheetItemAsyncConfig> Items { get; } = new();
    #endregion
}