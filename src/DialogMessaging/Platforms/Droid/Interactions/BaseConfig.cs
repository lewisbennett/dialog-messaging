namespace DialogMessaging.Interactions
{
    public partial interface IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the dialog is cancelable.
        /// </summary>
        bool Cancelable { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use.
        /// </summary>
        int? LayoutID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the style to use.
        /// </summary>
        int? StyleID { get; set; }
        #endregion
    }

    public partial class BaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the dialog is cancelable.
        /// </summary>
        public bool Cancelable { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use.
        /// </summary>
        public int? LayoutID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the style to use.
        /// </summary>
        public int? StyleID { get; set; }
        #endregion
    }

    public partial class BaseAsyncConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the dialog is cancelable.
        /// </summary>
        public bool Cancelable { get; set; }

        /// <summary>
        /// Gets or sets the ID of the layout file to use.
        /// </summary>
        public int? LayoutID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the style to use.
        /// </summary>
        public int? StyleID { get; set; }
        #endregion
    }
}
