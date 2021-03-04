namespace DialogMessaging.Interactions
{
    public static partial class LoginConfigDefaults
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
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the bottom of password the text field.
        /// </summary>
        public static int? PasswordBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the end of the password text field.
        /// </summary>
        public static int? PasswordEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the start of the password text field.
        /// </summary>
        public static int? PasswordStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the top of the password text field.
        /// </summary>
        public static int? PasswordTopIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the style to use.
        /// </summary>
        public static int? StyleResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the bottom of username the text field.
        /// </summary>
        public static int? UsernameBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the end of the username text field.
        /// </summary>
        public static int? UsernameEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the start of the username text field.
        /// </summary>
        public static int? UsernameStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the default value for the resource ID of the drawable to be displayed at the top of the username text field.
        /// </summary>
        public static int? UsernameTopIconResID { get; set; }
        #endregion
    }

    public partial interface ILoginConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of password the text field.
        /// </summary>
        int? PasswordBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the password text field.
        /// </summary>
        int? PasswordEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the password text field.
        /// </summary>
        int? PasswordStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the password text field.
        /// </summary>
        int? PasswordTopIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of username the text field.
        /// </summary>
        int? UsernameBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the username text field.
        /// </summary>
        int? UsernameEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the username text field.
        /// </summary>
        int? UsernameStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the username text field.
        /// </summary>
        int? UsernameTopIconResID { get; set; }
        #endregion
    }

    public partial class LoginConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of password the text field.
        /// </summary>
        public int? PasswordBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the password text field.
        /// </summary>
        public int? PasswordEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the password text field.
        /// </summary>
        public int? PasswordStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the password text field.
        /// </summary>
        public int? PasswordTopIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of username the text field.
        /// </summary>
        public int? UsernameBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the username text field.
        /// </summary>
        public int? UsernameEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the username text field.
        /// </summary>
        public int? UsernameStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the username text field.
        /// </summary>
        public int? UsernameTopIconResID { get; set; }
        #endregion

        #region Constructors
        public LoginConfig()
        {
            Cancelable = LoginConfigDefaults.Cancelable;
            LayoutResID = LoginConfigDefaults.LayoutResID;
            PasswordBottomIconResID = LoginConfigDefaults.PasswordBottomIconResID;
            PasswordEndIconResID = LoginConfigDefaults.PasswordEndIconResID;
            PasswordStartIconResID = LoginConfigDefaults.PasswordStartIconResID;
            PasswordTopIconResID = LoginConfigDefaults.PasswordTopIconResID;
            StyleResID = LoginConfigDefaults.StyleResID;
            UsernameBottomIconResID = LoginConfigDefaults.UsernameBottomIconResID;
            UsernameEndIconResID = LoginConfigDefaults.UsernameEndIconResID;
            UsernameStartIconResID = LoginConfigDefaults.UsernameStartIconResID;
            UsernameTopIconResID = LoginConfigDefaults.UsernameTopIconResID;
        }
        #endregion
    }

    public partial class LoginAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of password the text field.
        /// </summary>
        public int? PasswordBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the password text field.
        /// </summary>
        public int? PasswordEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the password text field.
        /// </summary>
        public int? PasswordStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the password text field.
        /// </summary>
        public int? PasswordTopIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the bottom of username the text field.
        /// </summary>
        public int? UsernameBottomIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the end of the username text field.
        /// </summary>
        public int? UsernameEndIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the start of the username text field.
        /// </summary>
        public int? UsernameStartIconResID { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the drawable to be displayed at the top of the username text field.
        /// </summary>
        public int? UsernameTopIconResID { get; set; }
        #endregion

        #region Constructors
        public LoginAsyncConfig()
        {
            Cancelable = LoginConfigDefaults.Cancelable;
            LayoutResID = LoginConfigDefaults.LayoutResID;
            PasswordBottomIconResID = LoginConfigDefaults.PasswordBottomIconResID;
            PasswordEndIconResID = LoginConfigDefaults.PasswordEndIconResID;
            PasswordStartIconResID = LoginConfigDefaults.PasswordStartIconResID;
            PasswordTopIconResID = LoginConfigDefaults.PasswordTopIconResID;
            StyleResID = LoginConfigDefaults.StyleResID;
            UsernameBottomIconResID = LoginConfigDefaults.UsernameBottomIconResID;
            UsernameEndIconResID = LoginConfigDefaults.UsernameEndIconResID;
            UsernameStartIconResID = LoginConfigDefaults.UsernameStartIconResID;
            UsernameTopIconResID = LoginConfigDefaults.UsernameTopIconResID;
        }
        #endregion
    }
}
