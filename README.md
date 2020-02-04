<div align="center">

[![GitHub license](https://img.shields.io/badge/license-Apache%202-blue.svg?style=flat-square)](https://raw.githubusercontent.com/lewisbennett/dialog-messaging/master/README.md)

</div>

# DialogMessaging

Inspired by [Acr.UserDialogs](https://github.com/aritchie/userdialogs), DialogMessaging is a cross platform, customizable dialog messaging service.

## Dialogs

- Alert*
- Confirm*
- Delete*
- Loading*
- Action sheet*
- Action sheet bottom*
- Prompt*
- Toast
- Snackbar

\*Synchronous and asynchronous methods are available.

## Getting Started (MvvmCross)

Add a reference to `DialogMessaging.Core` and `DialogMessaging.MvvmCross`. At the entry point for your app call `DialogMessaging.MessagingService.Init()`. **On Android you must provide an Activity or Application reference as well as an instance of** `MvvmCrossViewCreator`**. If an instance of** `MvvmCrossViewCreator` **isn't provided, dialogs that use custom views won't work properly.**

## Getting Started (non-MvvmCross)

Add a reference to `DialogMessaging.Core` and `DialogMessaging`. At the entry point for your app call `DialogMessaging.MessagingService.Init()`. **On Android you must provide an Activity or Application reference.**

## Customization

You can access and set a custom `IMessagingDelegate` via `DialogMessaging.MessagingService.Delegate`. These delegate methods are called by their respective display methods and allow you to customize the display process. By returning `true` or `false` you can optionally cancel dialogs from being shown. **If you set a custom** `IMessagingService` **you are responsible for calling and handling delegate methods.**

### Android

You can set layout and style ID's on a dialog-by-dialog basis or you can assign default values. If no customization is provided the normal Android AlertDialog's and internal layouts will be used.
```
// Defaults.
IAlertConfig.DefaultLayoutID = Resource.Layout.MyCustomLayout;
IAlertConfig.DefaultStyleID = Resource.Style.MyAppTheme;

// Individual dialog.
var alertConfig = new AlertConfig
{
    LayoutID = Resource.Layout.MyCustomLayout,
    StyleID = Resource.Style.MyAppTheme
};
```
In your custom layouts, assign dialog elements using the `app:DialogElement` tag. Any part of the layout that uses this tag will be hidden if the corresponding data inside of the configuration holds no value. For example: if `Title` within the configuration object is null or empty any layout element that uses `app:DialogElement="Title"` will be hidden. This can be customised using the `app:HideWhenNotInUse` tag which by default is set to `true`.

See [`DialogElement`](https://github.com/lewisbennett/dialog-messaging/blob/master/src/DialogMessaging.Core/Platforms/Droid/Schema/DialogElement.cs) for all usable dialog element values. Be aware that not all are available for every dialog. For example: `ProgressDeterminate` isn't available when using `Alert`.

### iOS

You can set view types on a dialog-by-dialog basis or you can assign default values. If no customization is provided the normal iOS UIAlertController's and internal views will be used.
```
// Defaults.
IAlertConfig.DefaultViewType = typeof(CustomAlertView);

// Individual dialog.
var alertConfig = new AlertConfig
{
    ViewType = typeof(CustomAlertView)
};
```
Your custom views must implement `IShowable` which gives you the `Show` and `Dismiss` methods. This is where you control the presentation of your view such as animations. You should not interact with the view hierarchy as this is done for you. You can optionally assign `DialogViewAttribute` to your view class if the view has an associated XIB/NIB file. To assign configuration values to your view, implement `IValueAssigner`.

## Samples

See [samples](https://github.com/lewisbennett/dialog-messaging/tree/master/samples) for examples.
