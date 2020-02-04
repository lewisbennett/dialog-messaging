using System;

namespace DialogMessaging.Interactions
{
    public partial interface IDeleteConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class DeleteConfig
    {
        #region Constructors
        public DeleteConfig()
        {
            ViewType = IDeleteConfig.DefaultViewType;
        }
        #endregion
    }

    public partial class DeleteAsyncConfig
    {
        #region Constructors
        public DeleteAsyncConfig()
        {
            ViewType = IDeleteConfig.DefaultViewType;
        }
        #endregion
    }
}
