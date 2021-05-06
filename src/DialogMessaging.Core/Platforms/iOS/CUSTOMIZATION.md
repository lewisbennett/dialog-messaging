# Customization (iOS)

This document covers dialog customization added by iOS. iOS inherits all customization available from DialogMessaging's [Shared](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared) resources. Please [read here](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared/CUSTOMIZATION.md) for an overview of customization available in addition to that outlined in this document.

## Interaction configuration properties

iOS provides additional properties for all interaction configuration objects. Properties that affect most/all configurations are explained below, but you can view properties available to individual configurations [here](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/iOS/Interactions).

### Custom view type

iOS provides an additional property to all interaction configuration objects, `CustomViewType`. This is the type that you would like to be instantiated when displaying a dialog. `CustomViewType` is provided via [`IBaseInteraction`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/iOS/Interactions/Base/BaseInteraction.cs#L11).

Your custom dialogs must implement the [`ICustomDialog`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/iOS/Infrastructure/ICustomDialog.cs) interface. This provides your dialog with everything required for DialogMessaging to correctly handle your dialog implementation. **Important:** Your `Show` and `Dismiss` methods must correctly set the state of `IsShowing` to avoid strange behaviour with view handling.

If your custom view loads its layout from a NIB/XIB, you can assign [`DialogViewAttribute`](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/iOS/Attributes) to your view implementation. This will tell DialogMessaging that your view should be created from a layout file, rather than constructing the class manually.

### Resources

[DialogMessaging default veiew files](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/src/DialogMessaging.Core/Platforms/iOS/Alerts)

## Extending the messaging service

Using one of the overflow methods available with `DialogMessaging.MessagingService.Init(...)`, you can provide your own implementation of [`IMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared/IMessagingDelegate.cs). This can be an implementation from scratch, or you can extend the functionality provided by either [`BaseMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared/Base/BaseMessagingService.cs) or [`IosMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/iOS/IosMessagingService.cs).
