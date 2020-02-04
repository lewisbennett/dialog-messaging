using Android.Content;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure
{
    public interface IValueAssigner
    {
        #region Properties
        /// <summary>
        /// Gets the context.
        /// </summary>
        Context Context { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="viewConfig">The view configuration.</param>
        void AssignValue(ViewConfig viewConfig);
        #endregion
    }
}
