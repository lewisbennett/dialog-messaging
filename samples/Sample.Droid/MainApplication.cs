using System;
using Android.App;
using Android.Graphics;
using Android.Runtime;
using DialogMessaging;
using DialogMessaging.Interactions;
using Google.Android.Material.Snackbar;

//using ViewPump;

namespace Sample.Droid;

[Application]
public class MainApplication : Application
{
    public override void OnCreate()
    {
        base.OnCreate();

        // Optionally, initialize the intercepting service (ViewPump) before initializing the messaging service.
        // Useful for if you're using ViewPump for other purposes (for example: providing a custom IInterceptingService).
        //InterceptingService.Init();

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