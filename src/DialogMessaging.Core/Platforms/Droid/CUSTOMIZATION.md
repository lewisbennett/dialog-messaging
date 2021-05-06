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
