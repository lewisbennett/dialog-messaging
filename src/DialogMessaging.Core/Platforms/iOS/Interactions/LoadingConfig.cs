using System;

namespace DialogMessaging.Interactions
{
    public partial interface ILoadingConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class LoadingConfig
    {
        #region Constructors
        public LoadingConfig()
        {
            ViewType = ILoadingConfig.DefaultViewType;
        }
        #endregion
    }

    public partial class LoadingAsyncConfig
    {
        #region Constructors
        public LoadingAsyncConfig()
        {
            ViewType = ILoadingConfig.DefaultViewType;
        }
        #endregion
    }
}
