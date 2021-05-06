using System;

namespace DialogMessaging.Interactions
{
    public static partial class PromptConfigDefaults
    {
        #region Properties
        /// <summary>
        /// Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public static Type CustomViewType { get; set; }
        #endregion
    }

    public partial interface IPromptConfig
    {
    }

    public partial class PromptConfig
    {
        #region Constructors
        public PromptConfig()
            : base()
        {
            CustomViewType = ActionSheetConfigDefaults.CustomViewType;
        }
        #endregion
    }

    public partial class PromptAsyncConfig
    {
        #region Constructors
        public PromptAsyncConfig()
            : base()
        {
            CustomViewType = ActionSheetConfigDefaults.CustomViewType;
        }
        #endregion
    }
}
