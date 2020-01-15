using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class ActionSheetAppCompatDialogFragment : AbstractAppCompatDialogFragment<IActionSheetConfig>
    {
        #region Fields
        private ListView _listView;
        #endregion

        #region Event Handlers
        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Config.ItemClickAction?.Invoke(Config.Items[e.Position]);

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
        /// <param name="dialogElement">The dialog element extracted from the view.</param>
        public override void AssignValue(KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
            switch (dialogElement.Key)
            {
                case DialogElement.ItemsSource:

                    if (!(dialogElement.Value.Item1 is ListView listView) || Config.Items.Count < 1)
                        break;

                    _listView = listView;

                    var adapter = new ArrayAdapter<string>(Context, Config.ItemLayoutResID ?? Resource.Layout.dialog_default_action_sheet_item);

                    adapter.AddAll(Config.Items.Select(i => i.Text).ToList());

                    _listView.Adapter = adapter;

                    return;

                case DialogElement.ButtonSecondary:

                    if (!string.IsNullOrWhiteSpace(Config.CancelButtonText) && dialogElement.Value.Item1.TrySetText(Config.CancelButtonText))
                    {
                        RegisterForClickEvents(dialogElement.Key, dialogElement.Value.Item1);
                        return;
                    }

                    break;

                default:
                    base.AssignValue(dialogElement);
                    return;
            }

            dialogElement.HideElementIfNeeded();
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public override void CreateDialog(AlertDialog.Builder builder)
        {
            base.CreateDialog(builder);

            var view = new CustomLayoutInflater(Context, this).Inflate(Resource.Layout.dialog_default_action_sheet, null, false);

            if (view != null)
                builder.SetView(view);

            builder.SetNegativeButton(Config.CancelButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonSecondary, s as View));
        }
        #endregion

        #region Lifecycle
        public override void OnResume()
        {
            base.OnResume();

            if (_listView != null)
                _listView.ItemClick += ListView_ItemClick;
        }

        public override void OnPause()
        {
            base.OnPause();

            if (_listView != null)
                _listView.ItemClick -= ListView_ItemClick;
        }
        #endregion

        #region Constructors
        public ActionSheetAppCompatDialogFragment()
            : base()
        {
        }

        public ActionSheetAppCompatDialogFragment(IActionSheetConfig config)
            : base(config)
        {
        }

        public ActionSheetAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
