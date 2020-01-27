using System;

namespace DialogMessaging.Interactions
{
    public partial interface IActionSheetConfig
    {
        #region Constructors
        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class ActionSheetConfig
    {
        #region Constructors
        public ActionSheetConfig()
        {
            ViewType = IActionSheetConfig.DefaultViewType;
        }
        #endregion
    }

    public partial class ActionSheetAsyncConfig
    {
        #region Constructors
        public ActionSheetAsyncConfig()
        {
            ViewType = IActionSheetConfig.DefaultViewType;
        }
        #endregion
    }
}
