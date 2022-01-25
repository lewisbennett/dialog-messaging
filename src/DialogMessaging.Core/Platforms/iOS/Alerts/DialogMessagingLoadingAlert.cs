using CoreGraphics;
using DialogMessaging.Core.Platforms.iOS.Infrastructure;
using DialogMessaging.Interactions;
using Foundation;
using System;
using System.ComponentModel;
using UIKit;

namespace DialogMessaging.Core.Platforms.iOS.Alerts
{
    public class DialogMessagingLoadingAlert : UIView, ICustomDialog<ILoadingConfig>
    {
        #region Fields
        private ILoadingConfig _config;
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the alert background.
        /// </summary>
        public UIView AlertBackground { get; } = new();

        /// <summary>
        ///     Gets the alert background blur.
        /// </summary>
        public UIVisualEffectView AlertBackgroundBlur { get; } = new();

        /// <summary>
        ///     Gets the determinate progress view.
        /// </summary>
        public UIProgressView DeterminateProgress { get; } = new(UIProgressViewStyle.Bar);

        /// <summary>
        ///     Gets the dimmer background.
        /// </summary>
        public UIView DimmerBackground { get; } = new();

        /// <summary>
        ///     Gets the indeterminate progress view.
        /// </summary>
        public UIActivityIndicatorView IndeterminateProgress { get; } = new();

        /// <summary>
        ///     Gets or sets whether the view is currently showing.
        /// </summary>
        public bool IsShowing { get; set; }

        /// <summary>
        ///     Gets the message label.
        /// </summary>
        public UILabel MessageLabel { get; } = new();

        /// <summary>
        ///     Gets the title label.
        /// </summary>
        public UILabel TitleLabel { get; } = new();
        #endregion

        #region Event Handlers
        private void Config_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_config.Progress):

                    AdjustProgress();

                    return;

                default:

                    return;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///     Applies the provided dialog configuration to the view.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public void ApplyDialogConfig(ILoadingConfig config)
        {
            // Unregister the previous event handler, if a previous configuration is available.
            if (_config != null)
                _config.PropertyChanged -= Config_PropertyChanged;

            _config = config;

            AdjustProgress();

            TitleLabel.Text = _config.Title;
            MessageLabel.Text = _config.Message;

            TitleLabel.Hidden = string.IsNullOrWhiteSpace(TitleLabel.Text);
            MessageLabel.Hidden = string.IsNullOrWhiteSpace(MessageLabel.Text);

            _config.PropertyChanged += Config_PropertyChanged;

            SetNeedsLayout();
            LayoutIfNeeded();
        }

        /// <summary>
        ///     Dismisses the custom dialog.
        /// </summary>
        /// <param name="finishedAction">An optional action to invoke after the custom dialog has been dismissed.</param>
        public void Dismiss(Action finishedAction = null)
        {
            this.FadeOut(0.2f, finishedAction: finishedAction);

            IsShowing = false;
        }

        /// <summary>
        ///     Shows the custom dialog.
        /// </summary>
        /// <param name="finishedAction">An optional action to invoke after the custom dialog has been shown.</param>
        public void Show(Action finishedAction = null)
        {
            this.FadeIn(0.2f, finishedAction: finishedAction);

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

            Frame = UIApplication.SharedApplication.KeyWindow.Bounds;

            DimmerBackground.Frame = Bounds;

            var alertWidth = (float)Math.Min(300, Bounds.Width - 60);
            var alertWidthWithPadding = alertWidth - 32;

            nfloat alertHeight = 0f;

            // Adjust indeterminate progress bar, if visible.
            if (!IndeterminateProgress.Hidden)
            {
                IndeterminateProgress.Center = new CGPoint(alertWidth / 2, 0);
                IndeterminateProgress.Frame = new CGRect(IndeterminateProgress.Frame.X, 16, IndeterminateProgress.IntrinsicContentSize.Width, IndeterminateProgress.IntrinsicContentSize.Height);

                alertHeight = IndeterminateProgress.Frame.Y + IndeterminateProgress.Frame.Height + 16;
            }

            // Adjust determinate progress bar, if visible.
            if (!DeterminateProgress.Hidden)
            {
                DeterminateProgress.Frame = new CGRect(16, IndeterminateProgress.Hidden ? 16 : IndeterminateProgress.Frame.Y + IndeterminateProgress.Frame.Height + 4, alertWidthWithPadding, 4);

                alertHeight = DeterminateProgress.Frame.Y + DeterminateProgress.Frame.Height + 16;
            }

            // Adjust title label, if visible.
            if (!TitleLabel.Hidden)
            {
                TitleLabel.Frame = new CGRect(16, alertHeight, alertWidthWithPadding, 0);
                TitleLabel.ResizeForTextHeight();

                alertHeight = TitleLabel.Frame.Y + TitleLabel.Frame.Height + 16;
            }

            // Adjust message label, if visible.
            if (!MessageLabel.Hidden)
            {
                MessageLabel.Frame = new CGRect(16, TitleLabel.Hidden ? alertHeight : alertHeight - 12, alertWidthWithPadding, 0);
                MessageLabel.ResizeForTextHeight();

                alertHeight = MessageLabel.Frame.Y + MessageLabel.Frame.Height + 16;
            }

            AlertBackground.Center = new CGPoint(Bounds.Width / 2, Bounds.Height / 2);
            AlertBackground.Frame = new CGRect(AlertBackground.Frame.X, AlertBackground.Frame.Y, alertWidth, alertHeight);

            AlertBackgroundBlur.Frame = new CGRect(0, 0, AlertBackground.Frame.Width, AlertBackground.Frame.Height);
        }
        #endregion

