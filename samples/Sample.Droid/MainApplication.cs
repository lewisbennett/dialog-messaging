﻿using Android.App;
using Android.Graphics;
using Android.Runtime;
using DialogMessaging;
using DialogMessaging.Interactions;
using Google.Android.Material.Snackbar;
using System;
using ViewPump;

namespace Sample.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public override void OnCreate()
        {
            base.OnCreate();

            ViewPumpService.Init();

            MessagingService.Init(this);
            MessagingService.Delegate = new MessagingDelegate();

            ISnackbarConfig.DefaultActionButtonTextColor = Color.White;
            ISnackbarConfig.DefaultDuration = Snackbar.LengthLong;
            ISnackbarConfig.DefaultMessageTextColor = Color.White;
        }

        public MainApplication()
            : base()
        {
        }

        public MainApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
    }
}