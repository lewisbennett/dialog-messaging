using CoreGraphics;
using DialogMessaging.Infrastructure;
using DialogMessaging.Schema;
using Foundation;
using System;
using UIKit;

namespace DialogMessaging
{
    public static partial class Extensions
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
                textField.ResignFirstResponder();
                return true;
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
            if (view == null)
                return;

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
            if (view == null)
                return;

            view.Alpha = 1f;
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.Animate(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Alpha = 0f;

            }, finishedAction);
        }

        /// <summary>
        /// Slides a view vertically into focus.
        /// </summary>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void SlideInVertically(this UIView view, float animDuration, float delay = 0, Action finishedAction = null)
        {
            if (view == null)
                return;

            view.Alpha = 0f;
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.Animate(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Alpha = 1f;
                view.Transform = CGAffineTransform.MakeTranslation(0, -1 * view.Bounds.Height);

            }, finishedAction);
        }

        /// <summary>
        /// Slides a view vertically out of focus.
        /// </summary>
        /// <param name="animDuration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation starts.</param>
        /// <param name="finishedAction">The action invoked upon animation completion.</param>
        public static void SlideOutVertically(this UIView view, float animDuration, float delay = 0, Action finishedAction = null)
        {
            if (view == null)
                return;

            view.Alpha = 1f;
            view.Transform = CGAffineTransform.MakeTranslation(0, -1 * view.Bounds.Height);

            UIView.Animate(animDuration, delay, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                view.Alpha = 0f;
                view.Transform = CGAffineTransform.MakeIdentity();

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
        public static void ResizeForTextHeight(this UIButton button, float maxHeight = 960f)
        {
            var buttonWidth = button.Frame.Width;

            var intrinsicSize = ((NSString)button.Title(UIControlState.Normal) ?? string.Empty).StringSize(button.Font, new CGSize(buttonWidth, maxHeight), UILineBreakMode.WordWrap);

            var buttonFrame = button.Frame;

            buttonFrame.Size = new CGSize(buttonWidth, intrinsicSize.Height);

            button.Frame = buttonFrame;
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
        /// Resizes the UILabel so that it can show all of its text.
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
        /// Resizes the UILabel so that it can show all of its text.
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
        /// Safely invokes an action on the main thread.
        /// </summary>
        /// <param name="action">The action to perform on the main thread.</param>
        public static void SafeInvokeOnMainThread(this UIDevice device, Action action)
        {
            if (device == null || action == null)
                return;

            device.InvokeOnMainThread(() =>
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception e)
                {
                    Log.Debug(string.Empty, e.ToString());
                }
            });
        }

        /// <summary>
        /// Sets the center without creating a new object.
        /// </summary>
        public static void SetCenter(this UIView view, nfloat x, nfloat y)
        {
            var center = view.Center;

            center.X = x;
            center.Y = y;

            view.Center = center;
        }

        /// <summary>
        /// Sets the frame without creating a new object.
        /// </summary>
        public static void SetFrame(this UIView view, nfloat x, nfloat y, nfloat width, nfloat height)
        {
            var frame = view.Frame;

            frame.X = x;
            frame.Y = y;
            frame.Width = width;
            frame.Height = height;

            view.Frame = frame;
        }
        #endregion
    }
}
