using System;

namespace DialogMessaging.Interactions
{
    public partial interface IPromptConfig
    {
        #region Static Properties
        /// <summary>
        /// Gets or sets the default view type.
        /// </summary>
        public static Type DefaultViewType { get; set; }
        #endregion
    }

    public partial class PromptConfig
    {
        #region Constructors
        public PromptConfig()
        {
            ViewType = IPromptConfig.DefaultViewType;
        }
        #endregion
    }

    public partial class PromptAsyncConfig
    {
        #region Constructors
        public PromptAsyncConfig()
        {
            ViewType = IPromptConfig.DefaultViewType;
        }
        #endregion
    }
}
