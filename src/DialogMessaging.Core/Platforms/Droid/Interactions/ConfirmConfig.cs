namespace DialogMessaging.Interactions
{
    public static partial class ConfirmConfigDefaults
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

    public partial interface IConfirmConfig
    {
    }

    public partial class ConfirmConfig
    {
        #region Constructors
        public ConfirmConfig()
        {
            Cancelable = ConfirmConfigDefaults.Cancelable;
            LayoutResID = ConfirmConfigDefaults.LayoutResID;
            StyleResID = ConfirmConfigDefaults.StyleResID;
        }
        #endregion
    }

    public partial class ConfirmAsyncConfig
    {
        #region Constructors
        public ConfirmAsyncConfig()
        {
            Cancelable = ConfirmConfigDefaults.Cancelable;
            LayoutResID = ConfirmConfigDefaults.LayoutResID;
            StyleResID = ConfirmConfigDefaults.StyleResID;
        }
        #endregion
    }
}
