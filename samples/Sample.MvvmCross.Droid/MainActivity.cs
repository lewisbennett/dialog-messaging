using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Sample.MvvmCross.Core;

namespace Sample.MvvmCross.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);
        }
    }
}
