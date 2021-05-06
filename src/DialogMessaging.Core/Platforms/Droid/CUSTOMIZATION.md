# Customization (Android)

This document covers dialog customization added by Android. Android inherits all customization available from DialogMessaging's [Shared](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared) resources. Please [read here](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared/CUSTOMIZATION.md) for an overview of customization available in addition to that outlined in this document.

## Interaction configuration properties

Android provides additional properties for all interaction configuration objects. Properties that affect most/all configurations are explained below, but you can view properties available to individual configurations [here](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/Droid/Interactions).

### Layout resource ID

Android provides an additional property to all interaction configuration objects, `LayoutResID`. This is the resource ID of the Android layout file you would like to use for the view associated with the interaction configuration object. `LayoutResID` is provided via [`IBaseInteraction`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Droid/Interactions/Base/BaseInteraction.cs#L9).

### Cancelable and style resource ID

Android provides `Cancelable` and `StyleResID` via [`IBaseDialogConfig`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Droid/Interactions/Base/BaseDialogConfig.cs#L3). This means that the properties are only available to interaction configuration objects that implement this interface.

`Cancelable` is used to determine whether the dialog can be canceled without having to interact with widgets within the dialog itself (for example: confirm/cancel buttons). If enabled, the user can click outside of the dialog window to dismiss it.

`StyleResID` is used to tell the dialog to use a specific style resource ID. If provided, the dialog will use the provided style to theme itself and subviews.

## Custom layout files

You can provide custom dialog layouts to DialogMessaging by using the `LayoutResID` property, available to all interaction configuration objects. Use the below XML attributes to configure your layout to work with DialogMessaging:

* `DialogElement` - Tells DialogMessaging what information the view is responsible for displaying.
* `AutoHude` - Controls whether the view should be hidden if it doesn't have any information to display. Note that not all of the built-in DialogMessaging dialogs respect this property in scenarios where it wouldn't make sense (for example: hiding a text field if it doesn't have any pre-filled text).

### Example

Make sure to include the `http://schemas.android.com/apk/res-auto` XML namespace.

```
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    android:orientation="vertical"
    android:paddingLeft="?android:attr/dialogPreferredPadding"
    android:paddingRight="?android:attr/dialogPreferredPadding">
    <EditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:layout_marginBottom="10dp"
        app:DialogElement="UsernameInputText" />
    <EditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:layout_marginBottom="10dp"
        app:DialogElement="PasswordInputText" />
    <CheckBox
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        app:DialogElement="PasswordVisibilityToggle" />
</LinearLayout>
```

### Resources

[All available dialog elements](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Droid/Schema/DialogElement.cs)

[DialogMessaging default layout files](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Resources/layout)

[Sample.Droid custom alert layout](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/samples/Sample.Droid/Resources/layout/dialog_alert.xml)

## Extending the messaging service

Using one of the overflow methods available with `DialogMessaging.MessagingService.Init(...)`, you can provide your own implementation of [`IMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared/IMessagingDelegate.cs). This can be an implementation from scratch, or you can extend the functionality provided by either [`BaseMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared/Base/BaseMessagingService.cs) or [`DroidMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Droid/DroidMessagingService.cs).
