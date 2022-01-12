namespace DialogMessaging.Interactions.Base;

public partial interface IBaseDialogConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets whether the dialog is cancelable.
    /// </summary>
    bool Cancelable { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the style to use.
    /// </summary>
    int? StyleResID { get; set; }
    #endregion
}

public partial class BaseDialogConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets whether the dialog is cancelable.
    /// </summary>
    public bool Cancelable { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the style to use.
    /// </summary>
    public int? StyleResID { get; set; }
    #endregion
}

public partial class BaseDialogAsyncConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets whether the dialog is cancelable.
    /// </summary>
    public bool Cancelable { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the style to use.
    /// </summary>
    public int? StyleResID { get; set; }
    #endregion
}