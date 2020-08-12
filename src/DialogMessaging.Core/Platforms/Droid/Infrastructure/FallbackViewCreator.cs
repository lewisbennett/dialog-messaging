using Android.Views;
using DialogMessaging.Infrastructure;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure
{
    public class FallbackViewCreator : IViewCreator
    {
        #region Public Methods
        /// <summary>
        /// Create the view for a dialog fragment.
        /// </summary>
        /// <param name="valueAssigner">The context.</param>
        /// <param name="layoutResId">The resource ID of the layout.</param>
        /// <param name="container">The view container, if any.</param>
        /// <param name="attachToRoot">Whether to attach this view to the root view.</param>
        public View CreateView(IValueAssigner valueAssigner, int layoutResId, ViewGroup container, bool attachToRoot)
        {
            var view = LayoutInflater.From(valueAssigner.Context).Inflate(layoutResId, container, attachToRoot);

            foreach (var subview in view.Find(v => MessagingServiceCore.InflatedViews.ContainsKey(v)))
                valueAssigner.AssignValue(MessagingServiceCore.InflatedViews[subview]);

            return view;
        }
        #endregion
    }
}
