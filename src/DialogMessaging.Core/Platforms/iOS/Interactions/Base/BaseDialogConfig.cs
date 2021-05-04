using System;

namespace DialogMessaging.Interactions.Base
{
    public partial interface IBaseDialogConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        Type CustomViewType { get; set; }
        #endregion
    }

    public partial class BaseDialogConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public Type CustomViewType { get; set; }
        #endregion
    }

    public partial class BaseDialogAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public Type CustomViewType { get; set; }
        #endregion
    }
}
