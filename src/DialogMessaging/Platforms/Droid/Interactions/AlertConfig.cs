namespace DialogMessaging.Interactions
{
    public partial interface IAlertConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the dialog is cancelable.
        /// </summary>
        bool Cancelable { get; set; }
        #endregion

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

    public partial class AlertConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the dialog is cancelable.
        /// </summary>
        public bool Cancelable { get; set; }
        #endregion

        #region Constructors
        public AlertConfig()
        {
            Cancelable = IAlertConfig.DefaultCancelable;
            LayoutID = IAlertConfig.DefaultLayoutID;
            StyleID = IAlertConfig.DefaultStyleID;
        }
        #endregion
    }

    public partial class AlertAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the dialog is cancelable.
        /// </summary>
        public bool Cancelable { get; set; }
        #endregion

        #region Constructors
        public AlertAsyncConfig()
        {
            Cancelable = IAlertConfig.DefaultCancelable;
            LayoutID = IAlertConfig.DefaultLayoutID;
            StyleID = IAlertConfig.DefaultStyleID;
        }
        #endregion
    }
}
