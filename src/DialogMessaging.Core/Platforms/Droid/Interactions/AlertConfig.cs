namespace DialogMessaging.Interactions
{
    public static partial class AlertConfigDefaults
    {
        #region Properties
        /// <summary>
        /// Gets or sets the default value for whether the dialog is cancelable.
        /// </summary>
        public static bool Cancelable { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the layout to use.
        /// </summary>
        public static int? LayoutResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the style to use.
        /// </summary>
        public static int? StyleResID { get; set; }
        #endregion
    }

    public partial interface IAlertConfig
    {
    }

    public partial class AlertConfig
    {
        #region Constructors
        public AlertConfig()
        {
            Cancelable = AlertConfigDefaults.Cancelable;
            LayoutResID = AlertConfigDefaults.LayoutResID;
            StyleResID = AlertConfigDefaults.StyleResID;
        }
        #endregion
    }

    public partial class AlertAsyncConfig
    {
        #region Constructors
        public AlertAsyncConfig()
        {
            Cancelable = AlertConfigDefaults.Cancelable;
            LayoutResID = AlertConfigDefaults.LayoutResID;
            StyleResID = AlertConfigDefaults.StyleResID;
        }
        #endregion
    }
}
