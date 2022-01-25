using System;
using CoreGraphics;
using DialogMessaging.Core.Platforms.iOS;
using DialogMessaging.Core.Platforms.iOS.Attributes;
using DialogMessaging.Core.Platforms.iOS.Infrastructure;
using DialogMessaging.Interactions;
using Foundation;
using UIKit;

namespace Sample.iOS.Dialogs;

[Register("CustomAlert")]
[DialogView("CustomAlert")]
public partial class CustomAlert : UIView, ICustomDialog<IAlertConfig>
{
    #region Fields
    private IAlertConfig _config;
    private bool _hasAddedEventHandlers;
    #endregion

    #region Properties
    /// <summary>
    ///     Gets or sets whether the view is currently showing.
    /// </summary>
    public bool IsShowing { get; set; }
    #endregion

    #region Event Handlers
    private void OKButton_TouchUpInside(object sender, EventArgs e)
    {
        _config.OkButtonClickAction?.Invoke();
        _config.DismissedAction?.Invoke();

        Dismiss();
    }
    #endregion

    #region Public Methods
    /// <summary>
    ///     Applies the provided dialog configuration to the view.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    public void ApplyDialogConfig(IAlertConfig config)
    {
        _config = config;

        MessageLabel.Text = config.Message;
        TitleLabel.Text = config.Title;

        OKButton.SetTitle(config.OkButtonText, UIControlState.Normal);

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
    public override void LayoutSubviews()
    {
        base.LayoutSubviews();

        if (!_hasAddedEventHandlers)
        {
            OKButton.TouchUpInside += OKButton_TouchUpInside;

            _hasAddedEventHandlers = true;
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (disposing)
            OKButton.TouchUpInside -= OKButton_TouchUpInside;
    }
    #endregion

    #region Constructors
    public CustomAlert()
        : base()
    {
        Initialize();
    }

    public CustomAlert(CGRect frame)
        : base(frame)
    {
        Initialize();
    }

    public CustomAlert(NSCoder coder)
        : base(coder)
    {
        Initialize();
    }

    public CustomAlert(NSObjectFlag t)
        : base(t)
    {
        Initialize();
    }

    public CustomAlert(IntPtr handle)
        : base(handle)
    {
        Initialize();
    }
    #endregion

    #region Private Methods
    private void Initialize()
    {
        // A unique tag per instance allows multiple dialogs of the same type to be shown at the same time.
        Tag = new Random().Next(int.MinValue, int.MaxValue);
    }
    #endregion
}