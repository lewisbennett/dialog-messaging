using System;
using System.Diagnostics;
using UIKit;

namespace DialogMessaging.Core.Platforms.iOS
{
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Gets the top level UIViewController.
        /// </summary>
        public static UIViewController GetTopViewController(this UIApplication application)
        {
            var viewController = application.KeyWindow.RootViewController;

            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            return viewController;
        }

        /// <summary>
        /// Safely invokes an action on the main thread.
        /// </summary>
        /// <param name="action">The action to perform on the main thread.</param>
        public static void SafeInvokeOnMainThread(this UIDevice device, Action action)
        {
            device.InvokeOnMainThread(() =>
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            });
        }
        #endregion
    }
}
