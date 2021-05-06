using System;

namespace DialogMessaging.Interactions
{
    public static partial class DeleteConfigDefaults
    {
        #region Properties
        /// <summary>
        /// Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public static Type CustomViewType { get; set; }
        #endregion
    }

    public partial interface IDeleteConfig
    {
    }

    public partial class DeleteConfig
    {
        #region Constructors
        public DeleteConfig()
            : base()
        {
            CustomViewType = ActionSheetConfigDefaults.CustomViewType;
        }
        #endregion
    }

    public partial class DeleteAsyncConfig
    {
        #region Constructors
        public DeleteAsyncConfig()
            : base()
        {
            CustomViewType = ActionSheetConfigDefaults.CustomViewType;
        }
        #endregion
    }
}
