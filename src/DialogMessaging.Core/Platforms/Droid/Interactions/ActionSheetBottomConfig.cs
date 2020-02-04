namespace DialogMessaging.Interactions
{
    public partial interface IActionSheetBottomConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the layout to use for the items.
        /// </summary>
        int? ItemLayoutResID { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default value for whether the dialog is cancelable.
        /// </summary>
        public static bool DefaultCancelable { get; set; } = true;

        /// <summary>
        /// Gets or sets the resource ID of the default layout to use for the items.
        /// </summary>
        public static int? DefaultItemLayoutResID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use by default.
        /// </summary>
        public static int? DefaultLayoutResID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the style to use by default.
        /// </summary>
        public static int? DefaultStyleResID { get; set; }
        #endregion
    }

    public partial class ActionSheetBottomConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the layout to use for the items.
        /// </summary>
        public int? ItemLayoutResID { get; set; }
        #endregion

        #region Constructors
        public ActionSheetBottomConfig()
        {
            Cancelable = IActionSheetBottomConfig.DefaultCancelable;
            ItemLayoutResID = IActionSheetBottomConfig.DefaultItemLayoutResID;
            LayoutID = IActionSheetBottomConfig.DefaultLayoutResID;
            StyleID = IActionSheetBottomConfig.DefaultStyleResID;
        }
        #endregion
    }

    public partial class ActionSheetBottomAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the layout to use for the items.
        /// </summary>
        public int? ItemLayoutResID { get; set; }
        #endregion

        #region Constructors
        public ActionSheetBottomAsyncConfig()
        {
            Cancelable = IActionSheetBottomConfig.DefaultCancelable;
            ItemLayoutResID = IActionSheetBottomConfig.DefaultItemLayoutResID;
            LayoutID = IActionSheetBottomConfig.DefaultLayoutResID;
            StyleID = IActionSheetBottomConfig.DefaultStyleResID;
        }
        #endregion
    }
}
