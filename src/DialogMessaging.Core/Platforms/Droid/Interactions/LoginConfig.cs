namespace DialogMessaging.Interactions
{
    public partial interface ILoginConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the icon to be displayed within the password text field..
        /// </summary>
        int? PasswordIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the icon to be displayed within the username text field..
        /// </summary>
        int? UsernameIconResID { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default value for whether the dialog is cancelable.
        /// </summary>
        public static bool DefaultCancelable { get; set; } = true;

        /// <summary>
        /// Gets or sets the resource ID of the default icon to be displayed within the password text field.
        /// </summary>
        public static int? DefaultPasswordIconResID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use by default.
        /// </summary>
        public static int? DefaultLayoutID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the style to use by default.
        /// </summary>
        public static int? DefaultStyleID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the default icon to be displayed within the username text field.
        /// </summary>
        public static int? DefaultUsernameIconResID { get; set; }
        #endregion
    }

    public partial class LoginConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the icon to be displayed within the password text field..
        /// </summary>
        public int? PasswordIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the icon to be displayed within the username text field..
        /// </summary>
        public int? UsernameIconResID { get; set; }
        #endregion

        #region Constructors
        public LoginConfig()
        {
            Cancelable = ILoginConfig.DefaultCancelable;
            LayoutID = ILoginConfig.DefaultLayoutID;
            PasswordIconResID = ILoginConfig.DefaultPasswordIconResID;
            StyleID = ILoginConfig.DefaultStyleID;
            UsernameIconResID = ILoginConfig.DefaultUsernameIconResID;
        }
        #endregion
    }

    public partial class LoginAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the icon to be displayed within the password text field..
        /// </summary>
        public int? PasswordIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the icon to be displayed within the username text field..
        /// </summary>
        public int? UsernameIconResID { get; set; }
        #endregion

        #region Constructors
        public LoginAsyncConfig()
        {
            Cancelable = ILoginConfig.DefaultCancelable;
            LayoutID = ILoginConfig.DefaultLayoutID;
            PasswordIconResID = ILoginConfig.DefaultPasswordIconResID;
            StyleID = ILoginConfig.DefaultStyleID;
            UsernameIconResID = ILoginConfig.DefaultUsernameIconResID;
        }
        #endregion
    }
}
