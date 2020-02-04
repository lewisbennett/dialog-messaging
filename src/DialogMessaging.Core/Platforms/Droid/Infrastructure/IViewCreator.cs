using Android.Views;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure
{
    public interface IViewCreator
    {
        #region Public Methods
        /// <summary>
        /// Create the view for a dialog fragment.
        /// </summary>
        /// <param name="valueAssigner">The value assigner.</param>
        /// <param name="layoutResId">The resource ID of the layout.</param>
        /// <param name="container">The view container, if any.</param>
        /// <param name="attachToRoot">Whether to attach this view to the root view.</param>
        View CreateView(IValueAssigner valueAssigner, int layoutResId, ViewGroup container, bool attachToRoot);
        #endregion
    }
}
