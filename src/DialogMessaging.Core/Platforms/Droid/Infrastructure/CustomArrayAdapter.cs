using Android.Content;
using Android.Views;
using Android.Widget;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure
{
    public class CustomArrayAdapter : ArrayAdapter<string>
    {
        #region Properties
        /// <summary>
        /// Gets the resource ID being used to inflate the items.
        /// </summary>
        public int TextViewResourceID { get; }

        /// <summary>
        /// Gets the value assigner.
        /// </summary>
        public IValueAssigner ValueAssigner { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets a View that displays the data at the specified position in the data set.
        /// </summary>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = MessagingService.ViewCreator.CreateView(ValueAssigner, TextViewResourceID, parent, false);

            if (view is TextView textView)
                textView.Text = GetItem(position);

            return view;
        }
        #endregion

        #region Constructors
        public CustomArrayAdapter(Context context, int textViewResourceId, IValueAssigner valueAssigner)
            : base(context, textViewResourceId)
        {
            TextViewResourceID = textViewResourceId;
            ValueAssigner = valueAssigner;
        }
        #endregion
    }
}
