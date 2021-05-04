using CoreGraphics;
using DialogMessaging.Schema;
using Foundation;
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
        /// Fades a UIView into focus.
        /// </summary>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void FadeIn(this UIView view, float animDuration, float delay = 0, Action finishedAction = null)
        {
            view.Alpha = 0f;
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.Animate(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Alpha = 1f;

            }, finishedAction);
        }

        /// <summary>
        /// Fades a UIView out of focus.
        /// </summary>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void FadeOut(this UIView view, float animDuration, float delay = 0, Action finishedAction = null)
        {
            view.Alpha = 1f;
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.Animate(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Alpha = 0f;

            }, finishedAction);
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
        /// Resizes the UILabel so that it can show all of its text.
        /// </summary>
        /// <param name="maxHeight">The maximum height that the label can be sized to.</param>
        public static void ResizeForTextHeight(this UILabel label, float maxHeight = 960f)
        {
            var labelWidth = label.Frame.Width;

            var intrinsicSize = ((NSString)label.Text ?? string.Empty).StringSize(label.Font, new CGSize(labelWidth, maxHeight), UILineBreakMode.WordWrap);

            var labelFrame = label.Frame;

            labelFrame.Size = new CGSize(labelWidth, intrinsicSize.Height);

            label.Frame = labelFrame;
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
