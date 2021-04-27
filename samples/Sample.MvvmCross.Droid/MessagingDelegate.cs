using Android.Graphics;
using DialogMessaging;
using DialogMessaging.Interactions;
using System;

namespace Sample.MvvmCross.Droid
{
    public class MessagingDelegate : IMessagingDelegate
    {
        private readonly Color[] _colors = new[] { Color.Red, Color.Green, Color.Blue };
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
            // Randomize whether to display the dialog with the configured custom layout, or default.
            if (_random.NextDouble() > 0.5)
                config.LayoutResID = config.StyleResID = null;

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
}