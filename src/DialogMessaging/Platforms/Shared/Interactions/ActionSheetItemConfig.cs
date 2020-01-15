namespace DialogMessaging.Interactions
{
    public partial interface IActionSheetItemConfig
    {
        #region Properties
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
