﻿using System;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid.Dialogs.Base;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs;

public class ActionSheetAppCompatDialogFragment<TActionSheetItemConfig> : BaseAppCompatDialogFragment<IActionSheetConfig<TActionSheetItemConfig>>
    where TActionSheetItemConfig : IActionSheetItemConfig
{
    #region Fields
    private TextView _cancelButton;
    private ListView _listView;
    #endregion

    #region Event Handlers
    private void CancelButton_Click(object sender, EventArgs e)
    {
        Config.CancelButtonClickAction?.Invoke();

        Dismiss();
    }

    private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
        var item = Config.Items[e.Position];

        Config.ItemClickAction?.Invoke(item);

        item.ClickAction?.Invoke();

        Dismiss();
    }
    #endregion

    #region Protected Methods
    protected override void ConfigureDialogBuilder(AlertDialog.Builder builder)
    {
        base.ConfigureDialogBuilder(builder);

        if (MessagingServiceCore.ViewManager.InflateView(Resource.Layout.dialog_default_action_sheet, null, false, ConfigureView) is View view)
            builder.SetView(view);

        if (!string.IsNullOrWhiteSpace(Config.CancelButtonText))
            builder.SetNegativeButton(Config.CancelButtonText, CancelButton_Click);
    }

    protected override void ConfigureView(View view, string dialogElement, bool autoHide)
    {
        base.ConfigureView(view, dialogElement, autoHide);

        switch (view, dialogElement)
        {
            // The Android Button inherits from TextView, and using TextView's for buttons is common.
            case (TextView button, DialogElement.ButtonSecondary):

                _cancelButton = button;

                if (string.IsNullOrWhiteSpace(Config.CancelButtonText) && autoHide)
                    _cancelButton.Visibility = ViewStates.Gone;

                else
                    _cancelButton.Text = Config.CancelButtonText;

                return;

            case (ListView listView, DialogElement.ItemsSource):

                _listView = listView;

                var adapter = new ActionSheetDefaultArrayAdapter<TActionSheetItemConfig>(Context);

                adapter.AddAll(Config.Items);

                _listView.Adapter = adapter;

                return;

            default:

                return;
        }
    }
    #endregion

    #region Lifecycle
    public override void OnResume()
    {
        base.OnResume();

        if (_cancelButton != null)
            _cancelButton.Click += CancelButton_Click;

        if (_listView != null)
            _listView.ItemClick += ListView_ItemClick;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        if (_cancelButton != null)
            _cancelButton.Click -= CancelButton_Click;

        if (_listView != null)
            _listView.ItemClick -= ListView_ItemClick;
    }
    #endregion

    #region Constructors
    public ActionSheetAppCompatDialogFragment()
        : base()
    {
    }

    public ActionSheetAppCompatDialogFragment(IActionSheetConfig<TActionSheetItemConfig> config)
        : base(config)
    {
    }

    public ActionSheetAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
        : base(handle, transfer)
    {
    }
    #endregion
}