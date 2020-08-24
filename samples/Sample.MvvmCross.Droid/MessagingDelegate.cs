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
            => true;

        public bool OnActionSheetRequested(IActionSheetConfig config)
            => true;

        public bool OnAlertRequested(IAlertConfig config)
            => true;

        public bool OnConfirmRequested(IConfirmConfig config)
            => true;

        public bool OnDeleteRequested(IDeleteConfig config)
            => true;

        public bool OnHideLoadingRequested()
            => true;

        public bool OnLoginRequested(ILoginConfig config)
            => true;

        public bool OnPromptRequested(IPromptConfig config)
            => true;

        public bool OnShowLoadingRequested(ILoadingConfig config)
            => true;

        public bool OnSnackbarRequested(ISnackbarConfig config)
        {
            config.BackgroundColor = _colors[_random.Next(0, _colors.Length)];

            return true;
        }

        public bool OnToastRequested(IToastConfig config)
            => true;
    }
}