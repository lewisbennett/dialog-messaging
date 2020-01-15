﻿using Android.Graphics;
using Android.Support.Design.Widget;
using System;

namespace DialogMessaging.Interactions
{
    public partial interface ISnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action text color.
        /// </summary>
        Color? ActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the action text color.
        /// </summary>
        Func<Color> ActionButtonTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        Color? BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calcaulate the background color.
        /// </summary>
        Func<Color> BackgroundColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the snackbar duration.
        /// </summary>
        int Duration { get; set; }

        /// <summary>
        /// Gets or sets the message text color.
        /// </summary>
        Color? MessageTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the message text color.
        /// </summary>
        Func<Color> MessageTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the message typeface.
        /// </summary>
        Typeface MessageTypeface { get; set; }

        /// <summary>
        /// Gets or sets the message typeface style.
        /// </summary>
        TypefaceStyle MessageTypefaceStyle { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default action button text color.
        /// </summary>
        public static Color? DefaultActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the default function to calculate the action button text color.
        /// </summary>
        public static Func<Color> DefaultActionButtonTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the default snackbar duration. Default value: Snackbar.LengthLong.
        /// </summary>
        public static int DefaultDuration { get; set; } = Snackbar.LengthLong;

        /// <summary>
        /// Gets or sets the default background color.
        /// </summary>
        public static Color? DefaultBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the default function to calculate the background color.
        /// </summary>
        public static Func<Color> DefaultBackgroundColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the default message text color.
        /// </summary>
        public static Color? DefaultMessageTextColor { get; set; }

        /// <summary>
        /// Gets or sets the default function to calculate the message text color.
        /// </summary>
        public static Func<Color> DefaultMessageTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the default message typeface.
        /// </summary>
        public static Typeface DefaultMessageTypeface { get; set; }

        /// <summary>
        /// Gets or sets the default message typeface style. Default value: TypefaceStyle.Normal.
        /// </summary>
        public static TypefaceStyle DefaultMessageTypefaceStyle { get; set; } = TypefaceStyle.Normal;
        #endregion
    }

    public partial class SnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action text color.
        /// </summary>
        public Color? ActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the action text color.
        /// </summary>
        public Func<Color> ActionButtonTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public Color? BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calcaulate the background color.
        /// </summary>
        public Func<Color> BackgroundColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the snackbar duration.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the message text color.
        /// </summary>
        public Color? MessageTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the message text color.
        /// </summary>
        public Func<Color> MessageTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the message typeface.
        /// </summary>
        public Typeface MessageTypeface { get; set; }

        /// <summary>
        /// Gets or sets the message typeface style.
        /// </summary>
        public TypefaceStyle MessageTypefaceStyle { get; set; }
        #endregion

        #region Constructors
        public SnackbarConfig()
        {
            ActionButtonTextColor = ISnackbarConfig.DefaultActionButtonTextColor;
            ActionButtonTextColorCalculator = ISnackbarConfig.DefaultActionButtonTextColorCalculator;
            BackgroundColor = ISnackbarConfig.DefaultBackgroundColor;
            BackgroundColorCalculator = ISnackbarConfig.DefaultBackgroundColorCalculator;
            Duration = ISnackbarConfig.DefaultDuration;
            MessageTextColor = ISnackbarConfig.DefaultMessageTextColor;
            MessageTextColorCalculator = ISnackbarConfig.DefaultMessageTextColorCalculator;
            MessageTypeface = ISnackbarConfig.DefaultMessageTypeface;
            MessageTypefaceStyle = ISnackbarConfig.DefaultMessageTypefaceStyle;
        }
        #endregion
    }
}