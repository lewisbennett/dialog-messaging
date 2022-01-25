namespace DialogMessaging.Interactions
{
    public static partial class ActionSheetItemConfigDefaults
    {
        #region Properties
        /// <summary>
        /// Gets or sets the default value for the resource ID of the layout to use.
        /// </summary>
        public static int? LayoutResID { get; set; }
        #endregion
    }

    public partial interface IActionSheetItemConfig
    {
    }

    public partial class ActionSheetItemConfig
    {
        #region Constructors
        public ActionSheetItemConfig()
        {
            LayoutResID = ActionSheetItemConfigDefaults.LayoutResID;
        }
        #endregion
    }

    public partial class ActionSheetItemAsyncConfig
    {
        #region Constructors
        public ActionSheetItemAsyncConfig()
        {
            LayoutResID = ActionSheetItemConfigDefaults.LayoutResID;
        }
        #endregion
    }
}
