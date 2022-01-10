namespace DialogMessaging.Interactions.Base;

public partial interface IBaseInteraction
{
    #region Properties
    /// <summary>
    ///     Gets or sets the resource ID of the layout to use.
    /// </summary>
    int? LayoutResID { get; set; }
    #endregion
}

public partial class BaseInteraction
{
    #region Properties
    /// <summary>
    ///     Gets or sets the resource ID of the layout to use.
    /// </summary>
    public int? LayoutResID { get; set; }
    #endregion
}

public partial class BaseAsyncInteraction
{
    #region Properties
    /// <summary>
    ///     Gets or sets the resource ID of the layout to use.
    /// </summary>
    public int? LayoutResID { get; set; }
    #endregion
}