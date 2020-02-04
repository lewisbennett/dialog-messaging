using System;

namespace DialogMessaging.Interactions
{
    public partial interface IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the view type.
        /// </summary>
        Type ViewType { get; set; }
        #endregion
    }

    public partial class BaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the view type.
        /// </summary>
        public Type ViewType { get; set; }
        #endregion
    }

    public partial class BaseAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the view type.
        /// </summary>
        public Type ViewType { get; set; }
        #endregion
    }
}
