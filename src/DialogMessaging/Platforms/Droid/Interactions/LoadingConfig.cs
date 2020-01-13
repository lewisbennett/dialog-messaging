namespace DialogMessaging.Interactions
{
    public partial interface ILoadingConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default value for whether the dialog is cancelable.
        /// </summary>
        public static bool DefaultCancelable { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use by default.
        /// </summary>
        public static int? DefaultLayoutID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the style to use by default.
        /// </summary>
        public static int? DefaultStyleID { get; set; }
        #endregion
    }

    public partial class LoadingConfig
    {
        #region Constructors
        public LoadingConfig()
        {
            Cancelable = ILoadingConfig.DefaultCancelable;
            LayoutID = ILoadingConfig.DefaultLayoutID;
            StyleID = ILoadingConfig.DefaultStyleID;
        }
        #endregion
    }

    public partial class LoadingAsyncConfig
    {
        #region Constructors
        public LoadingAsyncConfig()
        {
            Cancelable = ILoadingConfig.DefaultCancelable;
            LayoutID = ILoadingConfig.DefaultLayoutID;
            StyleID = ILoadingConfig.DefaultStyleID;
        }
        #endregion
    }
}
