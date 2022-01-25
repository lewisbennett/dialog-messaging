using System;

namespace DialogMessaging.Interactions
{
    public static partial class LoadingConfigDefaults
    {
        #region Properties
        /// <summary>
        /// Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public static Type CustomViewType { get; set; }
        #endregion
    }

    public partial interface ILoadingConfig
    {
    }

    public partial class LoadingConfig
    {
        #region Constructors
        public LoadingConfig()
            : base()
        {
            CustomViewType = LoadingConfigDefaults.CustomViewType;
        }
        #endregion
    }

    public partial class LoadingAsyncConfig
    {
        #region Constructors
        public LoadingAsyncConfig()
            : base()
        {
            CustomViewType = LoadingConfigDefaults.CustomViewType;
        }
        #endregion
    }
}
