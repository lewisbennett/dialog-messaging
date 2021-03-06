﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DialogMessaging.Interactions
{
    public partial interface IActionSheetConfig : IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the cancel button is clicked.
        /// </summary>
        Action CancelButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the cancel button text.
        /// </summary>
        string CancelButtonText { get; set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        IList<IActionSheetItemConfig> Items { get; }

        /// <summary>
        /// Gets the action invoked when an item is clicked.
        /// </summary>
        Action<IActionSheetItemConfig> ItemClickAction { get; }
        #endregion
    }

    public partial class ActionSheetConfig : BaseConfig, IActionSheetConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the cancel button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the cancel button text.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public IList<IActionSheetItemConfig> Items { get; internal set; } = new List<IActionSheetItemConfig>();

        /// <summary>
        /// Gets the action invoked when an item is clicked.
        /// </summary>
        public Action<IActionSheetItemConfig> ItemClickAction { get; set; }
        #endregion
    }

    public partial class ActionSheetAsyncConfig : BaseAsyncConfig, IActionSheetConfig
    {
        #region Fields
        IList<IActionSheetItemConfig> IActionSheetConfig.Items => Items.Cast<IActionSheetItemConfig>().ToList();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the action invoked when the cancel button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the cancel button text.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public IList<ActionSheetItemAsyncConfig> Items { get; internal set; } = new List<ActionSheetItemAsyncConfig>();

        /// <summary>
        /// Gets the action invoked when an item is clicked.
        /// </summary>
        public Action<IActionSheetItemConfig> ItemClickAction { get; internal set; }
        #endregion
    }
}
