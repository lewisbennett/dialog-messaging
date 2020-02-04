namespace DialogMessaging.Interactions
{
    public partial interface IConfirmConfig
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

    public partial class ConfirmConfig
    {
        #region Constructors
        public ConfirmConfig()
        {
            Cancelable = IConfirmConfig.DefaultCancelable;
            LayoutID = IConfirmConfig.DefaultLayoutID;
            StyleID = IConfirmConfig.DefaultStyleID;
        }
        #endregion
    }

    public partial class ConfirmAsyncConfig
    {
        #region Constructors
        public ConfirmAsyncConfig()
        {
            Cancelable = IConfirmConfig.DefaultCancelable;
            LayoutID = IConfirmConfig.DefaultLayoutID;
            StyleID = IConfirmConfig.DefaultStyleID;
        }
        #endregion
    }
}
