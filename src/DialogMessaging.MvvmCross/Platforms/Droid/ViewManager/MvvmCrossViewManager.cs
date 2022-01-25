using Android.Content;
using Android.Views;
using DialogMessaging.Core.Platforms.Droid.ViewManager.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace DialogMessaging.MvvmCross.Platforms.Droid.ViewManager
{
    public class MvvmCrossViewManager : BaseViewManager
    {
        #region Protected Methods
        protected override View InflateView(Context context, int layoutResId, ViewGroup container, bool attachToRoot)
        {
            // To be able to access the view and its attributes via a custom MvxAndroidViewBinder, IMvxBindingContextOwner.BindingInflate must be used to inflate the view.
            if (context is IMvxBindingContextOwner contextOwner)
                return contextOwner.BindingInflate(layoutResId, container, attachToRoot);

            // As a worst case, use base.
            else
                return base.InflateView(context, layoutResId, container, attachToRoot);
        }
        #endregion
    }
}