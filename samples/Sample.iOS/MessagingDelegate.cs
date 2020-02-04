using DialogMessaging;
using DialogMessaging.Interactions;
using System;
using UIKit;

namespace Sample.iOS
{
    public class MessagingDelegate : IMessagingDelegate
    {
        private readonly UIColor[] _colors = new[] { UIColor.Red, UIColor.Green, UIColor.Blue };
        private readonly Random _random = new Random();

        public bool OnActionSheetBottomRequested(IActionSheetBottomConfig config)
        {
            return true;
        }

        public bool OnActionSheetRequested(IActionSheetConfig config)
        {
            return true;
        }

        public bool OnAlertRequested(IAlertConfig config)
        {
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

        public bool OnPromptRequested(IPromptConfig config)
        {
            return true;
        }

        public bool OnShowLoadingRequested(ILoadingConfig config)
        {
            return true;
        }

        public bool OnSnackbarRequested(ISnackbarConfig config)
        {
            config.BackgroundColor = _colors[_random.Next(0, _colors.Length)];

            return true;
        }

        public bool OnToastRequested(IToastConfig config)
        {
            return true;
        }
    }
}