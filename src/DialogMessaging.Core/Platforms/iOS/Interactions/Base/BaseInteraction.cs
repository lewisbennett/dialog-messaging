using System;

namespace DialogMessaging.Interactions.Base
{
    public partial interface IBaseInteraction
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        Type CustomViewType { get; set; }
        #endregion
    }

    public partial class BaseInteraction
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public Type CustomViewType { get; set; }
        #endregion
    }

    public partial class BaseAsyncInteraction
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public Type CustomViewType { get; set; }
        #endregion
    }
}
