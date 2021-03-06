﻿using System;

namespace DialogMessaging.Interactions
{
    public partial interface IBaseConfig
    {
        #region Properties
        /// <summary>
        /// An optional data payload. Use this for storing information that you plan to intercept using your own IMessagingDelegate.
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// Gets the action invoked when the dialog is dismissed.
        /// </summary>
        Action DismissedAction { get; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }
        #endregion
    }

    public partial class BaseConfig : IBaseConfig
    {
        #region Properties
        /// <summary>
        /// An optional data payload. Use this for storing information that you plan to intercept using your own IMessagingDelegate.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the action invoked when the dialog is dismissed.
        /// </summary>
        public Action DismissedAction { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }

    public partial class BaseAsyncConfig : IBaseConfig
    {
        #region Properties
        /// <summary>
        /// An optional data payload. Use this for storing information that you plan to intercept using your own IMessagingDelegate.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets the action invoked when the dialog is dismissed.
        /// </summary>
        public Action DismissedAction { get; internal set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }
}