        #region Constructors
        public DialogMessagingLoadingAlert()
            : base()
        {
            Initialize();
        }

        public DialogMessagingLoadingAlert(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public DialogMessagingLoadingAlert(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public DialogMessagingLoadingAlert(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        public DialogMessagingLoadingAlert(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
        #endregion

        #region Private Methods
        private void AdjustProgress()
        {
            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                float determinateProgress;
                bool determinateProgressHidden, indeterminateProgressHidden;

                if (_config.Progress.HasValue)
                {
                    indeterminateProgressHidden = true;

                    determinateProgress = _config.Progress.Value / 100f;
                    determinateProgressHidden = false;
                }
                else
                {
                    indeterminateProgressHidden = false;

                    determinateProgress = 0;
                    determinateProgressHidden = true;
                }

                // Compare the existing 'Hidden' values, so that we can check whether requiring layout again is necessary.
                if (DeterminateProgress.Hidden != determinateProgressHidden || IndeterminateProgress.Hidden != indeterminateProgressHidden)
                {
                    DeterminateProgress.Hidden = determinateProgressHidden;
                    IndeterminateProgress.Hidden = indeterminateProgressHidden;

                    SetNeedsLayout();
                }

                DeterminateProgress.Progress = determinateProgress;

                LayoutIfNeeded();
            });
        }

        private void AssignOwnership()
        {
            AddSubviews(DimmerBackground, AlertBackground);
            BringSubviewToFront(AlertBackground);

            AlertBackground.AddSubviews(AlertBackgroundBlur, DeterminateProgress, IndeterminateProgress, TitleLabel, MessageLabel);
            AlertBackgroundBlur.SendSubviewToBack(AlertBackgroundBlur);
        }

        private void Initialize()
        {
            // A unique tag per instance allows multiple dialogs of the same type to be shown at the same time.
            Tag = new Random().Next(int.MinValue, int.MaxValue);

            AssignOwnership();

            StyleViews();
        }

        private void StyleViews()
        {
            BackgroundColor = UIColor.Clear;

            DimmerBackground.Opaque = false;
            DimmerBackground.BackgroundColor = UIColor.Black;
            DimmerBackground.Alpha = 0.4f;

            AlertBackground.Opaque = false;
            AlertBackground.BackgroundColor = UIColor.Clear;
            AlertBackground.ClipsToBounds = true;
            AlertBackground.Layer.CornerRadius = 15f;

            // If iOS 13 or later, query dark mode traits for colors.
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                AlertBackgroundBlur.Effect = UIBlurEffect.FromStyle(UIApplication.SharedApplication.KeyWindow.TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Light ? UIBlurEffectStyle.ExtraLight : UIBlurEffectStyle.ExtraDark);

                TitleLabel.TextColor = UIColor.LabelColor;
                MessageLabel.TextColor = UIColor.LabelColor;

                IndeterminateProgress.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Large;
            }
            // Otherwise, use static theme.
            else
            {
                AlertBackgroundBlur.Effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);

                TitleLabel.TextColor = UIColor.Black;
                MessageLabel.TextColor = UIColor.Black;

                IndeterminateProgress.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.WhiteLarge;
            }

            DeterminateProgress.ProgressTintColor = UIColor.Blue;
            DeterminateProgress.TrackTintColor = UIColor.LightGray;

            IndeterminateProgress.StartAnimating();

            TitleLabel.TextAlignment = UITextAlignment.Center;
            TitleLabel.Font = UIFont.BoldSystemFontOfSize(17);
            TitleLabel.Lines = 0;

            MessageLabel.TextAlignment = UITextAlignment.Center;
            MessageLabel.Font = UIFont.SystemFontOfSize(15);
            MessageLabel.Lines = 0;
        }
        #endregion
    }
}