using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using Sample.MvvmCross.Core;

namespace Sample.MvvmCross.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);
        }
    }
}
