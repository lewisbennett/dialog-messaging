using CoreGraphics;
using DialogMessaging.Infrastructure;
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
        ///     Configures the UITextField to match the provided input type.
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
        ///     Fades a UIView into focus.
        /// </summary>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void FadeIn(this UIView view, float animDuration, float delay = 0, Action finishedAction = null)
        {
            view.Alpha = 0f;
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.AnimateNotify(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Alpha = 1f;

            }, (hasFinished) =>
            {
                if (hasFinished)
                    finishedAction?.Invoke();
            });
        }

        /// <summary>
        ///     Fades a UIView out of focus.
        /// </summary>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void FadeOut(this UIView view, float animDuration, float delay = 0, Action finishedAction = null)
        {
            view.Alpha = 1f;
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.AnimateNotify(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Alpha = 0f;

            }, (hasFinished) =>
            {
                if (hasFinished)
                    finishedAction?.Invoke();
            });
        }

        /// <summary>
        ///     Gets the top level UIViewController.
        /// </summary>
        public static UIViewController GetTopViewController(this UIApplication application)
        {
            var viewController = application.KeyWindow.RootViewController;

            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            return viewController;
        }

        /// <summary>
        ///     Resizes the UILabel so that it can show all of its text.
        /// </summary>
        /// <param name="maxHeight">The maximum height that the label can be sized to.</param>
        public static void ResizeForTextHeight(this UIButton button, float maxHeight = 960f)
        {
            var buttonWidth = button.Frame.Width;

            var intrinsicSize = ((NSString)button.Title(UIControlState.Normal) ?? string.Empty).StringSize(button.Font, new CGSize(buttonWidth, maxHeight), UILineBreakMode.WordWrap);

            var buttonFrame = button.Frame;

            buttonFrame.Size = new CGSize(buttonWidth, intrinsicSize.Height);

            button.Frame = buttonFrame;
        }

        /// <summary>
        ///     Resizes the UILabel so that it can show all of its text.
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
        ///     Resizes the UILabel so that it can show all of its text.
        /// </summary>
        /// <param name="maxHeight">The maximum width that the label can be sized to.</param>
        public static void ResizeForTextWidth(this UIButton button, float maxWidth = 960f)
        {
            var buttonHeight = button.Frame.Height;

            var intrinsicSize = ((NSString)button.Title(UIControlState.Normal) ?? string.Empty).StringSize(button.Font, new CGSize(maxWidth, buttonHeight), UILineBreakMode.WordWrap);

            var buttonFrame = button.Frame;

            buttonFrame.Size = new CGSize(intrinsicSize.Width, buttonHeight);

            button.Frame = buttonFrame;
        }

        /// <summary>
        ///     Resizes the UILabel so that it can show all of its text.
        /// </summary>
        /// <param name="maxHeight">The maximum width that the label can be sized to.</param>
        public static void ResizeForTextWidth(this UILabel label, float maxWidth = 960f)
        {
            var labelHeight = label.Frame.Height;

            var intrinsicSize = ((NSString)label.Text ?? string.Empty).StringSize(label.Font, new CGSize(maxWidth, labelHeight), UILineBreakMode.WordWrap);

            var labelFrame = label.Frame;

            labelFrame.Size = new CGSize(intrinsicSize.Width, labelHeight);

            label.Frame = labelFrame;
        }

        /// <summary>
        ///     Safely invokes an action on the main thread.
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

        /// <summary>
        ///     Slides a view vertically into focus.
        /// </summary>
        /// <param name="direction">The direction to slide the view in via. Top (positive) or bottom (negative).</param>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void SlideInVertically(this UIView view, int direction, float animDuration, float delay = 0, Action finishedAction = null)
        {
            nfloat ty;

            if (direction > 0)
                ty = 0 - view.Frame.Height;

            else
                ty = MessagingServiceCore.Window.Bounds.Height - view.Frame.Y;

            view.Transform = CGAffineTransform.MakeTranslation(0, ty);

            UIView.AnimateNotify(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Transform = CGAffineTransform.MakeIdentity();

            }, (hasFinished) =>
            {
                if (hasFinished)
                    finishedAction?.Invoke();
            });
        }

        /// <summary>
        ///     Slides a view vertically out of focus.
        /// </summary>
        /// <param name="direction">The direction to slide the view in via. Top (positive) or bottom (negative).</param>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void SlideOutVertically(this UIView view, int direction, float animDuration, float delay = 0, Action finishedAction = null)
        {
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.AnimateNotify(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                nfloat ty;

                if (direction > 0)
                    ty = 0 - view.Frame.Height;

                else
                    ty = MessagingServiceCore.Window.Bounds.Height - view.Frame.Y;

                view.Transform = CGAffineTransform.MakeTranslation(0, ty);

            }, (hasFinished) =>
            {
                if (hasFinished)
                    finishedAction?.Invoke();
            });
        }
        #endregion
    }
}