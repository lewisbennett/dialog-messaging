# Customization

This document covers dialog customization available between all supported platforms. Supported platforms inherit all
customization available within
DialogMessaging's [Shared](https://github.com/lewisbennett/dialog-messaging/tree/master/src/DialogMessaging.Core/Platforms/Shared)
resources. For an overview of additional customization provided by each supported platform, please refer to the links
below:

* [Android](https://github.com/lewisbennett/dialog-messaging/tree/master/src/DialogMessaging.Core/Platforms/Droid/CUSTOMIZATION.md)

## Interaction configuration default properties

DialogMessaging provides a class for each interaction configuration object specifically for providing default
customization for each interaction type. Default values are assigned to every interaction configuration object that is
created, and can be overwritten if needed.

## Interaction configuration properties

The simplest way to customize dialogs is to use the properties of
the [interaction configuration objects](https://github.com/lewisbennett/dialog-messaging/tree/master/src/DialogMessaging.Core/Platforms/Shared/Interactions)
. These definitions contain configuration that is globally available on all supported platforms.

### Data property

All interaction configuration objects implement
the [`IBaseInteraction`](https://github.com/lewisbennett/dialog-messaging/blob/master/src/DialogMessaging.Core/Platforms/Shared/Interactions/Base/BaseInteraction.cs#L3)
interface, which provides a `Data` property of type `object`. This isn't used by DialogMessaging, but is provided to
allow you to pass optional data payloads via the interaction configuration. This is particularily useful in scenarios
where your app's business logic is separate to its view logic. For example, it can be used to pass an identifier for
additional customization and/or view styling only available to the view part of your app.
