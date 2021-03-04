using Android.Views;
using DialogMessaging.Core.Platforms.Droid.ViewManager.Base;
using DialogMessaging.Infrastructure;

namespace DialogMessaging.Core.Platforms.Droid.ViewManager
{
    public class DialogMessagingViewManager : BaseViewManager
    {
        #region Protected Methods
        protected override View InflateView(int layoutResId, ViewGroup container, bool attachToRoot)
        {
            return LayoutInflater.From(MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity).Inflate(layoutResId, container, attachToRoot);
        }
        #endregion
    }
}
