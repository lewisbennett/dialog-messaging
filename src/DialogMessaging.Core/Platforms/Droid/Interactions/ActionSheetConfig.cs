namespace DialogMessaging.Interactions
{
    public static partial class ActionSheetConfigDefaults
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

    public partial interface IActionSheetConfig<TActionSheetItemConfig>
    {
    }

    public partial class ActionSheetConfig
    {
        #region Constructors
        public ActionSheetConfig()
        {
            Cancelable = ActionSheetConfigDefaults.Cancelable;
            LayoutResID = ActionSheetConfigDefaults.LayoutResID;
            StyleResID = ActionSheetConfigDefaults.StyleResID;
        }
        #endregion
    }

    public partial class ActionSheetAsyncConfig
    {
        #region Constructors
        public ActionSheetAsyncConfig()
        {
            Cancelable = ActionSheetConfigDefaults.Cancelable;
            LayoutResID = ActionSheetConfigDefaults.LayoutResID;
            StyleResID = ActionSheetConfigDefaults.StyleResID;
        }
        #endregion
    }
}
