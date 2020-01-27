using System;

namespace DialogMessaging.Interactions
{
    public partial interface IActionSheetBottomConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class ActionSheetBottomConfig
    {
        #region Constructors
        public ActionSheetBottomConfig()
        {
            ViewType = IActionSheetBottomConfig.DefaultViewType;
        }
        #endregion
    }

    public partial class ActionSheetBottomAsyncConfig
    {
        #region Constructors
        public ActionSheetBottomAsyncConfig()
        {
            ViewType = IActionSheetBottomConfig.DefaultViewType;
        }
        #endregion
    }
}
