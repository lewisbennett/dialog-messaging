using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System;

namespace DialogMessaging.Infrastructure
{
    public class CustomLayoutInflater : LayoutInflater, LayoutInflater.IFactory
    {
        #region Properties
        /// <summary>
        /// Gets the value assigner, any.
        /// </summary>
        public IValueAssigner ValueAssigner { get; }
        #endregion

        #region Public Methods
        public override LayoutInflater CloneInContext(Context newContext)
        {
            return new CustomLayoutInflater(newContext);
        }

        public View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            var view = OnCreateView(name, attrs);

            if (view == null)
                return null;

            if (ValueAssigner != null)
                ValueAssigner.AssignValues(view.ExtractAttributedViews(attrs));

            return view;
        }
        #endregion

        #region Constructors
        public CustomLayoutInflater(Context context)
            : base(context)
        {
            Initialize();
        }

        public CustomLayoutInflater(Context context, IValueAssigner valueAssigner)
            : base(context)
        {
            Initialize();

            ValueAssigner = valueAssigner;
        }

        public CustomLayoutInflater(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion

        #region Private Methods
        private void Initialize()
        {
            Factory = this;
        }
        #endregion
    }
}
