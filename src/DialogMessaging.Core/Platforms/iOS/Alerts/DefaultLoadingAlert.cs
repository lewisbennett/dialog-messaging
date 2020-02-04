using CoreGraphics;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.iOS.Infrastructure;
using Foundation;
using System;
using System.ComponentModel;
using UIKit;

namespace DialogMessaging.Platforms.iOS.Alerts
{
    public class DefaultLoadingAlert : UIView, IValueAssigner, IShowable
    {
        #region Fields
        private ILoadingConfig _config;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the alert background.
        /// </summary>
        public UIView AlertBackground { get; } = new UIView();

        /// <summary>
        /// Gets the alert background blur.
        /// </summary>
        public UIVisualEffectView AlertBackgroundBlur { get; } = new UIVisualEffectView();

        /// <summary>
        /// Gets or sets the configuration, if any.
        /// </summary>
        public ILoadingConfig Config
        {
            get => _config;

            set
            {
                if (_config != null)
                    _config.PropertyChanged -= Config_PropertyChanged;

                _config = value;

                if (_config != null)
                    _config.PropertyChanged += Config_PropertyChanged;
            }
        }

        /// <summary>
        /// Gets the determinate progress view.
        /// </summary>
        public UIProgressView DeterminateProgress { get; } = new UIProgressView(UIProgressViewStyle.Bar);

        /// <summary>
        /// Gets the dimmer background.
        /// </summary>
        public UIView DimmerBackground { get; } = new UIView();

        /// <summary>
        /// Gets the indeterminate progress view.
        /// </summary>
        public UIActivityIndicatorView IndeterminateProgress { get; } = new UIActivityIndicatorView();

        /// <summary>
        /// Gets or sets whether the showable is currently showing.
        /// </summary>
        public bool IsShowing { get; set; }

        /// <summary>
        /// Gets the message label.
        /// </summary>
        public UILabel MessageLabel { get; } = new UILabel();

        /// <summary>
        /// Gets the title label.
        /// </summary>
        public UILabel TitleLabel { get; } = new UILabel();
        #endregion

        #region Event Handlers
        private void Config_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Config == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(ILoadingConfig.Progress):
                    AdjustProgress();
                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void AssignValues(object config)
        {
            if (!(config is ILoadingConfig loadingConfig))
                return;

            Config = loadingConfig;

            AdjustProgress();

            TitleLabel.Text = Config.Title;
            MessageLabel.Text = Config.Message;

            TitleLabel.Hidden = string.IsNullOrWhiteSpace(TitleLabel.Text);
            MessageLabel.Hidden = string.IsNullOrWhiteSpace(MessageLabel.Text);

            LayoutIfNeeded();
        }

        /// <summary>
        /// Dismisses the showable.
        /// </summary>
        /// <param name="finishedAction">An optional action to complete when hiding has finished.</param>
        public void Dismiss(Action finishedAction = null)
        {
            if (!IsShowing)
                return;

            IsShowing = false;

            this.FadeOut(0.2f, finishedAction: finishedAction);
        }

        /// <summary>
        /// Shows the showable.
        /// </summary>
        /// <param name="finishedAction">An optional action to complete when hiding has finished.</param>
        public void Show(Action finishedAction = null)
        {
            LayoutIfNeeded();

            this.FadeIn(0.2f, finishedAction: finishedAction);

            IsShowing = true;
        }
        #endregion

        #region Lifecycle
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Frame = UIApplication.SharedApplication.KeyWindow.Bounds;

            DimmerBackground.Frame = Bounds;

            var alertWidth = (float)Math.Min(300, Bounds.Width - 60);
            var alertWidthWithPadding = alertWidth - 32;

            nfloat alertHeight = 0f;

            if (!IndeterminateProgress.Hidden)
            {
                IndeterminateProgress.SetCenter(alertWidth / 2, 0);
                IndeterminateProgress.SetFrame(IndeterminateProgress.Frame.X, 16, IndeterminateProgress.IntrinsicContentSize.Width, IndeterminateProgress.IntrinsicContentSize.Height);

                alertHeight = IndeterminateProgress.Frame.Y + IndeterminateProgress.Frame.Height + 16;
            }

            if (!DeterminateProgress.Hidden)
            {
                DeterminateProgress.SetFrame(16, IndeterminateProgress.Hidden ? 16 : IndeterminateProgress.Frame.Y + IndeterminateProgress.Frame.Height + 4, alertWidthWithPadding, 4);

                alertHeight = DeterminateProgress.Frame.Y + DeterminateProgress.Frame.Height + 16;
            }

            if (!TitleLabel.Hidden)
            {
                TitleLabel.SetFrame(16, alertHeight, alertWidthWithPadding, 0);
                TitleLabel.ResizeForTextHeight();

                alertHeight = TitleLabel.Frame.Y + TitleLabel.Frame.Height + 16;
            }   

            if (!MessageLabel.Hidden)
            {
                MessageLabel.SetFrame(16, TitleLabel.Hidden ? alertHeight : alertHeight - 12, alertWidthWithPadding, 0);
                MessageLabel.ResizeForTextHeight();

                alertHeight = MessageLabel.Frame.Y + MessageLabel.Frame.Height + 16;
            }

            AlertBackground.SetCenter(Bounds.Width / 2, Bounds.Height / 2);
            AlertBackground.SetFrame(AlertBackground.Frame.X, AlertBackground.Frame.Y, alertWidth, alertHeight);

            AlertBackgroundBlur.SetFrame(0, 0, AlertBackground.Frame.Width, AlertBackground.Frame.Height);
        }
        #endregion

        #region Constructors
        public DefaultLoadingAlert()
            : base()
        {
            Initialize();
        }

        public DefaultLoadingAlert(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public DefaultLoadingAlert(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public DefaultLoadingAlert(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        public DefaultLoadingAlert(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
        #endregion

        #region Private Methods
        private void AdjustProgress()
        {
            if (Config == null)
                return;

            if (Config.Progress == null)
            {
                IndeterminateProgress.Hidden = false;

                DeterminateProgress.Progress = 0;
                DeterminateProgress.Hidden = true;
            }
            else
            {
                IndeterminateProgress.Hidden = true;

                DeterminateProgress.Progress = (int)Config.Progress / 100f;
                DeterminateProgress.Hidden = false;
            }

            SetNeedsLayout();
            LayoutIfNeeded();
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
            Tag = 61854;

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

            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                AlertBackgroundBlur.Effect = UIBlurEffect.FromStyle(UIApplication.SharedApplication.KeyWindow.TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Light ? UIBlurEffectStyle.ExtraLight : UIBlurEffectStyle.ExtraDark);

                TitleLabel.TextColor = UIColor.LabelColor;
                MessageLabel.TextColor = UIColor.LabelColor;
            }
            else
            {
                AlertBackgroundBlur.Effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);

                TitleLabel.TextColor = UIColor.Black;
                MessageLabel.TextColor = UIColor.Black;
            }

            DeterminateProgress.ProgressTintColor = UIColor.Blue;
            DeterminateProgress.TrackTintColor = UIColor.LightGray;

            IndeterminateProgress.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Large;
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
