using Android.Graphics;
using DialogMessaging;
using DialogMessaging.Interactions;
using System;

namespace Sample.MvvmCross.Droid
{
    public class MessagingDelegate : IMessagingDelegate
    {
        private readonly Color[] _colors = new[] { Color.Red, Color.Green, Color.Blue };
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

        public bool OnLoginRequested(ILoginConfig config)
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