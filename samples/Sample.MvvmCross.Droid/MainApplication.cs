using System;
using Android.App;
using Android.Graphics;
using Android.Runtime;
using DialogMessaging;
using DialogMessaging.Interactions;
using Google.Android.Material.Snackbar;
using MvvmCross.Platforms.Android.Views;
using Sample.MvvmCross.Core;

namespace Sample.MvvmCross.Droid;

[Application]
public class MainApplication : MvxAndroidApplication<Setup, App>
{
    public MainApplication()
    {
    }

    public MainApplication(IntPtr handle, JniHandleOwnership transfer)
        : base(handle, transfer)
    {
    }

    public override void OnCreate()
    {
        base.OnCreate();

        // Initialize the messaging service, passing in the current Application context.
        // Overflow initializer methods are available for more advanced use cases.
        MessagingService.Init(this);

        // Provide the messaging service with a custom messaging delegate.
        // This allows us to be notified when specific dialogs are requested meaning that we can alter
        // the configuration, or even deny the dialog showing.
        MessagingService.Delegate = new MessagingDelegate();

        // Assign defaults to certain dialogs, as we would like these to be persistant throughout.
        // These values can be overwritten, and will already have been applied to the dialog configuration
        // object by the time it reaches the messaging delegate.
        AlertConfigDefaults.Cancelable = true;
        AlertConfigDefaults.LayoutResID = Resource.Layout.dialog_alert;
        AlertConfigDefaults.StyleResID = Resource.Style.AppTheme_Dialog_Alert;

        SnackbarConfigDefaults.ActionButtonTextColor = Color.White;
        SnackbarConfigDefaults.Duration = BaseTransientBottomBar.LengthLong;
        SnackbarConfigDefaults.MessageTextColor = Color.White;
    }
}