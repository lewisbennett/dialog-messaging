// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Sample.MvvmCross.iOS;

[Register ("MainViewController")]
partial class MainViewController
{
    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton ActionSheetBottomButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton ActionSheetButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton AlertButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton ConfirmButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton DeleteButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton LoadingButton { get; set; }

    [Outlet]
    UIKit.UIButton LoginButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton PromptButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton SnackbarButton { get; set; }

    [Outlet]
    [GeneratedCode ("iOS Designer", "1.0")]
    UIKit.UIButton ToastButton { get; set; }

    void ReleaseDesignerOutlets ()
    {
        if (ActionSheetBottomButton != null) {
            ActionSheetBottomButton.Dispose ();
            ActionSheetBottomButton = null;
        }

        if (ActionSheetButton != null) {
            ActionSheetButton.Dispose ();
            ActionSheetButton = null;
        }

        if (AlertButton != null) {
            AlertButton.Dispose ();
            AlertButton = null;
        }

        if (ConfirmButton != null) {
            ConfirmButton.Dispose ();
            ConfirmButton = null;
        }

        if (DeleteButton != null) {
            DeleteButton.Dispose ();
            DeleteButton = null;
        }

        if (LoadingButton != null) {
            LoadingButton.Dispose ();
            LoadingButton = null;
        }

        if (PromptButton != null) {
            PromptButton.Dispose ();
            PromptButton = null;
        }

        if (SnackbarButton != null) {
            SnackbarButton.Dispose ();
            SnackbarButton = null;
        }

        if (ToastButton != null) {
            ToastButton.Dispose ();
            ToastButton = null;
        }
    }
}