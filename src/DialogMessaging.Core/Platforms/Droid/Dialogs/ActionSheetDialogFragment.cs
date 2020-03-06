using Android.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DialogMessaging.Core;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Linq;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class ActionSheetDialogFragment : AbstractDialogFragment<IActionSheetConfig>
    {
        #region Fields
        private ListView _listView;
        #endregion

        #region Event Handlers
        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = Config.Items[e.Position];

            Config.ItemClickAction?.Invoke(item);
            item.ClickAction?.Invoke();

            Dismiss();
        }

        public override void OnRegisteredViewClick(string dialogElement, View view)
        {
            base.OnRegisteredViewClick(dialogElement, view);

            switch (dialogElement)
            {
                case DialogElement.ButtonSecondary:
                    Config.CancelButtonClickAction?.Invoke();
                    break;
            }

            Dismiss();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="viewConfig">The view configuration.</param>
        public override void AssignValue(ViewConfig viewConfig)
        {
            switch (viewConfig.DialogElement)
            {
                case DialogElement.ItemsSource:

                    if (!(viewConfig.View is ListView listView) || Config.Items.Count < 1)
                        break;

                    _listView = listView;

                    var adapter = new CustomArrayAdapter(Context, Config.ItemLayoutResID ?? Resource.Layout.dialog_default_action_sheet_item, this);

                    adapter.AddAll(Config.Items.Select(i => i.Text).ToList());

                    _listView.Adapter = adapter;

                    break;

                case DialogElement.ButtonSecondary:

                    if (string.IsNullOrWhiteSpace(Config.CancelButtonText) || !viewConfig.View.TrySetText(Config.CancelButtonText))
                        viewConfig.HideElementIfNeeded();
                    else
                        RegisterForClickEvents(viewConfig.DialogElement, viewConfig.View);

                    break;
            }

            base.AssignValue(viewConfig);
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public override void CreateDialog(AlertDialog.Builder builder)
        {
            base.CreateDialog(builder);

            var view = MessagingService.ViewCreator.CreateView(this, Resource.Layout.dialog_default_action_sheet, null, false);

            if (view != null)
                builder.SetView(view);

            builder.SetNegativeButton(Config.CancelButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonSecondary, s as View));
        }
        #endregion

        #region Lifecycle
        public override void OnResume()
        {
            base.OnResume();

            _listView.ItemClick += ListView_ItemClick;
        }

        public override void OnPause()
        {
            base.OnPause();

            _listView.ItemClick -= ListView_ItemClick;
        }
        #endregion

        #region Constructors
        public ActionSheetDialogFragment()
            : base()
        {
        }

        public ActionSheetDialogFragment(IActionSheetConfig config)
            : base(config)
        {
        }

        public ActionSheetDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
