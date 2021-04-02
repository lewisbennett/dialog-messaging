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

            SnackbarConfigDefaults.ActionButtonTextColor = Color.White;
            SnackbarConfigDefaults.Duration = Snackbar.LengthLong;
            SnackbarConfigDefaults.MessageTextColor = Color.White;
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