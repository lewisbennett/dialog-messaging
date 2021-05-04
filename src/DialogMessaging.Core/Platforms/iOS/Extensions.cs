using DialogMessaging.Schema;
using System;
using System.Diagnostics;
using UIKit;

namespace DialogMessaging.Core.Platforms.iOS
{
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Configures the UITextField to match the provided input type.
        /// </summary>
        /// <param name="inputType">The input type to be applied.</param>
        public static void ApplyInputType(this UITextField textField, InputType inputType)
        {
            textField.ReturnKeyType = UIReturnKeyType.Done;

            textField.ShouldReturn += delegate
            {
                return textField.ResignFirstResponder();
            };

            switch (inputType)
            {
                case InputType.EmailAddress:
                    textField.KeyboardType = UIKeyboardType.EmailAddress;
                    return;

                case InputType.Name:
                    textField.AutocapitalizationType = UITextAutocapitalizationType.Words;
                    return;

                case InputType.Integer:
                    textField.KeyboardType = UIKeyboardType.NumberPad;
                    return;

                case InputType.Decimal:
                    textField.KeyboardType = UIKeyboardType.DecimalPad;
                    return;

                case InputType.PhoneNumber:
                    textField.KeyboardType = UIKeyboardType.PhonePad;
                    return;

                case InputType.URI:
                    textField.KeyboardType = UIKeyboardType.Url;
                    return;

                default:
                    return;
            }
        }

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
