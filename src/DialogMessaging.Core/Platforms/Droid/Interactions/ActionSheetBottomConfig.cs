namespace DialogMessaging.Interactions
{
    public static partial class ActionSheetBottomConfigDefaults
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

    public partial interface IActionSheetBottomConfig<TActionSheetItemConfig>
    {
    }

    public partial class ActionSheetBottomConfig
    {
        #region Constructors
        public ActionSheetBottomConfig()
        {
            Cancelable = ActionSheetBottomConfigDefaults.Cancelable;
            LayoutResID = ActionSheetBottomConfigDefaults.LayoutResID;
            StyleResID = ActionSheetBottomConfigDefaults.StyleResID;
        }
        #endregion
    }

    public partial class ActionSheetBottomAsyncConfig
    {
        #region Constructors
        public ActionSheetBottomAsyncConfig()
        {
            Cancelable = ActionSheetBottomConfigDefaults.Cancelable;
            LayoutResID = ActionSheetBottomConfigDefaults.LayoutResID;
            StyleResID = ActionSheetBottomConfigDefaults.StyleResID;
        }
        #endregion
    }
}
