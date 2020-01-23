using CoreGraphics;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.iOS.Infrastructure;
using Foundation;
using System;
using UIKit;

namespace DialogMessaging.Platforms.iOS.Alerts
{
    public class DefaultSnackbar : UIView, IValueAssigner, IShowable
    {
        #region Properties
        /// <summary>
        /// Gets the action button.
        /// </summary>
        public UIButton ActionButton { get; } = new UIButton();

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public ISnackbarConfig Config { get; set; }

        /// <summary>
        /// Gets or sets whether the snackbar is showing.
        /// </summary>
        public bool IsShowing { get; set; }

        /// <summary>
        /// Gets the message label.
        /// </summary>
        public UILabel MessageLabel { get; } = new UILabel();
        #endregion

        #region Event Handlers
        private void ActionButton_TouchUpInside(object sender, EventArgs e)
        {
            Config?.ActionButtonClickAction?.Invoke();

            Hide();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assign configuration values to UI elements.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void AssignValues(object config)
        {
            if (!(config is ISnackbarConfig snackbarConfig))
                return;

            Config = snackbarConfig;

            MessageLabel.Text = Config.Message;

            ActionButton.SetTitle(Config.ActionButtonText?.ToUpper(), UIControlState.Normal);
            ActionButton.Hidden = string.IsNullOrWhiteSpace(Config.ActionButtonText);

            if (Config.BackgroundColor != null)
                BackgroundColor = Config.BackgroundColor;

            if (Config.MessageTextColor != null)
                MessageLabel.TextColor = Config.MessageTextColor;

            if (Config.MessageFont != null)
                MessageLabel.Font = Config.MessageFont;

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

            this.SlideOutVertically(0.3f, finishedAction: () =>
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

            this.SlideInVertically(0.3f);

            IsShowing = true;
        }
        #endregion

        #region Lifecycle
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var keyWindow = UIApplication.SharedApplication.KeyWindow;

            var snackbarWidth = (nfloat)Math.Min(600, Bounds.Width);
            var snackbarWidthWithPadding = snackbarWidth - 32;

            nfloat height;

            if (!ActionButton.Hidden)
            {
                // First we resize the view height based on the maximum width this item is allowed to occupy.
                // Then we resize it for width to remove any white space.
                ActionButton.SetFrame(0, 0, snackbarWidthWithPadding / 2, 0);
                ActionButton.ResizeForTextHeight();
                ActionButton.ResizeForTextWidth();

                MessageLabel.SetFrame(16, 16, snackbarWidthWithPadding - ActionButton.Frame.Width - 16, 0);
                MessageLabel.ResizeForTextHeight();

                ActionButton.SetFrame(MessageLabel.Frame.X + MessageLabel.Frame.Width + 16, 16, ActionButton.Frame.Width, ActionButton.Frame.Height);

                if (MessageLabel.Frame.Height > ActionButton.Frame.Height)
                    ActionButton.SetCenter(ActionButton.Center.X, MessageLabel.Center.Y);
                else
                    MessageLabel.SetCenter(MessageLabel.Center.X, ActionButton.Center.Y);

                height = (nfloat)Math.Max(MessageLabel.Frame.Height, ActionButton.Frame.Height) + 32;
            }
            else
            {
                MessageLabel.SetFrame(16, 16, snackbarWidthWithPadding - 16, 0);
                MessageLabel.ResizeForTextHeight();

                height = MessageLabel.Frame.Height + 32;
            }

            this.SetCenter(keyWindow.Center.X, 0);
            this.SetFrame(Center.X - (snackbarWidth / 2), keyWindow.Bounds.Height, snackbarWidth, height + keyWindow.SafeAreaInsets.Bottom);
        }
        #endregion

        #region Constructors
        public DefaultSnackbar()
            : base()
        {
            Initialize();
        }

        public DefaultSnackbar(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public DefaultSnackbar(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public DefaultSnackbar(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        public DefaultSnackbar(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
        #endregion

        #region Private Methods
        private void AssignOwnership()
        {
            AddSubviews(MessageLabel, ActionButton);
        }

        private void Initialize()
        {
            Tag = 92175;

            AssignOwnership();

            StyleViews();

            ActionButton.TouchUpInside += ActionButton_TouchUpInside;
        }

        private void StyleViews()
        {
            BackgroundColor = UIColor.DarkGray;

            ActionButton.Font = UIFont.SystemFontOfSize(15, UIFontWeight.Bold);
            ActionButton.SetTitleColor(UIColor.White, UIControlState.Normal);

            MessageLabel.Font = UIFont.SystemFontOfSize(15);
            MessageLabel.TextColor = UIColor.White;
            MessageLabel.Lines = 0;
        }
        #endregion
    }
}
