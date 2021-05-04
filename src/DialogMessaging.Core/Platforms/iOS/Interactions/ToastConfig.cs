using System;

namespace DialogMessaging.Interactions
{
    public partial interface IToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the duration of the toast.
        /// </summary>
        TimeSpan? Duration { get; set; }
        #endregion
    }

    public partial class ToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the duration of the toast.
        /// </summary>
        public TimeSpan? Duration { get; set; }
        #endregion
    }
}
