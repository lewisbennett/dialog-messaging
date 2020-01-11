<div align="center">

[![GitHub license](https://img.shields.io/badge/license-Apache%202-blue.svg?style=flat-square)](https://raw.githubusercontent.com/lewisbennett/dialog-messaging/master/README.md)

</div>

# DialogMessaging

Inspired by [Acr.UserDialogs](https://github.com/aritchie/userdialogs), DialogMessaging is a cross platform, customizable dialog messaging service.

## Dialogs

Synchronous and asynchronous methods are available for the following:
- Alert
- Confirm
- Delete (coming soon)
- Loading (coming soon)
- Action sheet (dialog and bottom sheet) (coming soon)
- Toast (coming soon)
- Snackbar (coming soon)

## Customization

### Android

Layout and style ID's can be provided for individual dialogs or a default value can be set. If none are provided the normal Android AlertDialog's will be used.
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

### iOS
Coming soon!

## Getting Started

Get started by calling `DialogMessaging.MessagingService.Init()`. `Init()` has overflow methods where you can provide your own `IMessagingService` should you wish to do so. **On Android you will need to provide an Application or Activity reference**.
