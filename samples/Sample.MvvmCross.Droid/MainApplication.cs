using Android.App;
using Android.Graphics;
using Android.Runtime;
using DialogMessaging;
using DialogMessaging.Interactions;
using Google.Android.Material.Snackbar;
using MvvmCross.Platforms.Android.Views;
using System;

namespace Sample.MvvmCross.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, Core.App>
    {
        public override void OnCreate()
        {
            base.OnCreate();

            MessagingService.Init(this);
            MessagingService.Delegate = new MessagingDelegate();

            ISnackbarConfig.DefaultActionButtonTextColor = Color.White;
            ISnackbarConfig.DefaultDuration = Snackbar.LengthLong;
            ISnackbarConfig.DefaultMessageTextColor = Color.White;
        }

        public MainApplication()
            : base()
        {
        }

        public MainApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
    }
}