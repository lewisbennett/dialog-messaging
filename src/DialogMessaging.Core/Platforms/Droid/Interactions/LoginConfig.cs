namespace DialogMessaging.Interactions;

public static partial class LoginConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default value for whether the dialog is cancelable.
    /// </summary>
    public static bool Cancelable { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the layout to use.
    /// </summary>
    public static int? LayoutResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the bottom of password the
    ///     text field.
    /// </summary>
    public static int? PasswordBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the left of the password text
    ///     field.
    /// </summary>
    public static int? PasswordLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the right of the password
    ///     text field.
    /// </summary>
    public static int? PasswordRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the top of the password text
    ///     field.
    /// </summary>
    public static int? PasswordTopIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the style to use.
    /// </summary>
    public static int? StyleResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the bottom of username the
    ///     text field.
    /// </summary>
    public static int? UsernameBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the left of the username text
    ///     field.
    /// </summary>
    public static int? UsernameLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the right of the username
    ///     text field.
    /// </summary>
    public static int? UsernameRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the drawable to be displayed at the top of the username text
    ///     field.
    /// </summary>
    public static int? UsernameTopIconResID { get; set; }
    #endregion
}

public partial interface ILoginConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the bottom of password the text field.
    /// </summary>
    int? PasswordBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the left of the password text field.
    /// </summary>
    int? PasswordLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the right of the password text field.
    /// </summary>
    int? PasswordRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the top of the password text field.
    /// </summary>
    int? PasswordTopIconResID { get; set; }

    /// <summary>
    ///     Gets or sets whether to show the password.
    /// </summary>
    bool ShowPassword { get; set; }

    /// <summary>
    ///     Gets or sets the hint for the show password toggle.
    /// </summary>
    string ShowPasswordHint { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the bottom of username the text field.
    /// </summary>
    int? UsernameBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the left of the username text field.
    /// </summary>
    int? UsernameLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the right of the username text field.
    /// </summary>
    int? UsernameRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the top of the username text field.
    /// </summary>
    int? UsernameTopIconResID { get; set; }
    #endregion
}

public partial class LoginConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the bottom of password the text field.
    /// </summary>
    public int? PasswordBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the left of the password text field.
    /// </summary>
    public int? PasswordLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the right of the password text field.
    /// </summary>
    public int? PasswordRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the top of the password text field.
    /// </summary>
    public int? PasswordTopIconResID { get; set; }

    /// <summary>
    ///     Gets or sets whether to show the password.
    /// </summary>
    public bool ShowPassword { get; set; }

    /// <summary>
    ///     Gets or sets the hint for the show password toggle.
    /// </summary>
    public string ShowPasswordHint { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the bottom of username the text field.
    /// </summary>
    public int? UsernameBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the left of the username text field.
    /// </summary>
    public int? UsernameLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the right of the username text field.
    /// </summary>
    public int? UsernameRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the top of the username text field.
    /// </summary>
    public int? UsernameTopIconResID { get; set; }
    #endregion

    #region Constructors
    public LoginConfig()
    {
        Cancelable = LoginConfigDefaults.Cancelable;
        LayoutResID = LoginConfigDefaults.LayoutResID;
        PasswordBottomIconResID = LoginConfigDefaults.PasswordBottomIconResID;
        PasswordRightIconResID = LoginConfigDefaults.PasswordRightIconResID;
        PasswordLeftIconResID = LoginConfigDefaults.PasswordLeftIconResID;
        PasswordTopIconResID = LoginConfigDefaults.PasswordTopIconResID;
        StyleResID = LoginConfigDefaults.StyleResID;
        UsernameBottomIconResID = LoginConfigDefaults.UsernameBottomIconResID;
        UsernameRightIconResID = LoginConfigDefaults.UsernameRightIconResID;
        UsernameLeftIconResID = LoginConfigDefaults.UsernameLeftIconResID;
        UsernameTopIconResID = LoginConfigDefaults.UsernameTopIconResID;
    }
    #endregion
}

public partial class LoginAsyncConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the bottom of password the text field.
    /// </summary>
    public int? PasswordBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the left of the password text field.
    /// </summary>
    public int? PasswordLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the right of the password text field.
    /// </summary>
    public int? PasswordRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the top of the password text field.
    /// </summary>
    public int? PasswordTopIconResID { get; set; }

    /// <summary>
    ///     Gets or sets whether to show the password.
    /// </summary>
    public bool ShowPassword { get; set; }

    /// <summary>
    ///     Gets or sets the hint for the show password toggle.
    /// </summary>
    public string ShowPasswordHint { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the bottom of username the text field.
    /// </summary>
    public int? UsernameBottomIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the left of the username text field.
    /// </summary>
    public int? UsernameLeftIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the right of the username text field.
    /// </summary>
    public int? UsernameRightIconResID { get; set; }

    /// <summary>
    ///     Gets or sets the resource ID of the drawable to be displayed at the top of the username text field.
    /// </summary>
    public int? UsernameTopIconResID { get; set; }
    #endregion

    #region Constructors
    public LoginAsyncConfig()
    {
        Cancelable = LoginConfigDefaults.Cancelable;
        LayoutResID = LoginConfigDefaults.LayoutResID;
        PasswordBottomIconResID = LoginConfigDefaults.PasswordBottomIconResID;
        PasswordRightIconResID = LoginConfigDefaults.PasswordRightIconResID;
        PasswordLeftIconResID = LoginConfigDefaults.PasswordLeftIconResID;
        PasswordTopIconResID = LoginConfigDefaults.PasswordTopIconResID;
        StyleResID = LoginConfigDefaults.StyleResID;
        UsernameBottomIconResID = LoginConfigDefaults.UsernameBottomIconResID;
        UsernameRightIconResID = LoginConfigDefaults.UsernameRightIconResID;
        UsernameLeftIconResID = LoginConfigDefaults.UsernameLeftIconResID;
        UsernameTopIconResID = LoginConfigDefaults.UsernameTopIconResID;
    }
    #endregion
}