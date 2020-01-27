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

## Getting Started

Get started by calling `DialogMessaging.MessagingService.Init()`. `Init()` has overflow methods where you can provide your own `IMessagingService` should you wish to do so. **On Android you will need to provide an Application or Activity reference.**

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

### iOS
Coming soon!
