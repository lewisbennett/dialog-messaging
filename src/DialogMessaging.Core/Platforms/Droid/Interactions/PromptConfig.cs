namespace DialogMessaging.Interactions
{
    public partial interface IPromptConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of the text field.
        /// </summary>
        int? BottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the text field.
        /// </summary>
        int? EndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the text field.
        /// </summary>
        int? StartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the text field.
        /// </summary>
        int? TopIconResID { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default value for whether the dialog is cancelable.
        /// </summary>
        public static bool DefaultCancelable { get; set; } = true;

        /// <summary>
        /// Gets or sets the resource ID of the default icon to be displayed within the text field.
        /// </summary>
        public static int? DefaultIconResID { get; set; }

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

    public partial class PromptConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of the text field.
        /// </summary>
        public int? BottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the text field.
        /// </summary>
        public int? EndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the text field.
        /// </summary>
        public int? StartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the text field.
        /// </summary>
        public int? TopIconResID { get; set; }
        #endregion

        #region Constructors
        public PromptConfig()
        {
            Cancelable = IPromptConfig.DefaultCancelable;
            EndIconResID = IPromptConfig.DefaultIconResID;
            LayoutID = IPromptConfig.DefaultLayoutID;
            StyleID = IPromptConfig.DefaultStyleID;
        }
        #endregion
    }

    public partial class PromptAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of the text field.
        /// </summary>
        public int? BottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the text field.
        /// </summary>
        public int? EndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the text field.
        /// </summary>
        public int? StartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the text field.
        /// </summary>
        public int? TopIconResID { get; set; }
        #endregion

        #region Constructors
        public PromptAsyncConfig()
        {
            Cancelable = IPromptConfig.DefaultCancelable;
            EndIconResID = IPromptConfig.DefaultIconResID;
            LayoutID = IPromptConfig.DefaultLayoutID;
            StyleID = IPromptConfig.DefaultStyleID;
        }
        #endregion
    }
}
