using System;
using DialogMessaging;
using DialogMessaging.Interactions;
using Sample.iOS.Dialogs;
using UIKit;

namespace Sample.iOS;

public class MessagingDelegate : IMessagingDelegate
{
    private readonly UIColor[] _colors = new[] { UIColor.Red, UIColor.Green, UIColor.Blue };
    private readonly Random _random = new();

    public bool OnActionSheetBottomRequested<TActionSheetItemConfig>(IActionSheetBottomConfig<TActionSheetItemConfig> config)
        where TActionSheetItemConfig : IActionSheetItemConfig
    {
        return true;
    }

    public bool OnActionSheetRequested<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
        where TActionSheetItemConfig : IActionSheetItemConfig
    {
        return true;
    }

    public bool OnAlertRequested(IAlertConfig config)
    {
        if (_random.NextDouble() > 0.5)
            config.CustomViewType = typeof(CustomAlert);

        return true;
    }

    public bool OnConfirmRequested(IConfirmConfig config)
    {
        return true;
    }

    public bool OnDeleteRequested(IDeleteConfig config)
    {
        return true;
    }

    public bool OnHideLoadingRequested()
    {
        return true;
    }

    public bool OnLoadingRequested(ILoadingConfig config)
    {
        return true;
    }

    public bool OnLoginRequested(ILoginConfig config)
    {
        return true;
    }

    public bool OnPromptRequested(IPromptConfig config)
    {
        return true;
    }

    public bool OnSnackbarRequested(ISnackbarConfig config)
    {
        // Choose a random color to apply to the background of the snackbar.
        config.BackgroundColor = _colors[_random.Next(0, _colors.Length)];

        return true;
    }

    public bool OnToastRequested(IToastConfig config)
    {
        return true;
    }
}