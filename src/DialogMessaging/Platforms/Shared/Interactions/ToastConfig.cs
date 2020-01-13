namespace DialogMessaging.Interactions
{
    public partial interface IToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }
        #endregion
    }

    public partial class ToastConfig : IToastConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
        #endregion
    }
}
