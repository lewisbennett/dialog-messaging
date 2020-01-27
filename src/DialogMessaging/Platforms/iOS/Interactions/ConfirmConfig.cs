using System;

namespace DialogMessaging.Interactions
{
    public partial interface IConfirmConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class ConfirmConfig
    {
        #region Constructors
        public ConfirmConfig()
        {
            ViewType = IConfirmConfig.DefaultViewType;
        }
        #endregion
    }

    public partial class ConfirmAsyncConfig
    {
        #region Constructors
        public ConfirmAsyncConfig()
        {
            ViewType = IConfirmConfig.DefaultViewType;
        }
        #endregion
    }
}
