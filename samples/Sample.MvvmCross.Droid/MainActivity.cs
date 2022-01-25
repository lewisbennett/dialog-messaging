using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using Sample.MvvmCross.Core;

//using DialogMessaging;

namespace Sample.MvvmCross.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // The messaging service can also be initialized in your main activity.
            // We have initialized the messaging service inside MainApplication though instead.
            // See MainApplication for more details.
            //MessagingService.Init(this);

            SetContentView(Resource.Layout.activity_main);
        }
    }
}