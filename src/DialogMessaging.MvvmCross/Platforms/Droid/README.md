# DialogMessaging.MvvmCross (Android)

## Getting started

At the entry point for your app, call `DialogMessaging.MessagingService.Init(...)`. You need to provide an activity or application reference, and you can optionally provide your own [`IDialogMessagingActivityLifecycleCallbacks`]() and/or [`IMessagingService`]() implementations.
