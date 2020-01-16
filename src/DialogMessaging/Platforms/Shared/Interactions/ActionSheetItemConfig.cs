using System;

namespace DialogMessaging.Interactions
{
    public partial interface IActionSheetItemConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the item is clicked.
        /// </summary>
        Action ClickAction { get; }

        /// <summary>
        /// An optional data payload.
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// Gets or sets the item's text.
        /// </summary>
        string Text { get; set; }
        #endregion
    }

    public partial class ActionSheetItemConfig : IActionSheetItemConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the item is clicked.
        /// </summary>
        public Action ClickAction { get; set; }

        /// <summary>
        /// An optional data payload.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the item's text.
        /// </summary>
        public string Text { get; set; }
        #endregion
    }

    public partial class ActionSheetItemAsyncConfig : IActionSheetItemConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the item is clicked.
        /// </summary>
        public Action ClickAction { get; internal set; }

        /// <summary>
        /// An optional data payload.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the item's text.
        /// </summary>
        public string Text { get; set; }
        #endregion
    }
}
