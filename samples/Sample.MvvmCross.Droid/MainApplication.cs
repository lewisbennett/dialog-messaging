using Android.App;
using Android.Graphics;
using Android.Runtime;
using Android.Support.Design.Widget;
using DialogMessaging;
using DialogMessaging.Interactions;
using MvvmCross.Droid.Support.V7.AppCompat;
using System;

namespace Sample.MvvmCross.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<Setup, Core.App>
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