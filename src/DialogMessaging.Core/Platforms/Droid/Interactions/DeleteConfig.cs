namespace DialogMessaging.Interactions;

public static partial class DeleteConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default value for whether the dialog is cancelable.
    /// </summary>
    public static bool Cancelable { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the layout to use.
    /// </summary>
    public static int? LayoutResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the style to use.
    /// </summary>
    public static int? StyleResID { get; set; }
    #endregion
}

public partial interface IDeleteConfig
{
}

public partial class DeleteConfig
{
    #region Constructors
    public DeleteConfig()
    {
        Cancelable = DeleteConfigDefaults.Cancelable;
        LayoutResID = DeleteConfigDefaults.LayoutResID;
        StyleResID = DeleteConfigDefaults.StyleResID;
    }
    #endregion
}

public partial class DeleteAsyncConfig
{
    #region Constructors
    public DeleteAsyncConfig()
    {
        Cancelable = DeleteConfigDefaults.Cancelable;
        LayoutResID = DeleteConfigDefaults.LayoutResID;
        StyleResID = DeleteConfigDefaults.StyleResID;
    }
    #endregion
}