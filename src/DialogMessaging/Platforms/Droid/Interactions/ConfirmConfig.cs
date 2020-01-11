namespace DialogMessaging.Interactions
{
    public partial class ConfirmConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ID of the layout file to use.
        /// </summary>
        public int? LayoutID { get; set; } = DefaultLayoutID;

        /// <summary>
        /// Gets or sets the ID of the style to use.
        /// </summary>
        public int? StyleID { get; set; } = DefaultStyleID;
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the ID of the layout file to use by default.
        /// </summary>
        public static int? DefaultLayoutID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the style to use by default.
        /// </summary>
        public static int? DefaultStyleID { get; set; }
        #endregion
    }
}
