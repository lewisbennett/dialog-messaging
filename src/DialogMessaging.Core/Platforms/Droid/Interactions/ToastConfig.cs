using Android.Widget;

namespace DialogMessaging.Interactions
{
    public partial interface IToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the toast duration.
        /// </summary>
        ToastLength Duration { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use.
        /// </summary>
        int? LayoutID { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default toast duration. Default value: ToastLength.Short.
        /// </summary>
        public static ToastLength DefaultDuration { get; set; } = ToastLength.Short;

        /// <summary>
        /// Gets or sets the ID of the layout file to use by default.
        /// </summary>
        public static int? DefaultLayoutID { get; set; }
        #endregion
    }

    public partial class ToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the toast duration.
        /// </summary>
        public ToastLength Duration { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use.
        /// </summary>
        public int? LayoutID { get; set; }
        #endregion

        #region Constructors
        public ToastConfig()
        {
            Duration = IToastConfig.DefaultDuration;
            LayoutID = IToastConfig.DefaultLayoutID;
        }
        #endregion
    }
}
