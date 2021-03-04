namespace DialogMessaging.Interactions
{
    public static partial class PromptConfigDefaults
    {
        #region Properties
        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the bottom of the text field.
        /// </summary>
        public static int? BottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for whether the dialog is cancelable.
        /// </summary>
        public static bool Cancelable { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the end of the text field.
        /// </summary>
        public static int? EndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the layout to use.
        /// </summary>
        public static int? LayoutResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the start of the text field.
        /// </summary>
        public static int? StartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the style to use.
        /// </summary>
        public static int? StyleResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the top of the text field.
        /// </summary>
        public static int? TopIconResID { get; set; }
        #endregion
    }

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
            BottomIconResID = PromptConfigDefaults.BottomIconResID;
            Cancelable = PromptConfigDefaults.Cancelable;
            EndIconResID = PromptConfigDefaults.EndIconResID;
            LayoutResID = PromptConfigDefaults.LayoutResID;
            StartIconResID = PromptConfigDefaults.StartIconResID;
            StyleResID = PromptConfigDefaults.StyleResID;
            TopIconResID = PromptConfigDefaults.TopIconResID;
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
            BottomIconResID = PromptConfigDefaults.BottomIconResID;
            Cancelable = PromptConfigDefaults.Cancelable;
            EndIconResID = PromptConfigDefaults.EndIconResID;
            LayoutResID = PromptConfigDefaults.LayoutResID;
            StartIconResID = PromptConfigDefaults.StartIconResID;
            StyleResID = PromptConfigDefaults.StyleResID;
            TopIconResID = PromptConfigDefaults.TopIconResID;
        }
        #endregion
    }
}
