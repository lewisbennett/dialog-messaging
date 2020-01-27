using CoreGraphics;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.iOS.Infrastructure;
using Foundation;
using System;
using UIKit;

namespace DialogMessaging.Platforms.iOS.Alerts
{
    public class DefaultToast : UIView, IValueAssigner, IShowable
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the snackbar is showing.
        /// </summary>
        public bool IsShowing { get; set; }

        /// <summary>
        /// Gets the message label.
        /// </summary>
        public UILabel MessageLabel { get; } = new UILabel();
        #endregion

        #region Public Methods
        /// <summary>
        /// Assign configuration values to UI elements.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void AssignValues(object config)
        {
            if (!(config is IToastConfig toastConfig))
                return;

            MessageLabel.Text = toastConfig.Message;

            SetNeedsLayout();
            LayoutIfNeeded();
        }

        /// <summary>
        /// Hides the snackbar.
        /// </summary>
        public void Hide(Action finishedAction = null)
        {
            if (!IsShowing)
                return;

            IsShowing = false;

            this.FadeOut(0.3f, finishedAction: () =>
            {
                finishedAction?.Invoke();

                try
                {
                    RemoveFromSuperview();
                    Dispose();
                }
                catch (Exception e)
                {
                    Log.Debug("Hide Snackbar", e.ToString());
                }
            });
        }

        /// <summary>
        /// Shows the snackbar.
        /// </summary>
        public void Show(Action finishedAction = null)
        {
            UIApplication.SharedApplication.KeyWindow.AddSubview(this);

            LayoutIfNeeded();

            this.FadeIn(0.3f, finishedAction: finishedAction);

            IsShowing = true;
        }
        #endregion

        #region Lifecycle
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var keyWindow = UIApplication.SharedApplication.KeyWindow;

            var toastWidth = keyWindow.Bounds.Width - 32;
            var toastWidthWithPadding = toastWidth - 32;

            MessageLabel.SetFrame(16, 16, toastWidthWithPadding - 16, 0);
            MessageLabel.ResizeForTextHeight();
            MessageLabel.ResizeForTextWidth();

            toastWidth = (nfloat)Math.Min(toastWidth, MessageLabel.Frame.Width + 32);

            this.SetCenter(keyWindow.Center.X, 0);
            this.SetFrame(Center.X - (toastWidth / 2), keyWindow.Bounds.Height - (keyWindow.Bounds.Height / 5), toastWidth, MessageLabel.Frame.Height + 32);

            Layer.CornerRadius = (MessageLabel.Font.LineHeight + 32) / 2;
        }
        #endregion

        #region Constructors
        public DefaultToast()
            : base()
        {
            Initialize();
        }

        public DefaultToast(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public DefaultToast(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public DefaultToast(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        public DefaultToast(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
        #endregion

        #region Private Methods
        private void AssignOwnership()
        {
            AddSubviews(MessageLabel);
        }

        private void Initialize()
        {
            Tag = 18571;

            AssignOwnership();

            StyleViews();
        }

        private void StyleViews()
        {
            BackgroundColor = UIColor.DarkGray;

            MessageLabel.Font = UIFont.SystemFontOfSize(15);
            MessageLabel.TextColor = UIColor.White;
            MessageLabel.Lines = 0;
        }
        #endregion
    }
}
