using System;
using CoreGraphics;
using DialogMessaging.Core.Platforms.iOS.Infrastructure;
using DialogMessaging.Interactions;
using Foundation;
using UIKit;

namespace DialogMessaging.Core.Platforms.iOS.Alerts;

public class DialogMessagingToast : UIView, ICustomDialog<IToastConfig>
{
    #region Fields
    private IToastConfig _config;
    #endregion

    #region Properties
    /// <summary>
    ///     Gets or sets whether the view is currently showing.
    /// </summary>
    public bool IsShowing { get; set; }

    /// <summary>
    ///     Gets the message label.
    /// </summary>
    public UILabel MessageLabel { get; } = new();
    #endregion

    #region Public Methods
    /// <summary>
    ///     Applies the provided dialog configuration to the view.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    public void ApplyDialogConfig(IToastConfig config)
    {
        _config = config;

        // Configure message.
        if (!string.IsNullOrWhiteSpace(_config.Message))
            MessageLabel.Text = _config.Message;

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

        var keyWindow = UIApplication.SharedApplication.KeyWindow;

        var toastWidth = keyWindow.Bounds.Width - 32;
        var toastWidthWithPadding = toastWidth - 32;

        MessageLabel.Frame = new CGRect(16, 16, toastWidthWithPadding - 16, 0);
        MessageLabel.ResizeForTextHeight();
        MessageLabel.ResizeForTextWidth();

        toastWidth = (nfloat)Math.Min(toastWidth, MessageLabel.Frame.Width + 32);

        Center = new CGPoint(keyWindow.Center.X, 0);
        Frame = new CGRect(Center.X - (toastWidth / 2), keyWindow.Bounds.Height - (keyWindow.Bounds.Height / 5), toastWidth, MessageLabel.Frame.Height + 32);

        Layer.CornerRadius = (MessageLabel.Font.LineHeight + 32) / 2;
    }
    #endregion

    #region Constructors
    public DialogMessagingToast()
        : base()
    {
        Initialize();
    }

    public DialogMessagingToast(CGRect frame)
        : base(frame)
    {
        Initialize();
    }

    public DialogMessagingToast(NSCoder coder)
        : base(coder)
    {
        Initialize();
    }

    public DialogMessagingToast(NSObjectFlag t)
        : base(t)
    {
        Initialize();
    }

    public DialogMessagingToast(IntPtr handle)
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
        // A unique tag per type allows only one dialog of the same type to be shown at one time.
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