using DialogMessaging;
using DialogMessaging.Interactions;
using Foundation;
using MvvmCross.Platforms.Ios.Core;
using Sample.MvvmCross.iOS.Dialogs;
using UIKit;

namespace Sample.MvvmCross.iOS
{
    [Register ("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, Core.App>
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            // Initialize the messaging service.
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

            return result;
        }
    }
}
