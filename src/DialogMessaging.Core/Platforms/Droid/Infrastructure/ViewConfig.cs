using Android.Views;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure
{
    public class ViewConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the dialog element.
        /// </summary>
        public string DialogElement { get; set; }

        /// <summary>
        /// Gets or sets whether the view should be hidden when not in use.
        /// </summary>
        public bool HideWhenNotInUse { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public View View { get; set; }
        #endregion
    }
}
