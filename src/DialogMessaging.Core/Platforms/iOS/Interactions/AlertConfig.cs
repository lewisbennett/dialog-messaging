using System;

namespace DialogMessaging.Interactions
{
    public static partial class AlertConfigDefaults
    {
        #region Properties
        /// <summary>
        ///     Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public static Type CustomViewType { get; set; }
        #endregion
    }

    public partial interface IAlertConfig
    {
    }

    public partial class AlertConfig
    {
        #region Constructors
        public AlertConfig()
            : base()
        {
            CustomViewType = AlertConfigDefaults.CustomViewType;
        }
        #endregion
    }

    public partial class AlertAsyncConfig
    {
        #region Constructors
        public AlertAsyncConfig()
            : base()
        {
            CustomViewType = AlertConfigDefaults.CustomViewType;
        }
        #endregion
    }
}