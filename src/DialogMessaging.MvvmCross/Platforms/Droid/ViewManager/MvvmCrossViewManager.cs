using Android.Views;
using DialogMessaging.Core.Platforms.Droid.ViewManager.Base;
using DialogMessaging.Infrastructure;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace DialogMessaging.MvvmCross.Platforms.Droid.ViewManager
{
    public class MvvmCrossViewManager : BaseViewManager
    {
        #region Protected Methods
        protected override View InflateView(int layoutResId, ViewGroup container, bool attachToRoot)
        {
            var activity = MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity;

            if (activity is IMvxBindingContextOwner contextOwner)
                return contextOwner.BindingInflate(layoutResId, container, attachToRoot);
            else
                return LayoutInflater.From(activity).Inflate(layoutResId, container, attachToRoot);
        }
        #endregion
    }
}
