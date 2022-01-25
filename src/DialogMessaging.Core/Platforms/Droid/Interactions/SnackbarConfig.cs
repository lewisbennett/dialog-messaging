using Android.Graphics;
using Android.Views;

namespace DialogMessaging.Interactions;

public static partial class SnackbarConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default value for the action button text color.
    /// </summary>
    public static Color? ActionButtonTextColor { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the action button typeface.
    /// </summary>
    public static Typeface ActionButtonTypeface { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the action button typeface style.
    /// </summary>
    public static TypefaceStyle ActionButtonTypefaceStyle { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the animation mode.
    /// </summary>
    public static int? AnimationMode { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the background color.
    /// </summary>
    public static Color? BackgroundColor { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the Snackbar duration.
    /// </summary>
    public static int? Duration { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the message text color.
    /// </summary>
    public static Color? MessageTextColor { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the message typeface.
    /// </summary>
    public static Typeface MessageTypeface { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the message typeface style.
    /// </summary>
    public static TypefaceStyle MessageTypefaceStyle { get; set; }
    #endregion
}

public partial interface ISnackbarConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the action button text color.
    /// </summary>
    Color? ActionButtonTextColor { get; set; }

    /// <summary>
    ///     Gets or sets the action button typeface.
    /// </summary>
    Typeface ActionButtonTypeface { get; set; }

    /// <summary>
    ///     Gets or sets the action button typeface style.
    /// </summary>
    TypefaceStyle ActionButtonTypefaceStyle { get; set; }

    /// <summary>
    ///     Gets or sets the anchor view, if any.
    /// </summary>
    View AnchorView { get; set; }

    /// <summary>
    ///     Gets or sets the animation mode.
    /// </summary>
    int? AnimationMode { get; set; }

    /// <summary>
    ///     Gets or sets the background color.
    /// </summary>
    Color? BackgroundColor { get; set; }

    /// <summary>
    ///     Gets or sets the Snackbar duration.
    /// </summary>
    int? Duration { get; set; }

    /// <summary>
    ///     Gets or sets the message text color.
    /// </summary>
    Color? MessageTextColor { get; set; }

    /// <summary>
    ///     Gets or sets the message typeface.
    /// </summary>
    Typeface MessageTypeface { get; set; }

    /// <summary>
    ///     Gets or sets the message typeface style.
    /// </summary>
    TypefaceStyle MessageTypefaceStyle { get; set; }
    #endregion
}

public partial class SnackbarConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the action button text color.
    /// </summary>
    public Color? ActionButtonTextColor { get; set; }

    /// <summary>
    ///     Gets or sets the action button typeface.
    /// </summary>
    public Typeface ActionButtonTypeface { get; set; }

    /// <summary>
    ///     Gets or sets the action button typeface style.
    /// </summary>
    public TypefaceStyle ActionButtonTypefaceStyle { get; set; }

    /// <summary>
    ///     Gets or sets the anchor view, if any.
    /// </summary>
    public View AnchorView { get; set; }

    /// <summary>
    ///     Gets or sets the animation mode.
    /// </summary>
    public int? AnimationMode { get; set; }

    /// <summary>
    ///     Gets or sets the background color.
    /// </summary>
    public Color? BackgroundColor { get; set; }

    /// <summary>
    ///     Gets or sets the Snackbar duration.
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    ///     Gets or sets the message text color.
    /// </summary>
    public Color? MessageTextColor { get; set; }

    /// <summary>
    ///     Gets or sets the message typeface.
    /// </summary>
    public Typeface MessageTypeface { get; set; }

    /// <summary>
    ///     Gets or sets the message typeface style.
    /// </summary>
    public TypefaceStyle MessageTypefaceStyle { get; set; }
    #endregion

    #region Constructors
    public SnackbarConfig()
    {
        ActionButtonTextColor = SnackbarConfigDefaults.ActionButtonTextColor;
        ActionButtonTypeface = SnackbarConfigDefaults.ActionButtonTypeface;
        ActionButtonTypefaceStyle = SnackbarConfigDefaults.ActionButtonTypefaceStyle;
        AnimationMode = SnackbarConfigDefaults.AnimationMode;
        BackgroundColor = SnackbarConfigDefaults.BackgroundColor;
        Duration = SnackbarConfigDefaults.Duration;
        MessageTextColor = SnackbarConfigDefaults.MessageTextColor;
        MessageTypeface = SnackbarConfigDefaults.MessageTypeface;
        MessageTypefaceStyle = SnackbarConfigDefaults.MessageTypefaceStyle;
    }
    #endregion
}