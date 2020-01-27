using System;

namespace DialogMessaging.Interactions
{
    public partial interface IAlertConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class AlertConfig
    {
        #region Constructors
        public AlertConfig()
        {
            ViewType = IAlertConfig.DefaultViewType;
        }
        #endregion
    }

    public partial class AlertAsyncConfig
    {
        #region Constructors
        public AlertAsyncConfig()
        {
            ViewType = IAlertConfig.DefaultViewType;
        }
        #endregion
    }
}
