using DialogMessaging;
using DialogMessaging.Interactions;
using Foundation;
using Sample.iOS.Dialogs;
using UIKit;

namespace Sample.iOS
{
    [Register ("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Initialize the messaging service, with the app's current window.
            // Overflow initializer methods are available for more advanced use cases.
            MessagingService.Init(Window);

            // Provide the messaging service with a custom messaging delegate.
            // This allows us to be notified when specific dialogs are requested meaning that we can alter
            // the configuration, or even deny the dialog showing.
            MessagingService.Delegate = new MessagingDelegate();

            // Assign defaults to certain dialogs, as we would like these to be persistant throughout.
            // These values can be overwritten, and will already have been applied to the dialog configuration
            // object by the time it reaches the messaging delegate.
            SnackbarConfigDefaults.ActionButtonTextColor = UIColor.White;
            SnackbarConfigDefaults.CustomViewType = typeof(MaterialSnackbar);
            SnackbarConfigDefaults.MessageTextColor = UIColor.White;

            return true;
        }
    }
}
