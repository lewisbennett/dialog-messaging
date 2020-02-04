using DialogMessaging;
using Foundation;
using MvvmCross.Platforms.Ios.Core;
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

            MessagingService.Init();
            MessagingService.Delegate = new MessagingDelegate();

            return result;
        }
    }
}
