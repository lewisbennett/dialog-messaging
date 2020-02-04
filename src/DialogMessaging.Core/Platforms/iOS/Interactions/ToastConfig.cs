using System;

namespace DialogMessaging.Interactions
{
    public partial interface IToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the snackbar duration.
        /// </summary>
        TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the view type.
        /// </summary>
        Type ViewType { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default duration.
        /// </summary>
        public static TimeSpan? DefaultDuration { get; set; }

        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class ToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the toast duration.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the view type.
        /// </summary>
        public Type ViewType { get; set; }
        #endregion

        #region Constructors
        public ToastConfig()
        {
            Duration = IToastConfig.DefaultDuration;
            ViewType = IToastConfig.DefaultViewType;
        }
        #endregion
    }
}
