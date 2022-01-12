using System;

namespace DialogMessaging.Core.Platforms.iOS.Attributes
{
    public sealed class DialogViewAttribute : Attribute
    {
        #region Constructors
        public DialogViewAttribute(string nibName)
            : base()
        {
            NibName = nibName;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the name of the NIB/XIB file associated with the view.
        /// </summary>
        public string NibName { get; }
        #endregion
    }
}