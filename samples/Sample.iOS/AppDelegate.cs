using DialogMessaging;
using Foundation;
using UIKit;

namespace Sample.iOS
{
    [Register ("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            MessagingServiceCore.Init();
            MessagingServiceCore.Delegate = new MessagingDelegate();

            return true;
        }
    }
}
