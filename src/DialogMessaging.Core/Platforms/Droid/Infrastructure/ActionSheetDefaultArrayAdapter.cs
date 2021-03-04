using Android.Content;
using Android.Views;
using Android.Widget;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure
{
    public class ActionSheetDefaultArrayAdapter<TActionSheetItemConfig> : ArrayAdapter<TActionSheetItemConfig>
        where TActionSheetItemConfig : IActionSheetItemConfig
    {
        #region Public Methods
        /// <summary>
        /// Gets a View that displays the data at the specified position in the data set.
        /// </summary>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = GetItem(position);

            return MessagingServiceCore.ViewManager.InflateView(item.LayoutResID ?? Resource.Layout.dialog_default_action_sheet_item, parent, false, (v, d, a) => ConfigureView(v, d, a, item));
        }
        #endregion

        #region Constructors
        public ActionSheetDefaultArrayAdapter(Context context)
            : base(context, 0)
        {
        }
        #endregion

        #region Private Methods
        private void ConfigureView(View view, string dialogElement, bool autoHide, TActionSheetItemConfig item)
        {
            switch (view, dialogElement)
            {
                case (TextView textView, DialogElement.Message):

                    if (string.IsNullOrWhiteSpace(item.Message) && autoHide)
                        textView.Visibility = ViewStates.Gone;
                    else
                        textView.Text = item.Message;

                    return;

                default:
                    return;
            }
        }
        #endregion
    }
}
