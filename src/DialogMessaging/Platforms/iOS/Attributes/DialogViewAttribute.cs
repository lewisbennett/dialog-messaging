using System;

namespace DialogMessaging.Attributes
{
    public sealed class DialogViewAttribute : Attribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the NIB file associated with this UIView.
        /// </summary>
        public string NibName { get; set; }
        #endregion
    }
}
