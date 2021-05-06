using Foundation;
using UIKit;

namespace Sample.MvvmCross.iOS.Dialogs
{
    partial class CustomAlert
    {
        #region Properties
        [Outlet]
        public UILabel MessageLabel { get; set; }

        [Outlet]
        public UIButton OKButton { get; set; }

        [Outlet]
        public UILabel TitleLabel { get; set; }
        #endregion
    }
}
