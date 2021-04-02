using Android.Content;
using Android.Util;
using Android.Views;
using DialogMessaging;
using MvvmCross.Platforms.Android.Binding.Binders;

namespace Sample.MvvmCross.Droid.Binding
{
    public class ViewBinder : MvxAndroidViewBinder
    {
        public override void BindView(View view, Context context, IAttributeSet attrs)
        {
            base.BindView(view, context, attrs);

            MessagingService.ViewManager.OnViewInflated(view, attrs);
        }

        public ViewBinder(object source)
            : base(source)
        {
        }
    }
}