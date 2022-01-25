namespace DialogMessaging.Interactions
{
    public static partial class LoadingConfigDefaults
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

    public partial interface ILoadingConfig
    {
    }

    public partial class LoadingConfig
    {
        #region Constructors
        public LoadingConfig()
        {
            Cancelable = LoadingConfigDefaults.Cancelable;
            LayoutResID = LoadingConfigDefaults.LayoutResID;
            StyleResID = LoadingConfigDefaults.StyleResID;
        }
        #endregion
    }

    public partial class LoadingAsyncConfig
    {
        #region Constructors
        public LoadingAsyncConfig()
        {
            Cancelable = LoadingConfigDefaults.Cancelable;
            LayoutResID = LoadingConfigDefaults.LayoutResID;
            StyleResID = LoadingConfigDefaults.StyleResID;
        }
        #endregion
    }
}