using Android.Views;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace DialogMessaging.MvvmCross.Platforms.Droid
{
    public class MvvmCrossViewCreator : IViewCreator
    {
        #region Public Methods
        /// <summary>
        /// Create the view for a dialog fragment.
        /// </summary>
        /// <param name="valueAssigner">The value assigner.</param>
        /// <param name="layoutResId">The resource ID of the layout.</param>
        /// <param name="container">The view container, if any.</param>
        /// <param name="attachToRoot">Whether to attach this view to the root view.</param>
        public View CreateView(IValueAssigner valueAssigner, int layoutResId, ViewGroup container, bool attachToRoot)
        {
            View view = null;

            if (valueAssigner.Context is IMvxBindingContextOwner contextOwner)
                view = contextOwner.BindingInflate(layoutResId, container, attachToRoot);
            else
                view = LayoutInflater.From(valueAssigner.Context).Inflate(layoutResId, container, attachToRoot);

            foreach (var subview in view.Find(v => MessagingService.InflatedViews.ContainsKey(v)))
                valueAssigner?.AssignValue(MessagingService.InflatedViews[subview]);

            return view;
        }
        #endregion
    }
}
