using System;
using CoreGraphics;
using DialogMessaging.Core.Platforms.iOS;
using DialogMessaging.Core.Platforms.iOS.Infrastructure;
using DialogMessaging.Interactions;
using Foundation;
using UIKit;

namespace Sample.MvvmCross.iOS.Dialogs
{
    public class MaterialSnackbar : UIView, ICustomDialog<ISnackbarConfig>
    {
        #region Fields
        private ISnackbarConfig _config;
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the action button.
        /// </summary>
        public UIButton ActionButton { get; } = new();

        /// <summary>
        ///     Gets the background view.
        /// </summary>
        public UIView BackgroundView { get; } = new();

        /// <summary>
        ///     Gets or sets whether the view is currently showing.
        /// </summary>
        public bool IsShowing { get; set; }

        /// <summary>
        ///     Gets the message label.
        /// </summary>
        public UILabel MessageLabel { get; } = new();
        #endregion

        #region Event Handlers
        private void ActionButton_TouchUpInside(object sender, EventArgs e)
        {
            _config.ActionButtonClickAction?.Invoke();

            Dismiss();
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///     Applies the provided dialog configuration to the view.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public void ApplyDialogConfig(ISnackbarConfig config)
        {
            _config = config;

            // Configure message.
            if (!string.IsNullOrWhiteSpace(_config.Message))
            {
                if (_config.MessageFont != null)
                    MessageLabel.Font = _config.MessageFont;

                if (_config.MessageTextColor != null)
                    MessageLabel.TextColor = _config.MessageTextColor;

                MessageLabel.Text = _config.Message;
            }

            if (_config.BackgroundColor != null)
                BackgroundView.BackgroundColor = _config.BackgroundColor;

            // Hide action button, or configure if text is available.
            if (string.IsNullOrWhiteSpace(_config.ActionButtonText))
                ActionButton.Hidden = true;

            else
            {
                if (_config.ActionButtonFont != null)
                    ActionButton.TitleLabel.Font = _config.ActionButtonFont;

                if (_config.ActionButtonTextColor != null)
                    ActionButton.SetTitleColor(_config.ActionButtonTextColor, UIControlState.Normal);

                ActionButton.SetTitle(_config.ActionButtonText, UIControlState.Normal);
            }

            SetNeedsLayout();
            LayoutIfNeeded();
        }

        /// <summary>
        ///     Dismisses the custom dialog.
        /// </summary>
        /// <param name="finishedAction">An optional action to invoke after the custom dialog has been dismissed.</param>
        public void Dismiss(Action finishedAction = null)
        {
            this.SlideOutVertically(-1, 0.3f, finishedAction: finishedAction);

            IsShowing = false;
        }

        /// <summary>
        ///     Shows the custom dialog.
        /// </summary>
        /// <param name="finishedAction">An optional action to invoke after the custom dialog has been shown.</param>
        public void Show(Action finishedAction = null)
        {
            this.SlideInVertically(-1, 0.3f, finishedAction: finishedAction);

            IsShowing = true;
        }
        #endregion

        #region Lifecycle
        /// <summary>
        ///     Lays out subviews.
        /// </summary>
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var keyWindow = UIApplication.SharedApplication.KeyWindow;

            var containerView = _config?.ContainerView ?? keyWindow;

            // Subtract 32 from the width of the view to add a "margin" around the view.
            var snackbarWidth = (nfloat)Math.Min(600, containerView.Frame.Width - 32);
            var snackbarWidthWithPadding = snackbarWidth - 32;

            nfloat height;

            if (ActionButton.Hidden)
            {
                // If the action button is hidden, the message label's frame is simply the allowed width.
                MessageLabel.Frame = new CGRect(16, 16, snackbarWidthWithPadding, 0);
                MessageLabel.ResizeForTextHeight();

                // The height of the Snackbar is the height of the message label plus padding.
                height = MessageLabel.Frame.Height + 32;
            }
            else
            {
                // First, we resize the view height based on the maximum width this item is allowed to occupy.
                // Then we resize it for width to remove any white space.
                ActionButton.Frame = new CGRect(0, 0, snackbarWidthWithPadding / 2, 0);
                ActionButton.ResizeForTextHeight();
                ActionButton.ResizeForTextWidth();

                // The width of the message label is the allowed width, subtract the width of the action button, subtract padding.
                MessageLabel.Frame = new CGRect(16, 16, snackbarWidthWithPadding - ActionButton.Frame.Width - 16, 0);
                MessageLabel.ResizeForTextHeight();

                ActionButton.Frame = new CGRect(MessageLabel.Frame.X + MessageLabel.Frame.Width + 16, 16, ActionButton.Frame.Width, ActionButton.Frame.Height);

                if (MessageLabel.Frame.Height > ActionButton.Frame.Height)
                    ActionButton.Center = new CGPoint(ActionButton.Center.X, MessageLabel.Center.Y);

                else
                    MessageLabel.Center = new CGPoint(MessageLabel.Center.X, ActionButton.Center.Y);

                height = (nfloat)Math.Max(MessageLabel.Frame.Height, ActionButton.Frame.Height) + 32;
            }

            // Position the view in its final position once displayed.
            // The animation uses transforms to bring it into and out of view.
            var containerViewRect = containerView.ConvertRectToView(containerView.Frame, keyWindow);

            var y = containerViewRect.Y + containerViewRect.Height - containerView.SafeAreaInsets.Bottom - height;

            Frame = new CGRect(containerView.Center.X - (snackbarWidth / 2), y, snackbarWidth, keyWindow.Bounds.Height - y);

            BackgroundView.Frame = new CGRect(0, 0, Frame.Width, height);
        }
        #endregion

        #region Constructors
        public MaterialSnackbar()
            : base()
        {
            Initialize();
        }

        public MaterialSnackbar(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public MaterialSnackbar(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public MaterialSnackbar(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        public MaterialSnackbar(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
        #endregion

        #region Private Methods
        private void AssignOwnership()
        {
            AddSubview(BackgroundView);

            BackgroundView.AddSubviews(MessageLabel, ActionButton);
        }

        private void Initialize()
        {
            // A unique tag per type allows only one dialog of the same type to be shown at one time.
            Tag = 56285;

            AssignOwnership();

            StyleViews();

            ActionButton.TouchUpInside += ActionButton_TouchUpInside;
        }

        private void StyleViews()
        {
            BackgroundColor = UIColor.Clear;

            BackgroundView.BackgroundColor = UIColor.DarkGray;

            BackgroundView.Layer.CornerRadius = 5f;
            BackgroundView.Layer.MasksToBounds = false;
            BackgroundView.Layer.ShadowColor = UIColor.Gray.CGColor;
            BackgroundView.Layer.ShadowOffset = new CGSize(0f, 5f);
            BackgroundView.Layer.ShadowOpacity = 0.6f;

            ActionButton.Font = UIFont.SystemFontOfSize(15, UIFontWeight.Bold);
            ActionButton.SetTitleColor(UIColor.White, UIControlState.Normal);

            MessageLabel.Font = UIFont.SystemFontOfSize(15);
            MessageLabel.TextColor = UIColor.White;
            MessageLabel.Lines = 0;
        }
        #endregion
    }
}