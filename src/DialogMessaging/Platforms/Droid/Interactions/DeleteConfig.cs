namespace DialogMessaging.Interactions
{
    public partial interface IDeleteConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default value for whether the dialog is cancelable.
        /// </summary>
        public static bool DefaultCancelable { get; set; } = true;

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

    public partial class DeleteConfig
    {
        #region Constructors
        public DeleteConfig()
        {
            Cancelable = IDeleteConfig.DefaultCancelable;
            LayoutID = IDeleteConfig.DefaultLayoutID;
            StyleID = IDeleteConfig.DefaultStyleID;
        }
        #endregion
    }

    public partial class DeleteAsyncConfig
    {
        #region Constructors
        public DeleteAsyncConfig()
        {
            Cancelable = IDeleteConfig.DefaultCancelable;
            LayoutID = IDeleteConfig.DefaultLayoutID;
            StyleID = IDeleteConfig.DefaultStyleID;
        }
        #endregion
    }
}
